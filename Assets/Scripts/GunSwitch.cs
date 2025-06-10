using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    public GameObject[] guns;
    public GameObject tablet;
    public GameObject tabletPanel;
    public GameObject inventoryPanel;
    private int index = 0;

    void Start()
    {
        SwitchGun(0);
    }

    void Update()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel");

        var tabletUp = Input.GetKeyDown(KeyCode.Tab);
        var tabletDown = Input.GetKeyUp(KeyCode.Tab);

        var inventoryUp = Input.GetKeyDown(KeyCode.BackQuote);
        var inventoryDown = Input.GetKeyUp(KeyCode.BackQuote);

        if (tabletUp)
        {
            Switch2Tablet(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else if (tabletDown)
        {
            Switch2Tablet(false);
            Cursor.lockState = CursorLockMode.Locked;

        }

        if (inventoryUp)
        {
            Switch2Inventory(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else if (inventoryDown)
        {
            Switch2Inventory(false);
            Cursor.lockState = CursorLockMode.Locked;

        }

        if (scroll > 0)
        {
            SwitchGun((index + 1) % guns.Length);
        }
        else if (scroll < 0)
        {
            var i = index - 1;
            if (i < 0) i = guns.Length - 1;
            SwitchGun(i);
        }
    }
    void Switch2Tablet(bool a)
    {
        guns[index].SetActive(!a);
        tabletPanel.SetActive(a);
        tablet.SetActive(a);
    }
    void Switch2Inventory(bool a)
    {
        guns[index].SetActive(!a);
        inventoryPanel.SetActive(a);
        tablet.SetActive(a);
    }
    void SwitchGun(int newIndex)
    {
        guns[index].SetActive(false);
        guns[newIndex].SetActive(true);
        index = newIndex;
    }
    public void Holster()
    {
        guns[index].SetActive(false);
    }
}
