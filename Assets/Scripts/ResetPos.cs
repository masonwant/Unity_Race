using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{

    public Transform resetCar;
    public GameObject theCar;

    private void OnTriggerEnter(Collider other)
    {
        theCar.transform.position = resetCar.transform.position;
        theCar.transform.rotation = resetCar.transform.rotation;
    }
}
