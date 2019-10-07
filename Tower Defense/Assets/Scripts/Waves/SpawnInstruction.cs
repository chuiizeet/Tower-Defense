using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SpawnInstruction
{
    [SerializeField] private NavigationNode startingNode;
    [SerializeField] private float spawnDelay;
    [SerializeField] private AutoMovement spawnAgent;

    public NavigationNode StartingNode {
        get {return startingNode;}
    }

    public float SpawnDelay {
        get {return spawnDelay;}
    }

    public AutoMovement SpawnAgent {
        get { return spawnAgent; }
    }

}
