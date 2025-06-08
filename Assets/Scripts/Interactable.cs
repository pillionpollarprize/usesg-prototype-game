using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject particles;
    public GameObject icon;
    public bool done = false;
    Quaternion rotation;
    private void Start()
    {
        // particles emitted always face in the correct direction
        icon.SetActive(false);
        rotation = new Quaternion(0, 180 + transform.localRotation.y, 0, 0);
    }
    
    private void OnTriggerStay(Collider other)
    {
        icon.SetActive(true);
        if (Input.GetKey(KeyCode.E) && done == false)
        {
            print("done task");
            done = true;
            TasksManager.instance.Ping();
            Instantiate(particles, transform.position, rotation, transform); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        icon.SetActive(false);
    }
}
