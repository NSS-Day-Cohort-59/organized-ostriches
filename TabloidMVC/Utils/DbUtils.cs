using System;
using Microsoft.Data.SqlClient;

namespace TabloidMVC.Utils
{
    public static class DbUtils
    {
        public static string GetNullableString(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            if (reader.IsDBNull(ordinal))
            {
                return null;
            }
            return reader.GetString(ordinal);
        }

        public static DateTime? GetNullableDateTime(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            if (reader.IsDBNull(ordinal))
            {
                return null;
            }
            return reader.GetDateTime(ordinal);
        }

        public static object ValueOrDBNull(object value)
        {
            return value ?? DBNull.Value;
        } 
    }
}
