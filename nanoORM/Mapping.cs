using System.Collections.Generic;
using System.Data;


namespace nanoORM
{
    public class Mapping
    {
        public static T SingleItemMapping<T>(IDataReader dr)
        {
            while (dr.Read())
                return Creator.CreateObject<T>(dr);
            return default(T);
        }

        public static List<T> ListMapping<T>(IDataReader dr)
        {
            List<T> objList = new List<T>();
            while (dr.Read())
                objList.Add(Creator.CreateObject<T>(dr));
            return objList;
        }
    }
}
