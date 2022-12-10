
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItem
{
    public int id { get; set; }
    public string name { get; set; }
    public float price { get; set; }
    public bool instock { get; set; }//是否有货
    public bool iselected { get; set; }

    public MenuItem(int id, string name, float price, bool instock)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.instock = instock;
        iselected = false;
    }
    public override string ToString()
    {
        return id + ":" + name + ":" + price + ":" + instock;
    }
}
