using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AutoTargeting : MonoBehaviour
{
    [SerializeField] private List<string> targetTags = new List<string>();
    [SerializeField] private List<TargetType> targetableTypes = new List<TargetType>();

    private Targetable Target { get; private set; }
    private List<Targetable> targetsInRange = new List<Targetable>();

    public event Action TargetLost;
    public event EventHandler<EventArgTemplate<GameObject>> TargetAcquired;

    private void OnTriggerEnter2D(Collider2D other) {
        if (IsValidTarget(other)) {

        }
    }
    private bool IsValidTarget(Collider2D other) {
        var isValidTag = targetTags.Contains(other.tag);
        var isValidType = false;

        var targetable = other.gameObject.GetComponent<Targetable>();
        if (targetable != null) {
            var otherTypes = targetable.Types;
            foreach (var type in otherTypes) {
                if (targetableTypes.Contains(type)) {
                    isValidType = true;
                    break;
                }
            }
        }

        return isValidType && isValidType;
    }
}
