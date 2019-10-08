﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerNodeUIController : MonoBehaviour
{
    public event EventHandler<EventArgTemplate<TowerConfiguration>> PurchasedTower;
    public event Action CloseButtonPressed;

    private void OnTowerPurchased(object sender, EventArgTemplate<TowerConfiguration> purchasedTower)
    {
        SafelyBroadcastEvent<TowerConfiguration>(ref PurchasedTower, purchasedTower.Attachment);
    }

    private void SafelyBroadcastEvent<T>(ref EventHandler<EventArgTemplate<T>> eventToBradcast, T dataToattach)
    {
        if (eventToBradcast != null)
        {
            var attachment = new EventArgTemplate<T>(dataToattach);
            eventToBradcast.Invoke(this, attachment);
        }
    }

    private void SafelyBroadcastAction(ref Action actionToBroadcast)
    {
        if (actionToBroadcast != null)
        {
            actionToBroadcast.Invoke();
        }
    }

    public void OnCloseSelected()
    {
        SafelyBroadcastAction(ref CloseButtonPressed);
    }
}
