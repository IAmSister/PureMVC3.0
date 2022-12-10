using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public interface IObserver 
{
    //对比NotifyContext
    bool CompareNotifyContext(object obj);
    //通知观察者
    void NotifyObserver(INotification notification);
    //记录是Mediator或Command
    object NotifyContext { set; }
    //通知方法
    string NotifyMethod { set; }
}
