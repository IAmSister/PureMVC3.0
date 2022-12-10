using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAndExitOrderCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        OrderProxy orderProxy=Facades.RetrieveProxy("OrderProxy") as OrderProxy; ;
        MenuProxy menuProxy=Facades.RetrieveProxy("MenuProxy") as MenuProxy; ;
        if (notification.Type=="Get")
        {
            Order order = new Order(notification.Body as ClientItem, menuProxy.Menus); ;
            orderProxy.AddOrder(order);
            SendNotification(OrderSystemEvent.UPMENU, order);
        }
        else if (notification.Type=="Exit")
        {
            Order order = new Order(notification.Body as ClientItem, menuProxy.Menus);
            orderProxy.RemoveOrder(order);
        }
    }
}
