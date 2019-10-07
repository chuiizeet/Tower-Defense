using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausableTime : MonoBehaviour
{
    public float Timer {get; private set;} 

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        Timer += Time.deltaTime;
    }

    protected void ResetTimer()
    {
        Timer = 0.0f;
    }

    protected IEnumerator WaitForTime(float timeToWait)
    {
        var timer = 0.0f;
        while (Timer <= timeToWait) {
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }
}
