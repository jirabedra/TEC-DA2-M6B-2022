using System;
using System.IO;

namespace WorldCupOrganization.Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AssemblyDataGetter.GetTypesInAssembly(@"../../../../WorldCupOrganization.Domain/bin/debug/netcoreapp3.1/WorldCupOrganization.Domain.dll");

            AssemblyDataGetter.FindImplementations(@"../../../../WorldCupOrganization.Logic.Interfaces/bin/debug/netcoreapp3.1/WorldCupOrganization.Logic.Interfaces.dll",
                @"../../../../WorldCupOrganization.Logic/bin/debug/netcoreapp3.1/WorldCupOrganization.Logic.dll");
        }
    }
}
