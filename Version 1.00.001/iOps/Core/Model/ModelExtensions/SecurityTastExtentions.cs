﻿using System.ComponentModel.DataAnnotations.Schema;

namespace iOps.Core.Model
{
    public partial class SecurityTask : DelEntity
    {
        [NotMapped]
        public ControlData ControlFields
        {
            get { return new ControlData(ControlField); }
            set { ControlField = value.ExportToXMLString(); }
        }

    }
}
