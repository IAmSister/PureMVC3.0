using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum E_WaiterState
{
    Idle,
    Busy
}
public class WaiterItem
{
    public int id { get; set; }
    public string name { get; set; }
    public int state { get; set; }
    public Order order { get; set; }
    public WaiterItem(int id, string name, int state = 0, Order order = null)
    {
        this.id = id;
        this.name = name;
        this.state = state;
        this.order = order;
    }
    public override string ToString()
    {
        return id + "号服务员\n" + name + "\n" + resultState();
    }
    private string resultState()
    {
        if (state.Equals(0))
        {
            return "休息中";
        }
        return "忙碌中";
    }
}