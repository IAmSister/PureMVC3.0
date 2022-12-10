using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CookCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        CookProxy cookProxy=Facades.RetrieveProxy(CookProxy.NAME) as CookProxy; ;
        if (notification.Type== "Cooking")
        {
            Order order = notification.Body as Order;
            cookProxy.CookCooking(order);

        }
        else if (notification.Type == "Again")
        {
            cookProxy.GetOrder();
        }
    }
}
