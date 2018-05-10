using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Threading;

namespace SystemManagament.Client.WPF.Extensions
{
    public class ExtendedObservableCollection<T> : ObservableCollection<T>
    {
        private bool suppressCollectionChnagedEvent;

        public override event NotifyCollectionChangedEventHandler CollectionChanged;

        public void ClearAllItems()
        {
            this.suppressCollectionChnagedEvent = true;

            this.Clear();

            this.suppressCollectionChnagedEvent = false;
            NotifyCollectionChangedEventArgs obEvtArgs = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, this);
            this.OnCollectionChangedMultipleItems(obEvtArgs);
        }

        public void RefreshRange(IList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return;
            }

            this.suppressCollectionChnagedEvent = true;
            this.Clear();

            foreach (T item in list)
            {
                this.Add(item);
            }

            this.suppressCollectionChnagedEvent = false;

            NotifyCollectionChangedEventArgs obEvtArgs = new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Add,
                list as System.Collections.IList);
            this.OnCollectionChangedMultipleItems(obEvtArgs);
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!this.suppressCollectionChnagedEvent)
            {
                base.OnCollectionChanged(e);
            }
        }

        private void OnCollectionChangedMultipleItems(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler handlers = this.CollectionChanged;
            if (handlers != null)
            {
                foreach (NotifyCollectionChangedEventHandler handler in handlers.GetInvocationList())
                {
                    if (handler.Target is CollectionView)
                    {
                        // Use dispatcher because currently running method won't be executed on the UI thread
                        App.Current.Dispatcher.BeginInvoke(DispatcherPriority.DataBind, (Action)(() => { ((CollectionView)handler.Target).Refresh(); }));
                    }
                    else
                    {
                        handler(this, e);
                    }
                }
            }
        }
    }
}
