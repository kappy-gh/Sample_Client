using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainScene : MonoBehaviour
{
    public void OnMain()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }
}
