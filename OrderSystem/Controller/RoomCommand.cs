using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        RoomProxy roomProxy = Facades.RetrieveProxy(RoomProxy.NAME) as RoomProxy; ;
        if (notification.Type == "Checkin")
        {
            ClientItem item = notification.Body as ClientItem;
            roomProxy.RoomCheck(item);
        }
        if (notification.Type == "ClienLeave")
        {
            RoomItem item = notification.Body as RoomItem;
            roomProxy.LeaveClient(item);
        }
    }
}
