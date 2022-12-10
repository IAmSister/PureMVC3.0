using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifier : INotifier
{
    private IFacade m_facade = Facade.Instance;
    public void SendNotification(string notificationName)
    {
        this.m_facade.SendNotification(notificationName);
    }

    public void SendNotification(string notificationName, object body)
    {
        this.m_facade.SendNotification(notificationName, body);
    }

    public void SendNotification(string notificationName, object body, string type)
    {
        this.m_facade.SendNotification(notificationName, body, type);
    }
    protected IFacade Facades
    {
        get
        {
            return this.m_facade;
        }
    }
}
