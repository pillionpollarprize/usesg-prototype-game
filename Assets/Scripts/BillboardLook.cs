using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardLook : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}
