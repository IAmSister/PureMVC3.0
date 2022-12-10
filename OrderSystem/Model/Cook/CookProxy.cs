using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookProxy : Proxy
{
    public new const string NAME = "CookProxy";
    public Queue<Order> orders = new Queue<Order>();
    public IList<CookItem> Cooks
    {
        get
        {
            return (IList<CookItem>)base.Data;
        }
    }
    public CookProxy() : base(NAME, new List<CookItem>())
    {

    }
    public override void OnRegister()
    {
        base.OnRegister();
        AddCook(new CookItem(1, "AA", 0));
        AddCook(new CookItem(2, "BB"));
        AddCook(new CookItem(3, "CC", 0));
        AddCook(new CookItem(4, "DD"));
    }
    public void AddCook(CookItem item)
    {
        Cooks.Add(item);
    }
    public void RemoveCook(CookItem item)
    {
        Cooks.Remove(item);
    }
    public void GetOrder()
    {
        if (orders.Count>=1)
        {
            Order order= orders.Dequeue();
            for (int i = 0; i < Cooks.Count; i++)
            {
                if (Cooks[i].state == 0)
                {
                    Cooks[i].state++;
                    Cooks[i].cooking = order.names;
                    Cooks[i].cookOrder = order;
                    Debug.Log(order.names);
                    SendNotification(OrderSystemEvent.ResfrshCook);
                    return;
                }
            }
        }
    }
    public void CookCooking(Order order)
    {
        for (int i = 0; i < Cooks.Count; i++)
        {
            if (Cooks[i].state==0)
            {
                Cooks[i].state++;
                Cooks[i].cooking = order.names;
                Cooks[i].cookOrder = order;
                Debug.Log(order.names);
                SendNotification(OrderSystemEvent.ResfrshCook);
                return;
            }
        }
        orders.Enqueue(order);
    }
}
