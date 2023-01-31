using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapTimer : MonoBehaviour
{
    [SerializeField] RaceTimer timer;

    private void Start()
    {
        timer.SetDuration(0).Begin();
    }
}
