using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CookItem
{
    public int id { get; set; }
    public string name { get; set; }
    public int state { get; set; }
    public string cooking { get; set; }
    public Order cookOrder { get; set; }
    public CookItem(int id, string name, int state = 0, string cooking = "", Order cookOrder = null)
    {
        this.id = id;
        this.name = name;
        this.state = state;
        this.cooking = cooking;
        this.cookOrder = cookOrder;
    }
    public override string ToString()
    {
        return id + "号厨师\n" + name + "\n" + resultState();
    }
    public string resultState()
    {
        if (state.Equals(0))
        {
            return "休息中";
        }
        return "忙碌中";
    }
}
