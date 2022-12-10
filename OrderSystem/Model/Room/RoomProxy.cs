using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomProxy : Proxy
{
    public new const string NAME = "RoomProxy";
    public IList<RoomItem> Rooms
    {
        get
        {
            return (IList<RoomItem>)base.Data;
        }
    }
    public RoomProxy() : base(NAME, new List<RoomItem>())
    {

    }
    public override void OnRegister()
    {
        base.OnRegister();
        AddRoom(new RoomItem(1, "华庭", 0));
        AddRoom(new RoomItem(2, "碧桂园", 0));
        AddRoom(new RoomItem(3, "川上", 0));
        AddRoom(new RoomItem(4, "桃花", 0));
        AddRoom(new RoomItem(5, "千石", 0));
    }
    public void AddRoom(RoomItem item)
    {
        Rooms.Add(item);
    }
    public void RemoveRoom(RoomItem item)
    {
        Rooms.Remove(item);
    }
    public void RoomCheck(ClientItem item)
    {
        for (int i = 0; i < Rooms.Count; i++)
        {
            if (Rooms[i].roomtype == 0)
            {
                Rooms[i].sum = item.population;
                Rooms[i].roomtype = RoomType.Checkin;
                SendNotification(OrderSystemEvent.ResfrshRoom, Rooms[i]);
                return;
            }
        }
    }
    public void LeaveClient(RoomItem item)
    {
        for (int i = 0; i < Rooms.Count; i++)
        {
            if (Rooms[i].id == item.id)
            {
                Rooms[i].roomtype = RoomType.None;
                Rooms[i].sum = 0;
                SendNotification(OrderSystemEvent.ResfrshRoom, Rooms[i]);
            }
            return;
        }
    }
}
