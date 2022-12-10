using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mediator : Notifier, IMediator
{
    protected string m_meditatorName;
    protected object m_viewComponent;
    public const string NAME = "Mediator";
    public Mediator():this("Mediator", null)
    {

    }
    public Mediator(string mediatorName):this(mediatorName,null)
    {
        
    }
    public Mediator(string meditatorName, object viewComponent)
    {
        this.m_meditatorName = (meditatorName != null) ? meditatorName : "Mediator";
        this.m_viewComponent = viewComponent;

    }

    public virtual void HandleNotification(INotification notification)
    {
        
    }

    public virtual IList<string> ListNotificationInterests()
    {
        return new List<string>();
    }

    public virtual void OnRegister()
    {
        
    }

    public virtual void OnRemove()
    {
        throw new System.NotImplementedException();
    }
    public virtual string MediatorName
    {
        get
        {
            return this.m_meditatorName;
        }
    }
    public object ViewComponent
    {
        get
        {
            return this.m_viewComponent;
        }
        set
        {
            this.m_viewComponent = value;
        }
    }
}
