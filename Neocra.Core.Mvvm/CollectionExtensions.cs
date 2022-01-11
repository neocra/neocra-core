using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Neocra.Core.Mvvm
{
    public static class CollectionExtensions
    {
        public static ObservableCollection<T> ToObservable<T>(this IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }
        
        public static ObservableCollection<T> ToObservable<TBefore, T>(this IEnumerable<TBefore> enumerable, Func<TBefore, T> convert)
        {
            return new ObservableCollection<T>(enumerable
                .Select(convert));
        }
    }
}