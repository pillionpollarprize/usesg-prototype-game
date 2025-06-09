using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPickup : MonoBehaviour
{
    public int id;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                Inventory.instance.GetPickedUpItem(id);
                Destroy(gameObject);
            }
        }
    }
}
