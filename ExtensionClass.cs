using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        // - konwersja na double lub wartość domyślna
        public static double ToDoubleOrDefault(this object My, double defaultValue)
        {
            try  {
               return Convert.ToDouble(My);
            } catch {
               return defaultValue;
            }
        }
        
        // - konwersja na Int32 lub wartość domyślna
        public static Int32 ToInt32OrDefault(this object My, Int32 defaultValue)
        {
            try {
               return Convert.ToInt32(My);
            } catch {
               return defaultValue;
            }
        }

        // - czy obiekt jest liczbą
        public static bool IsNumericType(this object My)
        {
            switch (Type.GetTypeCode(My.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

    }
}
