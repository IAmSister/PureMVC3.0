using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterProxy : Proxy
{
    public new const string NAME = "WaiterProxy";
    public IList<WaiterItem> Waiters
    {
        get
        {
            return (IList<WaiterItem>)base.Data;
        }
    }
    public WaiterProxy() : base(NAME, new List<WaiterItem>())
    {
        AddWaiter(new WaiterItem(1, "小a", 0));
        AddWaiter(new WaiterItem(2, "小b", 0));
        AddWaiter(new WaiterItem(3, "小c", 0));
    }
    public void AddWaiter(WaiterItem item)
    {
        Waiters.Add(item);
    }
    public void RemoveWaiter(WaiterItem item)
    {
        for (int i = 0; i < Waiters.Count; i++)
        {
            if (item.id == Waiters[i].id)
            {
                Waiters[i].state = 0;
                SendNotification(OrderSystemEvent.ResfrshWarite);
                return;
            }
        }
    }
    public void ChangeWaiter(Order order)
    {
        WaiterItem item = GetIdleWaiter();
        if (item != null)
        {
            item.state = 1;
            item.order = order;
            SendNotification(OrderSystemEvent.ResfrshWarite);
            SendNotification(OrderSystemEvent.FOOD_TO_CLIENT, item);
        }
    }
    public WaiterItem GetIdleWaiter()
    {
        foreach (WaiterItem waiter in Waiters)
        {
            if (waiter.state.Equals((int)E_WaiterState.Idle))
            {
                return waiter;
            }
        }
        return null;
    }
}
