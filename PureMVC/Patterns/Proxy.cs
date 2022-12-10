
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proxy : Notifier, IProxy, INotifier
{
    protected object m_data;
    protected string m_proxyName;
    public static string NAME = "Proxy";

    public Proxy() : this(NAME, null)
    {

    }
    public Proxy(string prosyName) : this(prosyName, null)
    {

    }
    public Proxy(string prosyName, object data)
    {
        this.m_proxyName = (prosyName != null) ? prosyName : NAME;
        if (data != null)
        {
            this.m_data = data;
        }
    }
    public object Data
    {
        get
        {
            return this.m_data;
        }
        set
        {
            this.m_data = value;
        }
    }
    public string ProxyName
    {
        get
        {
            return this.m_proxyName;
        }
    }
    public virtual void OnRegister()
    {

    }

    public virtual void OnRemove()
    {

    }
}
