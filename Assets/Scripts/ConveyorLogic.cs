using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorLogic : MonoBehaviour
{
    public GameObject conveyor1;
    public GameObject conveyor2;
    public ConvDir directions;

    Vector3 direction;
    int stability = -1;
    private void Start()
    {
        switch (directions)
        {
            case ConvDir.LeftRight:
                direction = Vector3.forward;
                break;
            case ConvDir.UpDown:
                direction = Vector3.right;
                break;
        }
    }
    public void ConveyorStabilityUp()
    {
        stability++;
        if (stability == 1)
        {
            conveyor1.GetComponent<Conveyor>().t = direction;
            conveyor2.GetComponent<Conveyor>().t = direction;
            conveyor1.GetComponent<Conveyor>().speed = 10;
            conveyor2.GetComponent<Conveyor>().speed = -10;
        }
        print("stability up");
    }
}
public enum ConvDir
{
    LeftRight,
    UpDown
}
