using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private TrackCheckpoints trackCheckpoints;
    public int checkpointCount = 0;
    GameObject gameController;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        Invisible();
    }

    public void Visable()
    {
        meshRenderer.enabled = true;
    }

    public void Invisible()
    {
        meshRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CarController>(out CarController carController))
        {
            trackCheckpoints.PlayerThroughCheckpoint(this);
            gameController.GetComponent<GameController>().EditorUpdate1(checkpointCount);

        }
        
    }



    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }
}



