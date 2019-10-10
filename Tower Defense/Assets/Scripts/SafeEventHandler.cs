using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class SafeEventHandler
{
    public static void SafelyBroadcastEvent<T>(ref EventHandler<EventArgTemplate<T>> eventToBradcast,
                                                T dataToattach, object sender)
    {
        if (eventToBradcast != null)
        {
            var attachment = new EventArgTemplate<T>(dataToattach);
            eventToBradcast.Invoke(sender, attachment);
        }
    }

    public static void SafelyBroadcastAction(ref Action actionToBroadcast)
    {
        if (actionToBroadcast != null)
        {
            actionToBroadcast.Invoke();
        }
    }
}