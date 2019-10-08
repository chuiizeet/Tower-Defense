using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TowerNode : MonoBehaviour
{
    // TODO: Tower Selection UI

    private GameObject placedTower;

    public GameObject PlacedTower
    {
        get {
            return placedTower;
        }
    }

    private void Awake()
    {
        // TODO: Assert -- Tower Selection UI != null
    }

    private void Start()
    {
        
    }

    private void ToggleSelectionUI()
    {

    }

    private void OnTowerPurchased(object sender, EventArgTemplate<TowerConfiguration> purchasedTower)
    {
        if (placedTower != null)
        {
            Destroy(placedTower);
        }
        var prefab = purchasedTower.Attachment.TowerPrefab;
        placedTower = Instantiate(prefab);
        placedTower.transform.parent = transform;
        placedTower.transform.localPosition = new Vector2(0,0);
        OnCloseRequested();
    }

    public void OnCloseRequested()
    {

    }

    public void OnNodeSelected()
    {
       ToggleSelectionUI();
    }
}
