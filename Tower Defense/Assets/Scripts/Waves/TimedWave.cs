using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedWave : Wave
{
    [SerializeField] private float completionDelay = 15.0f;
    protected override void CompleteNextInstruction()
    {
        if (currentInstructionIndex >= spawnInstructions.Count) {
            StartCoroutine(DelayAndComplete());
            return;
        }

        var currentInstruction = spawnInstructions[currentInstructionIndex];
        // Run the current instruction
        StartCoroutine(HandleCurrentInstruction(currentInstruction));
    }

    private IEnumerator HandleCurrentInstruction(SpawnInstruction instruction) 
    {
        yield return WaitForTime(instruction.SpawnDelay);
        SpawnInstructionEnemy(instruction);
        CompleteNextInstruction();
    }

    private void SpawnInstructionEnemy(SpawnInstruction instruction) 
    {
        var newAgent = Instantiate(instruction.SpawnAgent);
        newAgent.StartingNode = instruction.StartingNode;
    }

    private IEnumerator DelayAndComplete()
    {
        yield return WaitForTime(completionDelay);
        HandleCompletion(true);
    }
}
