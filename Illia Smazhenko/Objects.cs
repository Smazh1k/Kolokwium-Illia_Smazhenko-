using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Zadanie 1,2,3
namespace Illia_Smazhenko
{
    public class Objects<T> where T : IComparable<T>
    {
        public event EventHandler<ItemAddedEventArgs<T>> ItemAdded;

       
        private readonly List<T> items;
        public Objects()
        {
            items = new List<T>();
        }
        
        public void Add(T newItem)
        {
            items.Add(newItem);

            
            OnItemAdded(newItem);
        }

        public void Delete(T item)
        {
            items.Remove(item);
        }
        protected virtual void OnItemAdded(T newItem)
        {
            if (ItemAdded != null)
            { 
                ItemAdded(this, new ItemAddedEventArgs<T>(newItem));
            }
        }
        public IEnumerable<T> Items => items;
        public IEnumerable<T> GetSortedItems()
        {
            
            if (typeof(T) == typeof(int))   
            {
                var comparer = Comparer<T>.Default;
                return items.OrderByDescending(x => x, comparer);
            }
            else
            {
                return items.OrderBy(x => x);
            }
        }
        public IEnumerable<T> GetFilteredItems(Func<T, bool> filter)
        {
            return items.Where(filter);
        }
    }

   
    public class ItemAddedEventArgs<T> : EventArgs
    {
        public T AddedItem { get; }

        public ItemAddedEventArgs(T addedItem)
        {
            AddedItem = addedItem;
        }
    }
}
