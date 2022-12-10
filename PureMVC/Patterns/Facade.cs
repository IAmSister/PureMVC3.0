using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Facade : IFacade
{
    protected IController m_controller;
    protected static volatile IFacade m_instance;
    protected IModel m_model;
    protected static readonly object m_staticSyncRoot = new object();
    protected IView m_view;
    protected Facade()
    {
        this.InitializeFacade();
    }

    protected virtual void InitializeFacade()
    {
        this.InitializeModel();
        this.InitializeController();
        this.InitializeView();
    }
    protected virtual void InitializeModel()
    {
        if (this.m_model == null)
        {
            this.m_model = Model.Instance;
        }
    }
    protected virtual void InitializeController()
    {
        if (this.m_controller == null)
        {
            this.m_controller = Controller.Instance;
        }
    }

    protected virtual void InitializeView()
    {
        if (this.m_view == null)
        {
            this.m_view = View.Instance;
        }
    }
    //是否存在事件
    public bool HasCommand(string notificationName)
    {
        return this.m_controller.HasCommand(notificationName);
    }
    //是否存在中介者
    public bool HasMediator(string mediatorName)
    {
        return this.m_view.HasMediator(mediatorName);
    }
    //是否存在代理
    public bool HasProxy(string proxyName)
    {
        return this.m_model.HasProxy(proxyName);
    }
    //向观察者下发事件通知
    public void NotifyObservers(INotification note)
    {
        this.m_view.NotifyObservers(note);
    }
    //注册事件
    public void RegisterCommand(string notificationName, Type commandType)
    {
        this.m_controller.RegisterCommand(notificationName, commandType);
    }
    //注册中介者
    public void RegisterMediator(IMediator mediator)
    {
        this.m_view.RegisterMediator(mediator);
    }
    //注册代理
    public void RegisterProxy(IProxy proxy)
    {
        this.m_model.RegisterProxy(proxy);
    }
    //移除事件
    public void RemoveCommand(string notificationName)
    {
        this.m_controller.RemoveCommand(notificationName);
    }
    //移除中介者
    public IMediator RemoveMediator(string mediatorName)
    {
        return this.m_view.RemoveMediator(mediatorName);
    }
    //移除代理
    public IProxy RemoveProxy(string proxyName)
    {
        return this.m_model.RemoveProxy(proxyName);
    }
    //回复中介者
    public IMediator RetrieveMediator(string mediatorName)
    {
        return this.m_view.RetrieveMediator(mediatorName);
    }
    //回复代理
    public IProxy RetrieveProxy(string proxyName)
    {
        return this.m_model.RetrieveProxy(proxyName);
    }

    public void SendNotification(string notificationName)
    {
        this.NotifyObservers(new Notification(notificationName));
    }

    public void SendNotification(string notificationName, object body)
    {
        this.NotifyObservers(new Notification(notificationName, body));
    }

    public void SendNotification(string notificationName, object body, string type)
    {
        this.NotifyObservers(new Notification(notificationName, body, type));
    }
    public static IFacade Instance
    {
        get
        {
            if (m_instance == null)
            {
                lock (m_staticSyncRoot)
                {
                    if (m_instance == null)
                    {
                        m_instance = new Facade();
                    }
                }
            }
            return m_instance;
        }
    }
}
