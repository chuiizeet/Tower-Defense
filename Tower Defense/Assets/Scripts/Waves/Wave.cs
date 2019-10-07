using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Wave : PausableTime
{
    protected int currentInstructionIndex;

    public event EventHandler<EventArgTemplate<bool>> WaveCompleted;

    public virtual void BeginWave()
    {
        CompleteNextInstruction();
    }

    protected virtual void HandleCompletion(bool success)
    {
        if (WaveCompleted != null) {
            var completion = new EventArgTemplate<bool>(success);
            WaveCompleted.Invoke(this, completion);
        }
    }

    protected abstract void CompleteNextInstruction();

}
