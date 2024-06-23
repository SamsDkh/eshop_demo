using eShop.UseCases.PluginInterfaces.StateStore;

namespace eShop.StateStore.DI
{
    public class StateStoreBase : IStateStore
    {
        protected Action listeners;

        public void AddStateChangeListeners(Action Listener) => this.listeners += listeners;
        public void RemoveStateChangeListeners(Action Listener) => this.listeners -= listeners;

        public void BroadCastStateChange()
        {
            listeners?.Invoke();
        }

    }
}
