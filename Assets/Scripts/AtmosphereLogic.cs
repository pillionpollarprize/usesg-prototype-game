using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosphereLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Health>();
            player.inAtmosphere = true;
            print("we're so back");
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Health>();
            player.inAtmosphere = false;
            print("it's so over");
        }
    }
}
