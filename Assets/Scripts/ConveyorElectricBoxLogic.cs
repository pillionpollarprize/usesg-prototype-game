using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorElectricBoxLogic : MonoBehaviour
{
    public GameObject indicator;
    public Material LeGood;
    public Material LeBad;
    bool F = false;
    public ConveyorLogic parentConveyor;
    private void Start()
    {
        if (F)
        {
            indicator.GetComponent<MeshRenderer>().material = LeGood;
        }
        else
        {
            indicator.GetComponent<MeshRenderer>().material = LeBad;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && F == false)
        {
            print("fixed");
            F = true;
            indicator.GetComponent<MeshRenderer>().material = LeGood;
            parentConveyor.ConveyorStabilityUp();
        }
    }
}
