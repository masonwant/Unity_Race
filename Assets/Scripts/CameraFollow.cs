using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Vector3 offset;
    private Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;


    private void Start()
    {
        target = GameObject.FindWithTag("CarSwitching").transform;
    }
    private void Update()
    {
        transform.LookAt(target);
    }
    private void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    public void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }



    private void HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
