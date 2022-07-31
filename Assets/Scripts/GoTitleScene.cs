using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTitleScene : MonoBehaviour
{
    public void OnTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
