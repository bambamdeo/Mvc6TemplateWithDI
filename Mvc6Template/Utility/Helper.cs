using System;
using System.ComponentModel;
using System.Reflection;

namespace Utility
{
    public class Helper
    {

    }
}

public static class StaticHelper
{
    public static string GetEnumDescription<T>(this T source)
    {
        try
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}







