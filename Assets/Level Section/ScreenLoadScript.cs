using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoadScript : MonoBehaviour
{
    // Loads up Scenes
    public void PlayButton()
    {
        SceneManager.LoadScene(2);
    }
    public void ControlButton()
    {
        SceneManager.LoadScene(1);
    }
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }    

    public void QuitButton()
    {
        Application.Quit();
    }

}
