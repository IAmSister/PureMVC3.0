using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class MenuView : MonoBehaviour
{
    public UnityAction<Order> Submit = null;
    public UnityAction Cancel = null;

    private ObjectPool<MenuItemView> objectPool = null;
    private List<MenuItemView> menus = new List<MenuItemView>();
    private Transform parent = null;
    private void Awake()
    {
        parent = this.transform.Find("Content");
        var prefab = Resources.Load<GameObject>("MenuItem");
        objectPool = new ObjectPool<MenuItemView>(prefab, "MenuPool");
        transform.Find("SubmitButton").GetComponent<Button>().onClick.AddListener(() =>
        {
            Submit(indexOrder);
        });
        transform.Find("CancelButton").GetComponent<Button>().onClick.AddListener(() => { CancelMenu(); });
    }

    private void CancelMenu()
    {
        this.transform.localPosition = new Vector3(0, -800, 0);
    }

    private Order indexOrder = null;

    public void UpdateMenu(IList<MenuItem> menus)
    {
        for (int i = 0; i < this.menus.Count; i++)
        {
            objectPool.Push(this.menus[i]);
        }
        this.menus.AddRange(objectPool.Pop(menus.Count));
        for (int i = 0; i < this.menus.Count; i++)
        {
            this.menus[i].transform.SetParent(parent);
            var item = this.menus[i];
            item.InitData(menus[i]);
        }
    }
    public void UpMenu(Order order)
    {
        ResetMenu();
        indexOrder = order;
        this.transform.localPosition = new Vector3(0, 0, 0);
    }
    public void SubmitMenu(Order order)
    {
        order.menus = GetSelected();
        CancelMenu();
    }
    public IList<MenuItem> GetSelected()
    {
        IList<MenuItem> relt= new List<MenuItem>();
        for (int i = 0; i < menus.Count; i++)
        {
            if (menus[i].Menu.iselected)
            {
                relt.Add(menus[i].Menu);
            }
        }
        return relt;
    }
    public void ResetMenu()
    {
        foreach (var item in menus)
        {
            item.toggle.isOn = false;
        }
    }

}
