using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject main;
    public GameObject settings;
    public GameObject exit;

    public void OpenAndClose(GameObject one, GameObject two)
    {
        one.SetActive(false);
        two.SetActive(true);
    }
}
