using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ClientView : MonoBehaviour
{
    public UnityAction<ClientItem> CallWaiter = null;
    public UnityAction<Order> Order = null;
    public UnityAction RoomIn = null;  
    public UnityAction Pay = null;

    private ObjectPool<ClientItemView> objectPool = null;
    private List<ClientItemView> clients = new List<ClientItemView>();
    private Transform parent = null;

    private void Awake()
    {
        parent = this.transform.Find("Content");
        var prefab = Resources.Load<GameObject>("ClientItem");
        objectPool=new ObjectPool<ClientItemView>(prefab, "ClientPool");
    }
    public void UpdateClient(IList<ClientItem> clients, IList<Action<object>> objs)
    {
        for (int i = 0; i < this.clients.Count; i++)
        {
            objectPool.Push(this.clients[i]);
        }
        this.clients.AddRange(objectPool.Pop(clients.Count));
        for (int i = 0; i < this.clients.Count; i++)
        {
            var client = this.clients[i];
            client.transform.SetParent(parent);
            client.InitClient(clients[i]);
            client.actionList = objs;
            client.GetComponent<Button>().onClick.RemoveAllListeners();
            client.GetComponent<Button>().onClick.AddListener(() => {
                if (client.client.state==0)
                {
                    CallWaiter(client.client);
                }
            });
        }
    }
    public void UpdateState(ClientItem client)
    {
        for (int i = 0; i < clients.Count; i++)
        {
            if (clients[i].client.id.Equals(client.id))
            {
                clients[i].InitClient(client);
                return;
            }
        }
    }

}
