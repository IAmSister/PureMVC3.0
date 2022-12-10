using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMediator : Mediator
{
    private MenuProxy menuProxy = null;
    public new const string NAME = "MenuMediator";
    public MenuView MenuView
    {
        get
        {
            return (MenuView)ViewComponent;
        }
    }
    public MenuMediator(MenuView view) : base(NAME, view)
    {
        MenuView.Submit += (order) => { SendNotification(OrderSystemEvent.SUBMITMENU, order); };
        MenuView.Cancel += () => { SendNotification(OrderSystemEvent.CANCEL_ORDER); };
    }

    public override void OnRegister()
    {
        base.OnRegister();
        menuProxy = Facades.RetrieveProxy(MenuProxy.NAME) as MenuProxy; ;
        if (menuProxy == null)
        {
            throw new Exception(MenuProxy.NAME + "is null!");
        }
        MenuView.UpdateMenu(menuProxy.Menus);
    }
    public override IList<string> ListNotificationInterests()
    {
        IList<string> notifications=new List<string>();
        notifications.Add(OrderSystemEvent.UPMENU);
        notifications.Add(OrderSystemEvent.CANCEL_ORDER);
        notifications.Add(OrderSystemEvent.SUBMITMENU);
        return notifications;
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case OrderSystemEvent.UPMENU:
                {
                    Order order=notification.Body as Order;
                    if (order==null)
                    {
                        throw new Exception("order is null ,plase check it!");
                    }
                    MenuView.UpMenu(order);
                }
                break;
            case OrderSystemEvent.SUBMITMENU:
                {
                    Order order = notification.Body as Order;
                    MenuView.SubmitMenu(order);
                    SendNotification(OrderSystemEvent.ORDER, order);
                }
                break;
            default:
                break;
        }
    }
}
