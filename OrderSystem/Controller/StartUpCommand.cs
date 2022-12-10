using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class StartUpCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        //菜单代理
        MenuProxy menuProxy = new MenuProxy();
        Facades.RegisterProxy(menuProxy);
        //客户端代理
        ClientProxy clientProxy = new ClientProxy();
        Facades.RegisterProxy(clientProxy);
        //服务员代理
        WaiterProxy waiterProxy = new WaiterProxy();
        Facades.RegisterProxy(waiterProxy);
        //厨师代理
        CookProxy cookProxy = new CookProxy();
        Facades.RegisterProxy(cookProxy);
        //房间代理
        RoomProxy roomProxy = new RoomProxy();
        Facades.RegisterProxy(roomProxy);

        OrderProxy orderProxy = new OrderProxy();
        Facades.RegisterProxy(orderProxy);

        MainUI mainUI=notification.Body as MainUI;
        if (null==mainUI)
        {
            throw new Exception("程序启动失败");
        }
        MenuMediator menuMediator = new MenuMediator(mainUI.MenuView);
        Facades.RegisterMediator(menuMediator);
        ClientMediator clientMediator = new ClientMediator(mainUI.ClientView);
        Facades.RegisterMediator(clientMediator);
        WaiterMediator waiterMediator = new WaiterMediator(mainUI.WaitView);
        Facades.RegisterMediator(waiterMediator);
        CookMediator cookMediator = new CookMediator(mainUI.CookView);
        Facades.RegisterMediator(cookMediator);
        RoomMediator roomMediator = new RoomMediator(mainUI.RoomView);
        Facades.RegisterMediator(roomMediator);

        Facades.RegisterCommand(OrderCommandEvent.GUEST_BE_AWAY,typeof(GuestBeAwayCommand));
        Facades.RegisterCommand(OrderCommandEvent.GET_ORDER, typeof(GetAndExitOrderCommand));
        Facades.RegisterCommand(OrderCommandEvent.CookCooking, typeof(CookCommand));
        Facades.RegisterCommand(OrderCommandEvent.selectWaiter, typeof(WaiterCommand));
        Facades.RegisterCommand(OrderCommandEvent.ChangeClientState, typeof(ClientChangeStateCommand));
        Facades.RegisterCommand(OrderCommandEvent.RoomCheckIn, typeof(RoomCommand));
    
    }
}
