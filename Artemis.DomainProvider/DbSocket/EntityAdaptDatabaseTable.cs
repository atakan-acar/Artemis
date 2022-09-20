using Artemis.DomainProvider.ScriptInitiliaze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.ConsoleUI.DbSocket
{
    public class EntityAdaptDatabaseTable
    {
        /// <summary>
        /// Script set all entities
        /// </summary>
        /// <param name="nameSpace">Folder with assets </param>
        /// <param name="assigned">Do you have BaseEntity</param>
        /// <returns></returns>
        public static string AdaptAll(string nameSpace, Type startType, Type? assigned = null)
        {
            string result = "";
            Type[] types = Types(nameSpace, assigned);

            if (types is null)
                return result;

            

            for (int i = 0; i < types.Length; i++)
            {
                Table table = new Table();
                Type domain = types[i];
                table.TableName = domain.Name;
                PropertyInfo[] properties = domain.GetProperties();
                if (properties.Length > 0)
                {
                    IList<Column> columns = new List<Column>();
                    for (int prop = 0; prop < properties.Length; prop++)
                    {
                        var property = properties[prop];

                        Column c = new Column(property.Name, property.PropertyType);
                        columns.Add(c);
                    }
                    table.Columns = columns;
                } 
                string script = Script.Init(table); 
                result += script;
            }

            return result;
        }


        /// <summary>
        /// Gets objects that will exist in the database 
        /// </summary>
        /// <param name="nameSpace">Retrieves All objects from the specified File</param>
        /// <param name="assigned">Inherited objects of the specified type come</param>
        /// <returns></returns>
        private static Type[] Types(string nameSpace, Type? assigned = null)
        {
            Type[] typeArr = null;
            if (assigned is null)
            {
                typeArr = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(t => t.GetTypes())
                    .Where(x => x.FullName.Contains(nameSpace) && x.IsClass)
                    .ToArray();
            }
            else
            {
                typeArr = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(t => t.GetTypes())
                    .Where(x => x.FullName.Contains(nameSpace) && x.IsClass && assigned.IsAssignableFrom(x))
                    .ToArray();

            }
            return typeArr;
        }

    }
}
