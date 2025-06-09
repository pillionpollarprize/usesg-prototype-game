using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public GameObject slotObj;
    public Transform[] slots;
    int space;
    void Start()
    {
        space = slotObj.transform.childCount;
        slots = new Transform[space];
        for (int i = 0; i < space; i++)
        {
            slots[i] = slotObj.transform.GetChild(i);
        }
        print("number of children " + space);
        print("first child " + slotObj.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text);
        //print("TEST: current length of slots: " + slots.Length);
        ////this clears all data in the slots
        //slots = new Transform[10];
        ////if i ever wanted to resize an array, i'll probably need a dynamic structure like List
        //print("TEST: after transformation: of slots" + slots.Length);

        UpdateData();

    }
    private void Awake()
    {
        if (instance == null) instance = this;
        else gameObject.SetActive(false); // if more than one, deactivate
    }
    public void GetPickedUpItem(int ID)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetComponent<InventorySlotBehavior>().holdID == 0)
            {
                slots[i].GetComponent<InventorySlotBehavior>().holdID = ID;
                UpdateData();
                break;
            }
        }
    }
    void SetSlots()
    {
        for (int i = 0; i < space; i++)
        {
            slotObj.transform.GetChild(i).GetComponent<InventorySlotBehavior>().holdID = 0;
        }
    }
    void UpdateData()
    {
        // needs some sort of library for ID's like Minecraft does it
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetComponent<InventorySlotBehavior>().holdID == 0)
            {
                slots[i].GetComponent<Button>().image.color = Color.gray;
                slots[i].GetComponentInChildren<TextMeshProUGUI>().text = " ";
            }
            if (slots[i].GetComponent<InventorySlotBehavior>().holdID == 1)
            {
                slots[i].GetComponent<Button>().image.color = Color.red;
                slots[i].GetComponentInChildren<TextMeshProUGUI>().text = "Medkit";
            }
        }
        print("first child " + slotObj.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text);
    }

}
