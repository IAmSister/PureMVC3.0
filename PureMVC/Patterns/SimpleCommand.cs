
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

public class SimpleCommand : Notifier,ICommand,INotifier
{
    public virtual void Execute(INotification notification)
    {

    }
}
