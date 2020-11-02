using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace App1.Utils
{
    public class RangeObservableCollection<T> : ObservableCollection<T>
    {
        public void AddRange(IEnumerable<T> enumerable)
        {
            CheckReentrancy();

            var startIndex = Count;

            var collection = enumerable.ToList();
            foreach (var item in collection)
                Items.Add(item);

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,
                new List<T>(collection), startIndex));
            OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
        }
    }
}