using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TasksManager : MonoBehaviour
{
    public static TasksManager instance;
    public TextMeshProUGUI taskText;
    public GameObject[] tasks;
    public int totalTasks = 0;
    public int totalTasksDone = 0;

    private void Awake()
    {
        if (instance == null) instance = this;
        else gameObject.SetActive(false); // if more than one, deactivate
    }

    private void Start()
    {
        //todo: automatically count tasks inside tasksmanager
        for(int i = 0; i < tasks.Length; i++)
        {
            totalTasks++;
        }
        ShowTasksOnPhone();
    }
    public void Ping()
    {
        totalTasksDone = 0;
        for(int i = 0; i < tasks.Length; i++)
        {
            if(tasks[i].GetComponent<Interactable>().done == true)
            {
                totalTasksDone++;
            }
        }
        if(totalTasksDone == totalTasks)
        {
            print("all tasks done");
            //todo: send indication task is done
        }
        ShowTasksOnPhone();
    }
    void ShowTasksOnPhone()
    {
        string temp;
        temp = "[" + totalTasksDone + "/" + totalTasks + "] Fix things";
        if (totalTasksDone == totalTasks)
        {
            temp += "\nALL TASKS DONE, HEAD TO SHIP";
        }
        taskText.text = temp;
    }
}
