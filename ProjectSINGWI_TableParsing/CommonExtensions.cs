using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.Json;

namespace ProjectSINGWI_TableParsing
{
    static class CommonExtensions
    {
        public static string ToJson(this DataTable value)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;

            foreach (DataRow dr in value.Rows)
            {
                row = new Dictionary<string, object>();

                foreach (DataColumn col in value.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }

                rows.Add(row);
            }
            
            JsonSerializerOptions Options = new JsonSerializerOptions();
            Options.WriteIndented = true;

            return JsonSerializer.Serialize(rows, Options);
        }
    }
}
