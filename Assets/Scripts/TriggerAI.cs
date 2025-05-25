using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAI : MonoBehaviour
{
    public bool sighted;
    public Transform target;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = collision.gameObject.transform;
            print("spotted");
            sighted = true;
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = null;
            print("unspotted");
            sighted = false;
        }
    }
}
