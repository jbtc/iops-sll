using iOps.Core.Model;
using iOps.Core.Service;
using iOps.Website.Dto;
using iOps.Website.Mappers;

namespace iOps.Website.Controllers
{
    public class CountryController : Cruder<Country, CountryInput>
    {
        public CountryController(ICrudService<Country> service, IMapper<Country, CountryInput> v) : base(service, v)
        {
        }

        protected override string RowViewName
        {
            get
            {
                return "ListItems/Country";
            }
        }
    }
}