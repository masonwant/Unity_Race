using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrackCheckpoints : MonoBehaviour
{

    private List<CheckpointSingle> checkpointSingleList;
    private int nextCheckpoint;
    public int checkpointCount = 0;
    private int previousCheckpoint;
    public int lapConfirmed = 0;
    public event EventHandler OnCarCheckpointCorrect;
    public event EventHandler OnCarCheckpointWrong;
    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetTrackCheckpoints(this);

            checkpointSingleList.Add(checkpointSingle);
        }


    }
    private void Start()
    {
        CheckpointSingle nextCheckpointSingle  = checkpointSingleList[nextCheckpoint];
        nextCheckpointSingle.Visable();


    }
    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
        if (checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpoint)
        {
            CheckpointSingle correctCheckpointSingle = checkpointSingleList[nextCheckpoint];
            correctCheckpointSingle.Invisible();
            Debug.Log("Checkpoint Correct");
            checkpointCount++;
            nextCheckpoint = (nextCheckpoint + 1) % checkpointSingleList.Count;
            OnCarCheckpointCorrect?.Invoke(this, EventArgs.Empty);
            if (nextCheckpoint == 1)
            {
                lapConfirmed++;
                Debug.Log("Lap Complete");

            }



            //Next Checkpoint
            CheckpointSingle nextCheckpointSingle = checkpointSingleList[(nextCheckpoint) % checkpointSingleList.Count];
            nextCheckpointSingle.Visable();
        }
        else
        {
            Debug.Log("Checkpoint Error");
            CheckpointSingle correctCheckpointSingle = checkpointSingleList[nextCheckpoint];
            correctCheckpointSingle.Visable();
            OnCarCheckpointWrong?.Invoke(this, EventArgs.Empty);

        }
    }

}
