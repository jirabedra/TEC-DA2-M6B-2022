using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WorldCupOrganization.Reflection
{
    public class AssemblyDataGetter
    {
        public static void GetTypesInAssembly(string assemblyPath)
        {
            Console.WriteLine("Assembly " + assemblyPath + " will be read...");
            Assembly a = Assembly.LoadFrom(assemblyPath);
            Console.WriteLine("Types found in assembly are: ");
            foreach(Type t in a.GetTypes())
            {
                Console.WriteLine("Type {0} is visible? {1}." , t.Name, t.IsVisible);
                GetMembersForType(t);
            }

        }

        public static void GetMembersForType(Type t)
        {
            Console.WriteLine("Members in {0} are: ", t.Name);
            foreach (MemberInfo m in t.GetMembers(BindingFlags.Public | BindingFlags.Instance))
            {
                Console.WriteLine("Member {0} is {1}", m.Name, m.MemberType);
            }
        }

        public static void FindImplementations(string contractsPath, string implementationsPath)
        {
            Assembly contractsAssembly = Assembly.LoadFrom(contractsPath);
            Assembly implementationsAssembly = Assembly.LoadFrom(implementationsPath);
            foreach(Type contract in contractsAssembly.GetTypes().Where(x => x.IsInterface))
            {
                FindImplementationsFor(contract, implementationsAssembly);
            }
        }

        private static void FindImplementationsFor(Type contract, Assembly target)
        {
            List<string> ret = new List<string>();
            IEnumerable<Type> implementations;
            IEnumerable<Type> types = target.GetTypes();
            implementations = types.Where(t => contract.IsAssignableFrom(t));
            foreach (var imp in implementations)
            {
                Console.WriteLine("{0} can be assigned from {1}", contract.Name, imp.Name);                
            }
        }
        
    }
}
