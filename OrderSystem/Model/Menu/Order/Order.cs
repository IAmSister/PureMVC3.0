using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Order
{
    public int id { get; set; }
    public ClientItem client { get; set; }
    public IList<MenuItem> menus { get; set; }
    public float pay
    {
        get
        {
            var money = 0.0f;
            foreach (MenuItem menu in menus)
            {
                money += menu.price;
            }
            return money;
        }
    }
    public string names
    {
        get
        {
            string name = "";
            foreach (MenuItem menu in menus)
            {
                name += menu.name + ",";
            }
            return name;
        }
    }
    public Order(ClientItem client, IList<MenuItem> menus)
    {
        this.client = client;
        this.menus = menus;
    }
    public override string ToString()
    {
        return client.id + "桌号" + client.population + "位顾客点餐" + menus.Count + "道,共消费" + pay + "元";
    }
}

