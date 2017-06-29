using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;

namespace PCBQuotes.Helpers
{
    public class ModelHelper
    {
        /// <summary>
        /// 获取模型类对应的数据表名称，约定在类上使用TableAttribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetTableNameByModel<T>()
        {
            Type t = typeof(T);
            var tableAtt = (TableAttribute)t.GetCustomAttributes(typeof(TableAttribute), true).SingleOrDefault();//约定模型类写TableAttribute,用反射获取
            if (tableAtt != null)
            {
                return tableAtt.Name;
            }
            return string.Empty;
        }

        public static T SetValueByPropertyName<T>(T t, string propertyName, object value)
        {
            Type tt = typeof(T);
            var p = tt.GetProperty(propertyName);
            if (p != null && p.CanWrite)//判断有此字段，并且有Setter
            {
                Type fType = p.PropertyType;
                if (!Convert.IsDBNull(value))
                {
                    //如果为Nullable类型判断一下，不然会提示转换错误
                    if (fType.IsGenericType && fType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    {
                        if (value == null)
                        {
                            p.SetValue(t, null, null);
                        }
                        else
                        {
                            p.SetValue(t, Convert.ChangeType(value, Nullable.GetUnderlyingType(fType), System.Globalization.CultureInfo.CurrentCulture), null);
                        }

                    }
                    else
                    {
                        if (value != null)
                        {
                            if (fType.Name.Equals("String"))
                            {
                                if (!string.IsNullOrWhiteSpace(value.ToString()))
                                {
                                    p.SetValue(t, Convert.ChangeType(value, fType, System.Globalization.CultureInfo.CurrentCulture), null);
                                }
                            }
                            else
                            {
                                p.SetValue(t, Convert.ChangeType(value, fType, System.Globalization.CultureInfo.CurrentCulture), null);
                            }
                        }
                    }
                }

                //default(T)//取得类型默认值

            }

            return t;
        }

        /// <summary>
        /// 获取字段类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static Type GetTypeByPropertyName<T>(string propertyName)
        {
            Type t = typeof(T);
            var p = t.GetProperty(propertyName);
            return p.PropertyType;
        }

        /// <summary>
        /// 获取所有attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object[] GetAttributesByPropertyName<T>(string propertyName)
        {
            Type t = typeof(T);
            return t.GetProperty(propertyName).GetCustomAttributes(true);
        }

        /// <summary>
        /// 必填项   
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static RequiredAttribute Required<T>(string propertyName)
        {
            Type t = typeof(T);
            var re = t.GetProperty(propertyName).GetCustomAttributes(typeof(RequiredAttribute), true).SingleOrDefault();
            return (RequiredAttribute)re;
        }

        /// <summary>
        /// 字符串长度
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static StringLengthAttribute StringLength<T>(string propertyName)
        {
            Type t = typeof(T);
            var re = t.GetProperty(propertyName).GetCustomAttributes(typeof(StringLengthAttribute), true).SingleOrDefault();
            return (StringLengthAttribute)re;
        }

        public static object GetValueByPropertyName<T>(T t, string propertyName)
        {
            Type tt = typeof(T);
            var prop = tt.GetProperty(propertyName);
            if (prop != null)
            {
                return prop.GetValue(t, null);
            }
            return null;
        }

        /// <summary>
        /// 获取实体类显示名称
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string[] GetColumnDisplayNames(Type t)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(t);
            List<string> re = new List<string>();
            foreach (PropertyDescriptor prop in properties)
            {
                var disAtt = (DisplayAttribute)t.GetProperty(prop.Name).GetCustomAttributes(typeof(DisplayAttribute), true).SingleOrDefault();
                if (disAtt != null && false == disAtt.GetAutoGenerateField())
                {
                    continue;
                }

                var disCN = disAtt != null ? disAtt.Name : prop.Name;
                re.Add(disCN);

            }
            return re.ToArray();
        }

        /// <summary>
        /// 获取实体类字段名
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string[] GetColumnNames(Type t)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(t);
            List<string> re = new List<string>();
            foreach (PropertyDescriptor prop in properties)
            {
                var disAtt = (DisplayAttribute)t.GetProperty(prop.Name).GetCustomAttributes(typeof(DisplayAttribute), true).SingleOrDefault();
                if (disAtt != null && false == disAtt.GetAutoGenerateField())
                {
                    continue;
                }
                re.Add(prop.Name);
            }
            return re.ToArray();
        }


        /// <summary>
        /// 获取实体类字段名
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string[] GetColumnNames(Type t, bool includeNotDiaplay, bool includeKeyColumn)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(t);
            List<string> re = new List<string>();
            foreach (PropertyDescriptor prop in properties)
            {
                if (!includeNotDiaplay)
                {
                    var disAtt = (DisplayAttribute)t.GetProperty(prop.Name).GetCustomAttributes(typeof(DisplayAttribute), true).SingleOrDefault();
                    if (disAtt != null && false == disAtt.GetAutoGenerateField())
                    {
                        continue;
                    }
                }
                if (!includeKeyColumn)
                {
                    var keyAtt = (KeyAttribute)t.GetProperty(prop.Name).GetCustomAttributes(typeof(KeyAttribute), true).SingleOrDefault();
                    if (keyAtt != null)
                    {
                        continue;
                    }
                }
                re.Add(prop.Name);
            }
            return re.ToArray();
        }


        /// <summary>
        /// 将实体类生成datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns
        public static DataTable ToDataTable<T>(T t)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                //使用DiaplayAttribute 获得字段显示名称,也可在实体类使用DispalyNameAttribute.
                var disAtt = (DisplayAttribute)typeof(T).GetProperty(prop.Name).GetCustomAttributes(typeof(DisplayAttribute), true).SingleOrDefault();
                var columnName = disAtt != null ? disAtt.Name : prop.Name;//表头字段名，如果有在实体类中定义DiaplayAttribute使用它，没有就用字段名.
                table.Columns.Add(columnName + "(" + prop.Name + ")", Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            return table;
        }

        public static DataTable ToDataTable<T>(T t, string[] excludeFields)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                if (excludeFields != null && excludeFields.Any(x => x.Equals(prop.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }
                //使用DiaplayAttribute 获得字段显示名称,也可在实体类使用DispalyNameAttribute.
                var disAtt = (DisplayAttribute)typeof(T).GetProperty(prop.Name).GetCustomAttributes(typeof(DisplayAttribute), true).SingleOrDefault();
                var columnName = disAtt != null ? disAtt.Name : prop.Name;//表头字段名，如果有在实体类中定义DiaplayAttribute使用它，没有就用字段名.
                //将显示名称和字段名称组合，方便后期转实体类
                table.Columns.Add(columnName + "(" + prop.Name + ")", Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            return table;
        }
    }
}
