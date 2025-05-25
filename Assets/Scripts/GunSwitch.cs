using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    public GameObject[] guns;
    public GameObject tablet;
    public GameObject tabletpanel;
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
        tabletpanel.SetActive(a);
        tablet.SetActive(a);
    }
    void SwitchGun(int newIndex)
    {
        guns[index].SetActive(false);
        guns[newIndex].SetActive(true);
        index = newIndex;
    }
}
