using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoadScript : MonoBehaviour
{
    // Loads up Scenes
    public Animator transitionScene;
    void Start()
    {
        Time.timeScale = 1f;
        transitionScene.SetTrigger("startScene");
    }
    public void PlayButton()
    {
        transitionScene.SetTrigger("endScene");
        StartCoroutine(TransitionPlay());
    }
    public void ControlButton()
    {
        SceneManager.LoadScene(1);
    }

    public void AboutButton()
    {
        SceneManager.LoadScene(2);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }    

    public void QuitButton()
    {
        Application.Quit();
    }

    private IEnumerator TransitionPlay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }

}
