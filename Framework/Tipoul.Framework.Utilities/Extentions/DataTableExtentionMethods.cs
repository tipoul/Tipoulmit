using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tipoul.Framework.Utilities.Extentions
{
    public static class DataTableExtentionMethods
    {
        public static DataTable ToDataTable(this Enum enm)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Key");
            dt.Columns.Add("Value");

            Array a = Enum.GetValues(enm.GetType());
            foreach (object key in a)
            {
                FieldInfo t2 = enm.GetType().GetField(key.ToString());
                if ((t2 == null))
                {
                    dt.Rows.Add(((int)(key)), key);
                }
                else
                {
                    DescriptionAttribute[] attr = (DescriptionAttribute[])t2.GetCustomAttributes(new DescriptionAttribute().GetType(), false);
                    if ((attr.Count() > 0))
                    {
                        dt.Rows.Add(((int)(key)), attr[0].Description);
                    }
                    else
                    {
                        dt.Rows.Add(((int)(key)), key);
                    }
                }
            }
            return dt;
        }
        public static string ToDescription(this Enum obj)
        {
            FieldInfo t2 = obj.GetType().GetField(obj.ToString());
            if (t2 == null)
                return obj.ToString();
            else
            {
                DescriptionAttribute[] attr = (DescriptionAttribute[])t2.GetCustomAttributes(new DescriptionAttribute().GetType(), false);
                if ((attr.Count() > 0))
                    return attr[0].Description;
                else
                    return obj.ToString();
            }
        }
        public static T StringToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}
