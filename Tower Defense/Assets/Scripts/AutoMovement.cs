using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class AutoMovement : MonoBehaviour
{
    [SerializeField] private NavigationNode startingNode;
    [SerializeField] private float speed = 1.0f;

    private NavigationNode targetNode;

    void Start()
    { 
        targetNode = startingNode;
    }

    void Update()
    {
        if (targetNode != null)
        {
            var currentPosition = transform.position;
            var targetPosition = targetNode.gameObject.transform.position;
            transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (targetNode == null) { return; }
        if (other.gameObject == targetNode.gameObject)
        {
            targetNode = targetNode.GetNextNode();
        }
    }

}