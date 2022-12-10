using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItemView : MonoBehaviour
{
    private Text text = null;
    private Image image = null;
    public RoomItem ItemRoom = null;
    public IList<Action<object>> actionList = null;
    public void Awake()
    {
        text = transform.Find("Id").transform.GetComponent<Text>();
        image = transform.GetComponent<Image>();
    }
    public void InitRoom(RoomItem roomItem, IList<Action<object>> actionList)
    {
        if (this.actionList==null)
        {
            this.actionList = actionList;
        }
        ItemRoom = roomItem;
        Debug.Log(ItemRoom.id);

        if (ItemRoom == null)
        {
            Debug.Log(ItemRoom.id);
            Color color = Color.white;
            switch (ItemRoom.roomtype)
            {
                case RoomType.Checkin:
                    color = Color.red;
                    StartCoroutine(Leave());
                    break;
            }
            image.color = color;
            text.text = roomItem.ToString();

        }
    }
    private IEnumerator Leave(float time=4)
    {
        yield return new WaitForSeconds(time);
        actionList[0].Invoke(ItemRoom);
    }
}
