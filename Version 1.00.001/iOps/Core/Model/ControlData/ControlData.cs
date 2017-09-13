using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace iOps.Core.Model
{
    /// <summary>
    /// ControlData: Defines the structure of the elements within the SQL Tables ControlData Field
    /// </summary>
    /// <example>
    /// <![CDATA[
    ///  <ControlData>
    ///   <Created>
    ///     <UserGUID>00000000-0000-0000-0000-000000000000</UserGUID>
    ///     <TimeStamp>2014-08-04T13:35:36.713</TimeStamp>
    ///   </Created>
    ///   <Updated>
    ///     <UserGUID>00000000-0000-0000-0000-000000000000</UserGUID>
    ///     <TimeStamp>1900-01-01T00:00:00.000</TimeStamp>
    ///   </Updated>
    ///   <Deleted>
    ///     <UserGUID>00000000-0000-0000-0000-000000000000</UserGUID>
    ///     <TimeStamp>1900-01-01T00:00:00.000</TimeStamp>
    ///   </Deleted>
    /// </ControlData>
    /// ]]>
    /// </example>
    //[XmlRootAttribute("ControlData", Namespace = "http://iOps.jbt.com", IsNullable = false)]
    [Serializable]
    public class ControlData
    {
        public ControlData()
        {
            Created = new ElementData();
            Updated = new ElementData();
            Deleted = new ElementData();
        }
        public ControlData(string controlDataXmlString)
        {
            Created = new ElementData();
            Updated = new ElementData();
            Deleted = new ElementData();
            ControlData cd = ImportToObject(controlDataXmlString, new ControlData());
            this.Created.UserGUID = cd.Created.UserGUID;
            this.Created.TimeStamp = cd.Created.TimeStamp;
            this.Updated.UserGUID = cd.Updated.UserGUID;
            this.Updated.TimeStamp = cd.Updated.TimeStamp;
            this.Deleted.UserGUID = cd.Deleted.UserGUID;
            this.Deleted.TimeStamp = cd.Deleted.TimeStamp;
        }
        public ControlData(XmlDocument controlDataXml)
        {
            Created = new ElementData();
            Updated = new ElementData();
            Deleted = new ElementData();
            ControlData cd = ImportToObject(controlDataXml, new ControlData());
            this.Created.UserGUID = cd.Created.UserGUID;
            this.Created.TimeStamp = cd.Created.TimeStamp;
            this.Updated.UserGUID = cd.Updated.UserGUID;
            this.Updated.TimeStamp = cd.Updated.TimeStamp;
            this.Deleted.UserGUID = cd.Deleted.UserGUID;
            this.Deleted.TimeStamp = cd.Deleted.TimeStamp;
        }


        [XmlElement("Created")]
        public ElementData Created { get; set; }
        [XmlElement("Updated")]
        public ElementData Updated { get; set; }
        [XmlElement("Deleted")]
        public ElementData Deleted { get; set; }

        [XmlIgnore]
        public bool IsDeleted { get { return (this.Deleted.TimeStamp > new DateTime(1900, 1, 1, 0, 0, 0)); } }

        private ControlData ImportToObject(XmlDocument xmlData, Object managedClassObject)
        {
            return ImportToObject(xmlData.InnerXml, managedClassObject);
        }

        private ControlData ImportToObject(string xmlData, Object managedClassObject)
        {

            //create and instance of XmlSerializer class and tell that instance which Class object you are going to deserialize
            XmlSerializer deserializer = new XmlSerializer(managedClassObject.GetType());

            managedClassObject = deserializer.Deserialize(new StringReader(xmlData));

            return (ControlData)managedClassObject;
        }

        public string ExportToXMLString()
        {
            XmlDocument serializedXML = ExportToXml1(this);
            return serializedXML.InnerXml;
        }

        public XmlDocument ExportToXml()
        {
            return ExportToXml1(this);
        }

        private XmlDocument ExportToXml1(Object managedClassObject)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces(); ns.Add("", "");

            //create an instance of XmlDocument class, it will be used to store the serialized XML
            XmlDocument serializedXMLDoc = new XmlDocument();

            //create and instance of XmlSerializer class and tell that instance which Class object you are going to serialize
            XmlSerializer serializer = new XmlSerializer(managedClassObject.GetType());

            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, managedClassObject, ns);
                ms.Position = 0;
                serializedXMLDoc.Load(ms);
                foreach (XmlNode node in serializedXMLDoc)
                {
                    if (node.NodeType == XmlNodeType.XmlDeclaration)
                    {
                        serializedXMLDoc.RemoveChild(node);
                    }
                }
                return serializedXMLDoc;
            }
        }

    }

    public class ElementData
    {
        private Guid? _UserGUID = new Guid(Guid.Empty.ToString());
        public ElementData()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public ElementData(Guid? userGUID, DateTime timeStamp)
        {
            UserGUID = userGUID;
            TimeStamp = timeStamp;
        }

        public Guid? UserGUID { get { return _UserGUID; } set { _UserGUID = value; } }
        public DateTime TimeStamp { get; set; }

    }
}
