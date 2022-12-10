using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Observer : IObserver
{
    private object m_notifyContext;
    private string m_notifyMethod;
    protected readonly object m_syncRoot = new object();
    public Observer(string notifyMethod, object notifyContext)
    {
        this.m_notifyMethod = notifyMethod;
        this.m_notifyContext = notifyContext;
    }

    public bool CompareNotifyContext(object obj)
    {
        throw new System.NotImplementedException();
    }

    public object NotifyContext
    {
        private get
        {
            return this.m_notifyContext;
        }
        set
        {
            this.m_notifyContext = value;
        }
    }
    public string NotifyMethod
    {
        private get
        {
            return this.m_notifyMethod;
        }
        set
        {
            this.m_notifyMethod = value;
        }
    }
    public void NotifyObserver(INotification notification)
    {
        object notifyContext;
        lock (this.m_syncRoot)
        {
            notifyContext = this.NotifyContext;
        }
        //利用反射获取方法
        Type type = notifyContext.GetType();
        //设置忽略大小写等
        BindingFlags binding=BindingFlags.Public| BindingFlags.Instance | BindingFlags.IgnoreCase;
        //根据设置的中介的名字，找他对应的方法
        MethodInfo method = type.GetMethod(this.NotifyMethod,binding);
        method.Invoke(notifyContext, new object[] { notification });

    }

}
