﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TowerPurchaseButtonController : MonoBehaviour
{
    [SerializeField] private TowerConfiguration tower;
    [SerializeField] private Image towerPlacementImage;
    [SerializeField] private TMP_Text priceText;

    public event EventHandler<EventArgTemplate<TowerConfiguration>> TowerPurchased;

    private void Start() {
        towerPlacementImage.sprite = tower.TowerImage;
        priceText.text = tower.Price.ToString();
    }

    public void onTowerSelected()
    {
        SafeEventHandler.SafelyBroadcastEvent(ref TowerPurchased, tower, this);
    }
}
