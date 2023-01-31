using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevertSwitch : MonoBehaviour
{
    public GameObject car1, car2;
    public GameObject cam1, cam2;

    int carSelect = 1;

    private void Start()
    {
        car1.gameObject.SetActive(false);
        car2.gameObject.SetActive(false);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
    }

    public void SwitchCar()
    {
        switch (carSelect)
        {
            case 1:
                carSelect = 2;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CarController>(out CarController carController))
        {
            SwitchCar();
            car1.gameObject.SetActive(true);
            car2.gameObject.SetActive(false);
            cam1.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);

        }
    }
}