using iOps.Core.Model;
using Omu.ValueInjecter;
using System;

namespace iOps.Website.Mappers
{
    public class EntityToNullInt : LoopValueInjection
    {
        protected override bool TypesMatch(Type sourceType, Type targetType)
        {
            return sourceType.IsSubclassOf(typeof (DelEntity)) && targetType == typeof (int?);
        }

        protected override object SetValue(object o)
        {
            if (o == null)
                return null;
            return (o as DelEntity).ID;
        }
    }
}