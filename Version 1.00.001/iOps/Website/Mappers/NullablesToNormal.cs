﻿using System;
using Omu.ValueInjecter;

namespace iOps.Website.Mappers
{
    public class NullablesToNormal : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name == c.TargetProp.Name &&
                   Nullable.GetUnderlyingType(c.SourceProp.Type) == c.TargetProp.Type;
        }
    }
}