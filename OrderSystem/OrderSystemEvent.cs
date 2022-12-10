using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSystemEvent
{
    /// <summary>
    /// 启动
    /// </summary>
    public const string STARTUP = "StartUp";
    /// <summary>
    /// 点菜
    /// </summary>
    public const string ORDER = "Order";
    /// <summary>
    /// 取消点餐
    /// </summary>
    public const string CANCEL_ORDER = "CancelOrder";
    /// <summary>
    /// 呼叫服务员
    /// </summary>
    public const string CALL_WAITER = "CallWaiter";
    /// <summary>
    /// 结账
    /// </summary>
    public const string PAY = "Pay";
    /// <summary>
    /// 服务员接收付款
    /// </summary>
    public const string GET_PAY = "GetPay";
    /// <summary>
    /// 通知厨师
    /// </summary>
    public const string CALL_COOK = "CallCook";
    /// <summary>
    /// 上菜
    /// </summary>
    public const string SERVER_FOOD = "ServerFood";
    /// <summary>
    /// 上菜单
    /// </summary>
    public const string UPMENU = "UpMenu";
    /// <summary>
    /// 提交菜单
    /// </summary>
    public const string SUBMITMENU = "SubmitMenu";
    /// <summary>
    /// 服务员上菜
    /// </summary>
    public const string FOOD_TO_CLIENT = "FoodToClient";
    /// <summary>
    /// 来客人了刷新
    /// </summary>
    public const string REFRESH = "refresh";
    /// <summary>
    /// 刷新服务员的信息
    /// </summary>
    public const string ResfrshWarite = "resfrshWarite";
    /// <summary>
    /// 刷新厨师
    /// </summary>
    public const string ResfrshCook = "resfrshcook";
    /// <summary>
    /// 刷新房间
    /// </summary>
    public const string ResfrshRoom = "resfrshroom";

}
public class OrderCommandEvent
{
    /// <summary>
    /// 客人走了
    /// </summary>
    public const string GUEST_BE_AWAY = "guest_be_away";
    /// <summary>
    /// 获取菜单
    /// </summary>
    public const string GET_ORDER = "get_order";
    /// <summary>
    /// 厨师做菜
    /// </summary>
    public const string CookCooking = "cookCooking";
    /// <summary>
    /// 选择空闲的服务员 上菜
    /// </summary>
    public const string selectWaiter = "selectWaiter";
    /// <summary>
    /// 改变客桌状态
    /// </summary>
    public const string ChangeClientState = "ChangeClientState";
    /// <summary>
    /// 客人住房
    /// </summary>
    public const string RoomCheckIn = "RoomCheckIn";
    /// <summary>
    /// 客人离开
    /// </summary>
    public const string ClienLeave = "ClienLeave";
}
