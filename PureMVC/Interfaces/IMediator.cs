using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public interface IMediator 
{
    //处理通知
    void HandleNotification(INotification notification);
    //通知的名字
    IList<string> ListNotificationInterests();
    //注册
    void OnRegister();
    //移除
    void OnRemove();
    //名称
    string MediatorName { get; }
    //视图组件 这里是存的object类型
    object ViewComponent { get; set; }
}
