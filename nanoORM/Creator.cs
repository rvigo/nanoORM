using System;
using System.Data;
using System.Reflection;
using System.Text;

namespace nanoORM
{
    public static class Creator
    {
        public static T CreateObject<T>(IDataReader dr)
        {
            T obj = default(T);
            obj = Activator.CreateInstance<T>();

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                string propertyName = prop.Name;
                try
                {
                    if (!Equals(dr[prop.Name], DBNull.Value))
                        if (prop.PropertyType == typeof(bool))
                        {
                            bool value = Convert.ToBoolean(dr[prop.Name].ToString());
                            prop.SetValue(obj, value, null);
                        }
                        else
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                }
                catch
                {
                    throw new Exception();
                }
            }
            return obj;
        }

        public static string CreateQueryString<T>(T obj)
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo p in obj.GetType().GetRuntimeProperties())
            {
                if (p.GetValue(obj, null) != null)
                    sb.Append(string.Format(@"""{0}"" = ""{1}""", p.Name, p.GetValue(obj, null).ToString()));
            }

            return sb.ToString();
        }
    }
}

