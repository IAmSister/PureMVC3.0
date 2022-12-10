using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : IModel
{
    protected static volatile IModel m_instance;
    protected IDictionary<string, IProxy> m_proxyMap = new Dictionary<string, IProxy>();
    protected static readonly object m_staticSyncRoot = new object();
    protected readonly object m_syncRoot = new object();
    
    protected Model()
    {
        this.InitializeModel();
    }

    protected virtual void InitializeModel()
    {
        
    }
    //是否存在代理
    public bool HasProxy(string proxyName)
    {
        throw new System.NotImplementedException();
    }
    //注册代理
    public void RegisterProxy(IProxy proxy)
    {
        lock (this.m_syncRoot)
        {
            this.m_proxyMap[proxy.ProxyName] = proxy;
        }
        proxy.OnRegister();
    }
    //移除代理
    public IProxy RemoveProxy(string proxyName)
    {
        IProxy proxy = null;
        lock (this.m_syncRoot)
        {
            if (this.m_proxyMap.ContainsKey(proxyName))
            {
                proxy = this.RetrieveProxy(proxyName);
                this.m_proxyMap.Remove(proxyName);
            }
        }
        if (proxy!=null)
        {
            proxy.OnRemove();
        }
        return proxy;
    }
    //回复代理
    public IProxy RetrieveProxy(string proxyName)
    {
        lock (this.m_syncRoot)
        {
            if (!this.m_proxyMap.ContainsKey(proxyName))
            {
                return null;
            }
            return this.m_proxyMap[proxyName];
        }

    }
    public static IModel Instance
    {
        get
        {
            if (m_instance==null)
            {
                lock (m_staticSyncRoot)
                {
                    if (m_instance==null)
                    {
                        m_instance = new Model();
                    }
                }
            }
            return m_instance;
        }
    }
}
