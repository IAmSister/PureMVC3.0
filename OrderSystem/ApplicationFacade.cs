using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationFacade : Facade
{
    public new static IFacade Instance
    {
        get
        {
            if (m_instance==null)
            {
                lock (m_staticSyncRoot)
                {
                    if (m_instance==null)
                    {
                        Debug.Log("构造Facade,此处会自动构造View、Controller和Model");
                        m_instance = new ApplicationFacade();
                    }
                }
            }
            return m_instance;
        }
    }

    public void StartUp(MainUI mainUI)
    {
        SendNotification(OrderSystemEvent.STARTUP, mainUI);
    }
    protected override void InitializeFacade()
    {
        base.InitializeFacade();
    }
    protected override void InitializeModel()
    {
        base.InitializeModel();
    }
    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(OrderSystemEvent.STARTUP, typeof(StartUpCommand));
    }
    protected override void InitializeView()
    {
        base.InitializeView();
    }
}
