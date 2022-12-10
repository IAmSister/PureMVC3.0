using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : IView
{
    protected static volatile IView m_instance;
    protected IDictionary<string, IMediator> m_mediateorMap = new Dictionary<string, IMediator>();
    protected IDictionary<string, List<IObserver>> m_observerMap = new Dictionary<string, List<IObserver>>();
    protected static readonly object m_staticSyncRoot = new object();
    protected readonly object m_syncRoot = new object();

    protected View()
    {
        this.InitializeView();
    }
    protected virtual void InitializeView()
    {

    }
    public bool HasMediator(string mediatorName)
    {
        throw new System.NotImplementedException();
    }

    public void NotifyObservers(INotification note)
    {
        IList<IObserver> list = null;
        lock (this.m_syncRoot)
        {
            if (this.m_observerMap.ContainsKey(note.Name))
            {
                IList<IObserver> collection = this.m_observerMap[note.Name];
                list = new List<IObserver>(collection);
            }
        }
        if (list!=null)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].NotifyObserver(note);
            }
        }
    }

    public void RegisterMediator(IMediator mediator)
    {
        lock (this.m_syncRoot)
        {
            if (this.m_mediateorMap.ContainsKey(mediator.MediatorName))
            {
                return;
            }
            this.m_mediateorMap[mediator.MediatorName] = mediator;
            IList<string> list = mediator.ListNotificationInterests();
            if (list.Count>0)
            {
                IObserver observer=new Observer("handleNotification",mediator);
                for (int i = 0; i < list.Count; i++)
                {
                    this.RegisterObserver(list[i].ToString(),observer);
                }
            }
            mediator.OnRegister();
        }
    }

    public void RegisterObserver(string notificationName, IObserver observer)
    {
        lock (this.m_syncRoot)
        {
            if (!this.m_observerMap.ContainsKey(notificationName))
            {
                this.m_observerMap[notificationName] = new List<IObserver>();
            }
            if (!this.m_observerMap[notificationName].Contains(observer))
            {
                this.m_observerMap[notificationName].Add(observer);
            }
        }
    }

    public IMediator RemoveMediator(string mediatorName)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveObserver(string notificationName, object notifyContext)
    {
        throw new System.NotImplementedException();
    }

    public IMediator RetrieveMediator(string mediatorName)
    {
        throw new System.NotImplementedException();
    }
    public static IView Instance
    {
        get
        {
            if (m_instance == null)
            {
                lock (m_staticSyncRoot)
                {
                    if (m_instance == null)
                    {
                        m_instance = new View();
                    }
                }
            }
            return m_instance;
        }
    }
}
