using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour
{
    public void HomeButton ( string Home_button)
    {
        SceneManager.LoadScene (Home_button);   
    }
}
