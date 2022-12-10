using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMediator : Mediator
{
    private RoomProxy roomProxy = null;
    public new const string NAME = "RoomMediator";
    public RoomView RoomView
    {
        get
        {
            return (RoomView)ViewComponent;
        }
    }
    public RoomMediator(RoomView view) : base(NAME, view)
    {

    }
    public override void OnRegister()
    {
        base.OnRegister();
        roomProxy = Facades.RetrieveProxy(RoomProxy.NAME) as RoomProxy;
        if (null == roomProxy)
        {
            throw new Exception(CookProxy.NAME + "is null.");
        }
        IList<Action<object>> actionList = new List<Action<object>>()
        {
            (item)=>{ SendNotification(OrderCommandEvent.RoomCheckIn,item,"ClienLeave"); },
        };
        RoomView.UpdateRoom(roomProxy.Rooms, actionList);
    }
    public override IList<string> ListNotificationInterests()
    {
        IList<string> notifications = new List<string>();
        notifications.Add(OrderSystemEvent.ResfrshRoom);

        return notifications;
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case OrderSystemEvent.ResfrshRoom:
                {
                    RoomItem room = notification.Body as RoomItem;

                    //todo 分配一个厨师开始做菜
                    RoomView.ResfrshRoom(room);
                }
                break;
        }
    }
}
