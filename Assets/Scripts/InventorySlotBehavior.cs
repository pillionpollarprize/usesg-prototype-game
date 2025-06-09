using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotBehavior : MonoBehaviour, IPointerClickHandler
{
    public int holdID = 0;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(holdID != 0)
        {
            // left click
            if (eventData.pointerId == -1)
            {
                // todo: use
            }
            // right click
            else if (eventData.pointerId == -2)
            {
                // todo: throw away item
            }
        }
        
    }
}
