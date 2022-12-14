using Artemis.Common.ArtemisAttributes;
using Artemis.DomainProvider.ScriptInitiliaze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.ConsoleUI.DbSocket
{ 
    public class EntityAdaptDatabase
    {
        /// <summary>
        /// Script set all entities
        /// </summary>
        /// <param name="nameSpace">Folder with assets </param>
        /// <param name="assigned">Do you have BaseEntity</param>
        /// <returns></returns>
        public static string AdaptAll(string nameSpace, Type startType, Type? assigned = null)
        {
            string script = "";

            Type[] types = Types(x=> x.FullName.Contains(nameSpace));

            if (types is null) return script;

            script = LoopScript<Type>((t) => CreateTable(t), types, types.Length);

            return script;
        }


        /// <summary>
        /// Generates the script of the given object
        /// </summary>
        /// <param name="type">Generates the script of the given object</param> 
        /// <returns></returns>
        public static string AdaptEntity<T>() where T : class, new()
        {
            return CreateTable(typeof(T));
        }

        /// <summary>
        ///  Creates the data type of the object passed as a parameter
        /// </summary>
        /// <param name="type">Generates the script of the given object</param> 
        /// <returns></returns>
        public static string AdaptEntity(Type type)
        {
            return CreateTable(type);
        }
        /// <summary>
        ///  Creates the data type of the object passed as a parameter
        /// </summary>
        /// <param name="type">Generates the script of the given object</param> 
        /// <returns></returns>
        public static string AdaptEntity(object entity)
        {
            Type type = entity.GetType();
            return CreateTable(type);
        }


        /// <summary>
        /// Generates the script of the given types
        /// </summary>
        /// <param name="types">Types</param> 
        /// <returns></returns> 
        public static string AdaptEntity(Type[] types)
        {
            return LoopScript<Type>((t) => CreateTable(t), types, types.Length);
        }



        #region private methods 
        /// <summary>
        /// Gets objects that will exist in the database 
        /// </summary>
        /// <param name="nameSpace">Retrieves All objects from the specified File</param>
        /// <param name="assigned">Inherited objects of the specified type come</param>
        /// <returns></returns>
        private static Type[] Types(Expression<Func<Type, bool>> expression)
        {
            var typesFolder = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(t => t.GetTypes()).AsQueryable();

            Type[] types = typesFolder.Where(expression)
                    .ToArray();


            return types;
        }

        private static string LoopScript<T>(Func<T, string> action, T[] t, int iterations)
        {
            string script = string.Empty;
            for (int i = 0; i < iterations; i++)
            {
                script += action(t[i]);
            }
            return script;
        }


        private static string CreateTable(Type type)
        {

            Func<Table, string> scriptResponse = (x) => Script.Init(x);

            PropertyInfo[] properties = type.GetProperties();

            string script;

            int iterations = properties.Length;
            IList<Column> columns = new List<Column>();
            for (int i = 0; i < iterations; i++)
            {
                PropertyInfo property = properties[i];

                var viewAttribute = 
                    property.GetCustomAttribute(typeof(DatabaseViewAttribute));

                var databaseView = viewAttribute as DatabaseViewAttribute;

                if (databaseView is null)
                    continue;

                Column c = new Column(databaseView.ColumnName, property.PropertyType, databaseView.IsKey, databaseView.Order);

                columns.Add(c);
            }

            columns = columns.OrderBy(x => x.Order).ToList();
            Table table = new Table
            {
                Columns = columns,
                TableName = type.Name
            };


            script = scriptResponse(table);

            return script;
        }

        #endregion

    }
}
