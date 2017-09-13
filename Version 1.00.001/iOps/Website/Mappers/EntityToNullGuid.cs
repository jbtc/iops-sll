using System;
using iOps.Core.Model;
using Omu.ValueInjecter;

namespace iOps.Website.Mappers
{
    public class EntityToNullGuid : LoopValueInjection
    {
        protected override bool TypesMatch(Type sourceType, Type targetType)
        {
            return sourceType.IsSubclassOf(typeof(DelEntity)) && targetType == typeof(Guid?);
        }

        protected override object SetValue(object o)
        {
            if (o == null) return null;
            return (o as DelEntity).ID;
        }
    }
}