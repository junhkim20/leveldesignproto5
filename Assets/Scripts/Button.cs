using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void TaskOnClick()
    {
        Global.level = 0; 
        Global.gemCount = 0; 
        SceneManager.LoadScene("level1");
    }
}
