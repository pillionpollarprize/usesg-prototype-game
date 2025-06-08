using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public int[] inventoryIDs;
    public GameObject[] slots;
    
    void Start()
    {
        UpdateData();
        //inventoryIDs = new int[10];
        //slots = new Button[2];
    }
    private void Awake()
    {
        if (instance == null) instance = this;
        else gameObject.SetActive(false); // if more than one, deactivate
    }
    public void GetPickedUpItem(int ID)
    {
        for(int i = 0; i < inventoryIDs.Length; i++)
        {
            if (inventoryIDs[i] == 0)
            {
                inventoryIDs[i] = ID;
                UpdateData();
                break;
            }
        }
    }
    void UpdateData()
    {
        // needs some sort of library for ID's like Minecraft does it
        for (int i = 0; i < inventoryIDs.Length; i++)
        {
            if (inventoryIDs[i] == 0)
            {
                slots[i].GetComponent<Button>().image.color = Color.gray;
                slots[i].GetComponentInChildren<TextMeshProUGUI>().text = " ";
                print("donedidit");
            }
            if (inventoryIDs[i] == 1)
            {
                slots[i].GetComponent<Button>().image.color = Color.red;
                slots[i].GetComponentInChildren<TextMeshProUGUI>().text = "Medkit";
            }
        }
    }
}
