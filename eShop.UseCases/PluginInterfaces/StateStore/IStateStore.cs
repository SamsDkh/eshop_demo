using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.PluginInterfaces.StateStore
{
    public interface IStateStore
    {
        void AddStateChangeListeners(Action Listener);
        void RemoveStateChangeListeners(Action Listener);
        void BroadCastStateChange();
    }
}
