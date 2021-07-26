using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Diagnostics.CodeAnalysis;

namespace AirLiquide_Test.Database
{
    public class GuidGenerator : ValueGenerator<Guid>
    {
        public override bool GeneratesTemporaryValues => false;

        public override Guid Next([NotNull] EntityEntry entry)
        {
            return Guid.NewGuid();
        }
    }
}