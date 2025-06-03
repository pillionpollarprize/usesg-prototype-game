using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Proceed : MonoBehaviour
{
    public GameObject a;
    bool b = false;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        if(a != null) StartCoroutine(ShowContinue());
    }

    // Update is called once per frame
    void Update()
    {
        if(b == true && Input.anyKeyDown) 
        {
            LoadScene();
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator ShowContinue()
    {
        yield return new WaitForSeconds(5);
        a.SetActive(true);
        b = true;
    }
}
