using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int laps = 0;
    public int checkpointID = 0;
    public int checkpointCount = 0;
    public int lapsComplete = 0;
    public void EditorUpdate(int n)
    {
        laps = n;
    }
    public void EditorUpdate1(int n)
    {
        checkpointID = n;
    }
    public void EditorUpdate2(int n)
    {
        checkpointCount = n;
    }
    public void checkpoints()
    {
        if (checkpointID == checkpointCount)
        {
            lapsComplete++;
            Debug.Log("laps++");
        }
        if (lapsComplete == laps)
        {
            Debug.Log("finished");
        }
    }
}
