using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsFactory
{
    public static class RandomElement
    {
        public static T GetRandomElements<T>(this IEnumerable<T> list, int elementsCount)
        {
            return list.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).FirstOrDefault();
        }
    }
}
