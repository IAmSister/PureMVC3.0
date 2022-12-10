using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestBeAwayCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
        ClientProxy clientProxy = Facades.RetrieveProxy(ClientProxy.NAME) as ClientProxy;
        if (notification.Type=="Add")
        {
            ClientItem client = notification.Body as ClientItem;
            client.state = 0;
            client.population = Random.Range(3, 14);
            clientProxy.AddClient(client);
        }
        else if (notification.Type=="Remove")
        {
            Debug.Log("客人走了");
            Debug.Log(notification.Body as ClientItem);
            clientProxy.DeleteClient(notification.Body as ClientItem);
        }
    }
}
