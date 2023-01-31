using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CheckpointCreator : EditorWindow
{
    string checkpointName = "CheckpointSingle";
    int checkpointID = 1;
    int laps = 0;
    GameObject checkpoint;
    GameObject checkpointParent;
    float spawnRadius = 50f;
    public GameObject gameController;
    [MenuItem("Race Editing Tools/Checkpoint Creator")]

    public static void TabVisible()
    {
        GetWindow(typeof(CheckpointCreator));
    }

    private void OnGUI()
    {
        GUILayout.Label("Add Checkpoints", EditorStyles.boldLabel);
        checkpointParent = EditorGUILayout.ObjectField("Parent", checkpointParent, typeof(GameObject), true) as GameObject;
        checkpointName = EditorGUILayout.TextField("Checkpoint Name", checkpointName);
        checkpointID = EditorGUILayout.IntField("Checkpoint ID", checkpointID);
        spawnRadius = EditorGUILayout.FloatField("Checkpoint Gap", spawnRadius);
        checkpoint = EditorGUILayout.ObjectField("Prefab to spawn", checkpoint, typeof(GameObject), true) as GameObject;
        GUILayout.Label("", EditorStyles.boldLabel);
        GUILayout.Label("Add Laps", EditorStyles.boldLabel);
        laps = EditorGUILayout.IntField("Laps", laps);
        gameController = EditorGUILayout.ObjectField("Game Controller", gameController, typeof(GameObject), true) as GameObject;
        if (GUILayout.Button("Create Checkpoint"))
        {
            CreateCheckpoint();
        }
        if (GUILayout.Button("Update Laps"))
        {
            gameController.GetComponent<GameController>().EditorUpdate(laps);
          //  gameController.GetComponent<GameController>().EditorUpdate1(checkpointID);
        }
        if (GUILayout.Button("Reset"))
        {
            laps = 0;
            checkpointID = 1;
        }
    }

    private void CreateCheckpoint()
    {
        if (checkpoint == null)
        {
            Debug.LogError("Error: Select the checkpoint you want to create");
            return;
        }
        if (checkpointName == string.Empty)
        {
            Debug.LogError("Error: Add a name to the Checkpoint");
            return;
        }

        Vector2 spawnCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(spawnCircle.x, 5.5f, spawnCircle.y);
        //GameObject newCheckpoint = Instantiate(checkpoint) as GameObject;
        
        GameObject newCheckpoint = Instantiate(checkpoint, spawnPos, Quaternion.identity) as GameObject;
        newCheckpoint.transform.SetParent(checkpointParent.transform);
        newCheckpoint.name = checkpointName + checkpointID;
        newCheckpoint.transform.localRotation = Quaternion.Euler(-90, 90, 0);
        checkpointID++;
    }


}