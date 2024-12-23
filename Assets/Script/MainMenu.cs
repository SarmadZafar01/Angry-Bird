using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void start_Button(string Start)
    {
        SceneManager.LoadScene(Start);
    }

    public void end_Button()
    {
        Application.Quit();
    }
}
