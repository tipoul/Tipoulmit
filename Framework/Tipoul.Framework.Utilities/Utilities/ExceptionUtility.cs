using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Utilities.Utilities
{
    public class ExceptionUtility
    {
        public static T? TryDo<T>(Func<T> func, T? defaultValue = default)
        {
            try
            {
                return func.Invoke();
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
