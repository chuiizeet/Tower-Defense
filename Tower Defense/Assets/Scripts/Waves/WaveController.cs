using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveController : MonoBehaviour
{
    [SerializeField] private List<Wave> waves = new List<Wave>();

    private int currentWaveIndex;

    public int CurrentWaveIndex
    {
        get {return currentWaveIndex;}
    }

    public event Action WaveChanged;
    public event Action WavesCompleted;

    public void StatWaves()
    {
        if (waves.Count > 0)
        {
            InitCurrentWave();
        }
        else 
        {
            print("No waves on wave controller");
            SafelyEmitEvent(ref WavesCompleted);
        }
    }

    public void SafelyEmitEvent(ref Action eventAction)
    {
        if (eventAction != null)
        {
            eventAction.Invoke();
        }
    }

    private void InitCurrentWave()
    {
        if (currentWaveIndex >= waves.Count)
        {
            SafelyEmitEvent(ref WavesCompleted);
        }
        var wave = waves[currentWaveIndex];
        wave.WaveCompleted += NextWave;
        wave.BeginWave();
        SafelyEmitEvent(ref WaveChanged);
    }

    private void NextWave(object sender, EventArgTemplate<bool> success)
    {
        if (success.Attachment)
        {
            waves[currentWaveIndex].WaveCompleted -= NextWave;
            currentWaveIndex++;
            if (currentWaveIndex >= waves.Count)
            {
                SafelyEmitEvent(ref WavesCompleted);
            }
            else
            {
                InitCurrentWave();
            }
        }
    }
}
