using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        WaiterProxy waiterProxy=Facades.RetrieveProxy(WaiterProxy.NAME) as  WaiterProxy; ;
        if (notification.Type=="SERVING")
        {
            Debug.Log("寻找服务员上菜");
            waiterProxy.ChangeWaiter(notification.Body as Order);
        }
        else if(notification.Type == "WANSHI")
        {
            Debug.Log("服务员没事干");
            waiterProxy.RemoveWaiter(notification.Body as WaiterItem);
        }
    }
}
