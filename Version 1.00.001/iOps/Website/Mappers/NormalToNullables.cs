using System;
using Omu.ValueInjecter;

namespace iOps.Website.Mappers
{
    public class NormalToNullables : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            //ignore int = 0, Guid = 00000000-0000-0000-0000-000000000000 and DateTime = to 1/01/0001 DateTime = to 1/1/1900 00:00.000
            if ((c.SourceProp.Type == typeof(DateTime) && (DateTime)c.SourceProp.Value == default(DateTime)) ||
                (c.SourceProp.Type == typeof(DateTime) && (DateTime)c.SourceProp.Value == new DateTime(1900,1,1,0,0,0)) ||
                (c.SourceProp.Type == typeof(Guid) && (Guid)c.SourceProp.Value == default(Guid)) ||
                (c.SourceProp.Type == typeof(int) && (int)c.SourceProp.Value == default(int)))
                return false;

            return (c.SourceProp.Name == c.TargetProp.Name &&
                    c.SourceProp.Type == Nullable.GetUnderlyingType(c.TargetProp.Type));
        }
    }
}