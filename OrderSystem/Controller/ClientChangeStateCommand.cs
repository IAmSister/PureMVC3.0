using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientChangeStateCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);

        Order order = notification.Body as Order;
        ClientProxy clientProxy = Facades.RetrieveProxy(ClientProxy.NAME) as ClientProxy;
        switch (notification.Type)
        {
            case "WaitFood":
                clientProxy.ChangeClientState(order.client, ClientState.WaitFood);
                break;
            case "Eating":
                clientProxy.ChangeClientState(order.client, ClientState.Eating);
                break;
        }

    }
}
