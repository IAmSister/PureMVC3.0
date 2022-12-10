using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomType
{
    None,
    Checkin,
}
public class RoomItem : MonoBehaviour
{
    public int id { get; set; }
    public string name { get; set; }
    public int sum { get; set; }
    public RoomType roomtype { get; set; }
    public RoomItem(int id, string name, int sum, RoomType roomtype = RoomType.None)
    {
        this.id = id;
        this.roomtype = roomtype;
        this.name = name;
        this.sum = sum;
    }
    public override string ToString()
    {
        return id + "号房间\n" + name + "\n" + sum.ToString() + "人" + "\n" + resultRoomType();
    }
    public string resultRoomType()
    {
        if (roomtype.Equals(RoomType.None))
        {
            return "房间是空房";
        }
        return "房间有人居住";
    }
}
