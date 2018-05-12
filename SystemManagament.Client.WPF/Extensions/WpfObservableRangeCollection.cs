using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Client.WPF.Extensions
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Data;
    using System.Windows.Threading;

    public class WpfObservableRangeCollection<T> : ObservableRangeCollection<T>
    {
        private DeferredEventsCollection deferredEvents;

        public WpfObservableRangeCollection()
        {
        }

        public WpfObservableRangeCollection(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public WpfObservableRangeCollection(List<T> list)
            : base(list)
        {
        }

        /// <summary>
        /// Raise CollectionChanged event to any listeners.
        /// Properties/methods modifying this ObservableCollection will raise
        /// a collection changed event through this virtual method.
        /// </summary>
        /// <remarks>
        /// When overriding this method, either call its base implementation
        /// or call <see cref="BlockReentrancy"/> to guard against reentrant collection changes.
        /// </remarks>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            var deferredEvents = (ICollection<NotifyCollectionChangedEventArgs>)typeof(ObservableRangeCollection<T>).GetField("_deferredEvents", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this);
            if (deferredEvents != null)
            {
                deferredEvents.Add(e);
                return;
            }

            var handlers = this.GetHandlers();
            foreach (var handler in this.GetHandlers())
            {
                if (this.IsRange(e) && handler.Target is CollectionView cv)
                {
                    App.Current.Dispatcher.BeginInvoke(DispatcherPriority.DataBind, (Action)(() => cv.Refresh()));
                }
                else
                {
                    App.Current.Dispatcher.BeginInvoke(DispatcherPriority.DataBind, (Action)(() => handler(this, e)));
                }
            }
        }

        protected override IDisposable DeferEvents() => new DeferredEventsCollection(this);

        private bool IsRange(NotifyCollectionChangedEventArgs e) => e.NewItems?.Count > 1 || e.OldItems?.Count > 1;

        private IEnumerable<NotifyCollectionChangedEventHandler> GetHandlers()
        {
            var info = typeof(ObservableCollection<T>).GetField(nameof(this.CollectionChanged), BindingFlags.Instance | BindingFlags.NonPublic);
            var @event = (MulticastDelegate)info.GetValue(this);
            return @event?.GetInvocationList()
              .Cast<NotifyCollectionChangedEventHandler>()
              .Distinct()
              ?? Enumerable.Empty<NotifyCollectionChangedEventHandler>();
        }

        private class DeferredEventsCollection : List<NotifyCollectionChangedEventArgs>, IDisposable
        {
            private readonly WpfObservableRangeCollection<T> collection;

            public DeferredEventsCollection(WpfObservableRangeCollection<T> collection)
            {
                this.collection = collection;
                this.collection.deferredEvents = this;
            }

            public void Dispose()
            {
                this.collection.deferredEvents = null;

                var handlers = this.collection
                  .GetHandlers()
                  .ToLookup(h => h.Target is CollectionView);

                foreach (var handler in handlers[false])
                {
                    foreach (var e in this)
                    {
                        App.Current.Dispatcher.BeginInvoke(DispatcherPriority.DataBind, (Action)(() => handler(this, e)));
                    }
                }

                foreach (var cv in handlers[true]
                  .Select(h => h.Target)
                  .Cast<CollectionView>()
                  .Distinct())
                {
                    App.Current.Dispatcher.BeginInvoke(DispatcherPriority.DataBind, (Action)(() => cv.Refresh()));
                }
            }
        }
    }
}
