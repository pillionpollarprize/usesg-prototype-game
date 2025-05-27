using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool done = false;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && done == false)
        {
            print("done task");
            done = true;
            TasksManager.instance.Ping();

        }
    }
}
