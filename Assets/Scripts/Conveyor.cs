using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Conveyor : MonoBehaviour
{
    public float speed = 3;
    [HideInInspector]public Vector3 t;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && speed != 0)
        {
            print("conveying");
            var rigidbody = other.gameObject.GetComponent<CharacterController>();
            rigidbody.Move(t * speed * Time.deltaTime);
        }
    }
}
