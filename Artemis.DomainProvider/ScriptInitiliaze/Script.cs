using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.DomainProvider.ScriptInitiliaze
{

    public class Column
    {
        public string Name { get; set; }

        public int Order { get; set; }
        public bool IsKey { get; set; }
        public Type DataType { get; set; }   // Type or  --> byte int = 1, nvarchar(max)= 2, nvarchar({length}) = 4, datetime2(7) = 8,

        public Column(string name, Type dataType, bool isKey, int order)
        {
            Name = name;
            DataType = dataType;
            IsKey = isKey;
            Order = order;
        }
    }
    public class Table
    {
        public string TableName { get; set; }

        public IList<Column> Columns { get; set; } = new List<Column>();

        public Table()
        {

        }
        public Table(string tableName, IList<Column> columns)
        {
            TableName = tableName;
            Columns = columns;
        }
    }

    public static class Script
    {
        private static string SetColumn(Column column, Column lastColumn, string type, bool isKey)
        {
            string columnScript = "";
            string keyValue = isKey ? "PRIMARY KEY" : "";
            if (column == lastColumn)
            {
                columnScript += $"{column.Name} {type} {keyValue}";
            }
            else
            {
                columnScript += $"{column.Name} {type} {keyValue}, ";
            }

            return columnScript;
        }
        public static string Init(Table table)
        {
            string tableScript = "--{0} Table \nCREATE TABLE {0} ({1})\n";
            string columnScript = string.Empty;

            bool keyCheck = table.Columns.Where(x => x.IsKey).Count() > 1;

            if (keyCheck)
                throw new Exception("Two keys cannot be used");



            if (!table.Columns.Any()) return columnScript;

            foreach (var column in table.Columns)
            {
                string type = ConvertToTypeString(column.DataType);

                if (string.IsNullOrEmpty(type))
                    continue;

                columnScript += SetColumn(column, table.Columns.LastOrDefault(), type, column.IsKey);

            }

            tableScript = string.Format(tableScript, table.TableName, columnScript);
            return tableScript;
        }
        internal static string ConvertToTypeString(Type columnType)
        {
            if (columnType == typeof(int)) { return "int"; }
            else if (columnType == typeof(string)) { return "nvarchar(355)"; }
            else if (columnType == typeof(decimal)) { return "decimal(18,0)"; }
            else if (columnType == typeof(float)) { return "decimal(18,0)"; }
            else if (columnType == typeof(DateTime)) { return "datetime2(7)"; }
            else if (columnType == typeof(Guid)) { return "uniqueidentifier"; }
            else if (columnType == typeof(bool)) { return "bit"; }
            else { return String.Empty; }
        }
    }


}
