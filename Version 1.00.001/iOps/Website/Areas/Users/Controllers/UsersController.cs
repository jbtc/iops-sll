using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using iOps.Service;
using iOps.Core.Model;
using System.Data.Entity.Infrastructure;
using Omu.Encrypto;

namespace iOps.Website.Areas.Users.Controllers
{
    public class UsersController : Controller
    {
        private iopsContext db = new iopsContext();

        // GET: Users/Users
        public async Task<ActionResult> Index(string sortingOrder)
        {
           ViewBag.SortingName = String.IsNullOrEmpty(sortingOrder) ? "Username" : "";
            //var user = db.Users.Include(u => u.Salutation).Select(u => u.Organizations.Where(o => o.Designator.Equals('SLL')));
           var user = db.Users.Where(u => u.Organizations.Any(o => o.Designator.Equals("SLL")));

             switch (sortingOrder)
                {
                    case "Username":
                    user = user.OrderByDescending(u=> u.Username);
                    break;
     
                    default:
                    user = user.OrderBy(u => u.Username);
                    break;
                }
            return View(await user.ToListAsync());
        }

 

        // GET: Users/Users/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Users/Create
        public ActionResult Create()
        {
            ViewBag.SalutationID = new SelectList(db.Salutations, "ID", "Name");
            ViewBag.SecurityGroupsID = new MultiSelectList(db.SecurityGroups, "ID", "Name");
            ViewBag.SecurityRolesID = new MultiSelectList(db.SecurityRoles, "ID", "Name");
            ViewBag.SecurityTasksID = new MultiSelectList(db.SecurityTasks, "ID", "Name");
            ViewBag.UsersXrefScreensID = new MultiSelectList(db.UsersXrefScreens, "ID", "DisplayName");
            return View();
        }

        // POST: Users/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Username,Password,Approved,Active,SalutationID,FirstName,LastName,MiddleInitial,JobTitle,Department,HireDate,BirthDate")] User user)
        {
            DateTime dtInsertTime = DateTime.Now;
            string guidNewUser = dtInsertTime.ToString("yyyyMMdd-hhmm-ssff") + Guid.NewGuid().ToString().Substring(18);

            User userToInsert = new User() 
            {
                ID = Guid.Parse(guidNewUser),
                Password = user.Password,
                Username = user.Username,
                Approved = user.Approved,
                Active = user.Active,
                SalutationID = user.SalutationID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleInitial = user.MiddleInitial,
                JobTitle = user.JobTitle,
                Department = user.Department,
                HireDate = user.HireDate,
                BirthDate = user.BirthDate
            };
            try
            {
                ControlData cdUser = new ControlData();
                cdUser.Created.TimeStamp = dtInsertTime;
                userToInsert.ControlField = cdUser.ExportToXMLString();
                iOps.Service.UserService.ChangeUserPassword(ref userToInsert, user.Password);
                
                userToInsert.Organizations.Clear();
                userToInsert.Organizations.Add(await db.Organizations.SingleAsync(o => o.Designator.Equals("SLL")));

                userToInsert.SecurityGroups.Clear();
                foreach (string sg in Request["SecurityGroupsID"].Split(new char[] { ',' }))
                {
                    userToInsert.SecurityGroups.Add(await db.SecurityGroups.FindAsync(Guid.Parse(sg)));
                }

                userToInsert.SecurityRoles.Clear();
                foreach (string sr in Request["SecurityRolesID"].Split(new char[] { ',' }))
                {
                    userToInsert.SecurityRoles.Add(await db.SecurityRoles.FindAsync(Guid.Parse(sr)));
                }

                userToInsert.SecurityTasks.Clear();
                foreach (string st in Request["SecurityTasksID"].Split(new char[] { ',' }))
                {
                    userToInsert.SecurityTasks.Add(await db.SecurityTasks.FindAsync(Guid.Parse(st)));
                }

                List<Screen> cidScreens = db.Screens.Where(s => s.Name.Contains("SLL") && !s.IsDeleted).OrderBy(s => s.DisplayName).ToList<Screen>();
                userToInsert.UsersXrefScreens.Clear();
                int iScreens = 0;
                foreach(Screen scr in  cidScreens)
                {
                    iScreens++;
                    userToInsert.UsersXrefScreens.Add(new UsersXrefScreen() { UserID = userToInsert.ID, ScreenID = scr.ID, DisplayOrder = iScreens });
                }

                //db.Entry(userToInsert).State = EntityState.Added;
                db.Users.Add(userToInsert);
                await db.SaveChangesAsync();
                //return Json(new { success = true });
                return RedirectToAction("Index", "Users", new { area = "Users" });
                //return RedirectToAction("Index");
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            ViewBag.SalutationID = new SelectList(db.Salutations, "ID", "Name", userToInsert.SalutationID);
            ViewBag.SecurityGroupsID = new MultiSelectList(db.SecurityGroups, "ID", "Name",userToInsert.SecurityGroups.Select(sg=>sg.ID));
            ViewBag.SecurityRolesID = new MultiSelectList(db.SecurityRoles, "ID", "Name",userToInsert.SecurityRoles.Select(sr=>sr.ID));
            ViewBag.SecurityTasksID = new MultiSelectList(db.SecurityTasks, "ID", "Name",userToInsert.SecurityTasks.Select(st=>st.ID));
            ViewBag.UsersXrefScreensID = new MultiSelectList(db.UsersXrefScreens, "ID", "DisplayName",userToInsert.UsersXrefScreens);
            return View(user);
        }

        // GET: Users/Users/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalutationID = new SelectList(db.Salutations, "ID", "Name", user.SalutationID);
            ViewBag.SecurityGroupsID = new MultiSelectList(db.SecurityGroups, "ID", "Name",user.SecurityGroups.Select(sg=>sg.ID));
            ViewBag.SecurityRolesID = new MultiSelectList(db.SecurityRoles, "ID", "Name",user.SecurityRoles.Select(sr=>sr.ID));
            ViewBag.SecurityTasksID = new MultiSelectList(db.SecurityTasks, "ID", "Name",user.SecurityTasks.Select(st=>st.ID));
            ViewBag.UsersXrefScreensID = new MultiSelectList(db.UsersXrefScreens, "ID", "DisplayName",user.UsersXrefScreens);
            return View(user);
        }

        // POST: Users/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Password,Approved,Active,SalutationID,FirstName,LastName,MiddleInitial,JobTitle,Department,HireDate,BirthDate")] User user)
        {
            DateTime dtEditTime = DateTime.Now;
            User userToUpdate = await db.Users.FindAsync(user.ID);
            try
            {
                ControlData cdUser = new ControlData(userToUpdate.ControlField);
                if( cdUser.Created.TimeStamp == DateTime.Parse("1900-01-01") )
                {
                    cdUser.Created.TimeStamp = dtEditTime;
                }
                cdUser.Updated.TimeStamp = dtEditTime;
                userToUpdate.ControlField = cdUser.ExportToXMLString();
                userToUpdate.Approved = user.Approved;
                userToUpdate.Active = user.Active;
                userToUpdate.SalutationID = user.SalutationID;
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.MiddleInitial = user.MiddleInitial;
                userToUpdate.JobTitle = user.JobTitle;
                userToUpdate.Department = user.Department;
                userToUpdate.HireDate = user.HireDate;
                userToUpdate.BirthDate = user.BirthDate;
                if (userToUpdate.Password != user.Password)
                {
                    iOps.Service.UserService.ChangeUserPassword(ref userToUpdate, user.Password);
                }

                userToUpdate.SecurityGroups.Clear();
                foreach (string sg in Request["SecurityGroupsID"].Split(new char[] { ',' }))
                {
                    userToUpdate.SecurityGroups.Add(await db.SecurityGroups.FindAsync(Guid.Parse(sg)));
                }

                userToUpdate.SecurityRoles.Clear();
                foreach (string sr in Request["SecurityRolesID"].Split(new char[] { ',' }))
                {
                    userToUpdate.SecurityRoles.Add(await db.SecurityRoles.FindAsync(Guid.Parse(sr)));
                }

                userToUpdate.SecurityTasks.Clear();
                foreach (string st in Request["SecurityTasksID"].Split(new char[] { ',' }))
                {
                    userToUpdate.SecurityTasks.Add(await db.SecurityTasks.FindAsync(Guid.Parse(st)));
                }

                List<Screen> cidScreens = db.Screens.Where(s => s.DisplayName.Contains("SLL") && !s.IsDeleted).OrderBy(s => s.DisplayName).ToList<Screen>();
                userToUpdate.UsersXrefScreens.Clear();
                int iScreens = 0;
                foreach(Screen scr in  cidScreens)
                {
                    iScreens++;
                    userToUpdate.UsersXrefScreens.Add(new UsersXrefScreen() { UserID = userToUpdate.ID, ScreenID = scr.ID, DisplayOrder = iScreens });
                }

                db.Entry(userToUpdate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                //return View(userToUpdate);
                return RedirectToAction("Index");
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            ViewBag.SalutationID = new SelectList(db.Salutations, "ID", "Name", userToUpdate.SalutationID);
            ViewBag.SecurityGroupsID = new MultiSelectList(db.SecurityGroups, "ID", "Name",userToUpdate.SecurityGroups.Select(sg=>sg.ID));
            ViewBag.SecurityRolesID = new MultiSelectList(db.SecurityRoles, "ID", "Name",userToUpdate.SecurityRoles.Select(sr=>sr.ID));
            ViewBag.SecurityTasksID = new MultiSelectList(db.SecurityTasks, "ID", "Name",userToUpdate.SecurityTasks.Select(st=>st.ID));
            ViewBag.UsersXrefScreensID = new MultiSelectList(db.UsersXrefScreens, "ID", "DisplayName",userToUpdate.UsersXrefScreens);
            return View(user);
        }

        // GET: Users/Users/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            User user = await db.Users.FindAsync(id);
            user.SecurityGroups.Clear();
            user.SecurityRoles.Clear();
            user.SecurityTasks.Clear();
            user.Users_ContactInformation.Clear();
            user.UsersXrefScreens.Clear();
            user.Organizations.Clear();
            db.Users.Remove(user);
            db.Entry(user).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Users/Users/Destroy/5
        public async Task<ActionResult> Destroy(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Users/Destroy/5
        [HttpPost, ActionName("Destroy")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DestroyConfirmed(Guid id)
        {
            User user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // UserAdminList_Read
        public ActionResult UserAdminList_Read([DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<iOps.Core.Model.User> users = db.Users.Include(u => u.Salutation);
            DataSourceResult result = users.ToDataSourceResult(request);
            return Json(result);
        }

        // UserAdminList_Destroy
        public ActionResult UserAdminList_Destroy([DataSourceRequest]DataSourceRequest request, User user)
        {
            if (ModelState.IsValid)
            {
                this.Delete(user.ID);
            }
            // Return the removed product. Also return any validation errors.
            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }
                
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
