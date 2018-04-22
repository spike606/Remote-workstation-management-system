using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SystemManagament.Client.WPF.Extensions
{
    public class ExtendedObservableCollection<T> : ObservableCollection<T>
    {
        private bool suppressCollectionChnagedEvent;

        public override event NotifyCollectionChangedEventHandler CollectionChanged;

        public void ClearAllItems()
        {
            suppressCollectionChnagedEvent = true;

            this.Clear();

            suppressCollectionChnagedEvent = false;
            NotifyCollectionChangedEventArgs obEvtArgs = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, this);
            this.OnCollectionChangedMultipleItems(obEvtArgs);
        }
        public void RefreshRange(IList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            suppressCollectionChnagedEvent = true;
            this.Clear();

            foreach (T item in list)
            {
                this.Add(item);
            }

            suppressCollectionChnagedEvent = false;

            NotifyCollectionChangedEventArgs obEvtArgs = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,
                list as System.Collections.IList);

            OnCollectionChangedMultipleItems(obEvtArgs);
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!suppressCollectionChnagedEvent)
                base.OnCollectionChanged(e);
        }

        private void OnCollectionChangedMultipleItems(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler handlers = CollectionChanged;
            if (handlers != null)
            {
                foreach (NotifyCollectionChangedEventHandler handler in handlers.GetInvocationList())
                {
                    if (handler.Target is CollectionView)
                        ((CollectionView)handler.Target).Refresh();
                    else
                        handler(this, e);
                }
            }
        }
    }
}
