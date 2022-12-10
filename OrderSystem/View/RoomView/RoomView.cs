using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomView : MonoBehaviour
{
    private ObjectPool<RoomItemView> objectPool = null;
    private List<RoomItemView> rooms = new List<RoomItemView>();
    private Transform parent = null;
    private void Awake()
    {
       
        parent = this.transform.Find("Content");
        var prefab = Resources.Load<GameObject>("RoomItem");
        objectPool = new ObjectPool<RoomItemView>(prefab, "RoomPool");
    }
    public void UpdateRoom(IList<RoomItem> room, IList<Action<object>> actionList)
    {
        for (int i = 0; i < this.rooms.Count; i++)
        {
            objectPool.Push(this.rooms[i]);
        }
        this.rooms.AddRange(objectPool.Pop(room.Count));
        for (int i = 0; i < this.rooms.Count; i++)
        {
            var roomItem = this.rooms[i];
            roomItem.transform.SetParent(parent);
            roomItem.InitRoom(room[i], actionList);
        }
    }
    public void ResfrshRoom(RoomItem room)
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].ItemRoom.id.Equals(room.id))
            {
                rooms[i].InitRoom(room,null);
                return;
            }
        }
    }
}
