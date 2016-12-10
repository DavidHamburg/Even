using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Even
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EvenStorageFormatAttribute : Attribute
    {
        public EvenStorageFormatAttribute(int format)
        {
            this.StorageFormat = format;
        }

        public int StorageFormat { get; }

        public static int GetStorageFormat(Type type)
        {
            if (type == null)
                return 0;

#if NETSTANDARD1_6
            var attr = type.GetTypeInfo().GetCustomAttributes(typeof(EvenStorageFormatAttribute), false).FirstOrDefault() as EvenStorageFormatAttribute;
#else
            var attr = type.GetCustomAttributes(typeof(EvenStorageFormatAttribute), false).FirstOrDefault() as EvenStorageFormatAttribute;
#endif

            return attr?.StorageFormat ?? 0;
        }
    }
}
