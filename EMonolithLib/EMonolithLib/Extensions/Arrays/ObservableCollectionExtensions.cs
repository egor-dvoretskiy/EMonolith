using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Extensions.Arrays
{
    public static class ObservableCollectionExtensions
    {
        public static int FindIndex<T>(this ObservableCollection<T> collection, Predicate<T> condition)
        {
            for (int i = 0; i < collection.Count; i++)
                if (condition(collection[i]))
                    return i;

            return -1;
        }
    }
}
