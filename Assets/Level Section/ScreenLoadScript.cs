using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoadScript : MonoBehaviour
{
    // Loads up Scenes
    public Animator transitionScene;
    public AudioSource popSoundEffect;
    void Start()
    {
        Time.timeScale = 1f;
        transitionScene.SetTrigger("startScene");
    }
    public void PlayButton()
    {
        transitionScene.SetTrigger("endScene");
        popSoundEffect.Play();
        StartCoroutine(TransitionPlay());
    }
    public void ControlButton()
    {
        transitionScene.SetTrigger("endScene");
        popSoundEffect.Play();
        StartCoroutine(TransitionControls());
    }

    public void AboutButton()
    {
        transitionScene.SetTrigger("endScene");
        popSoundEffect.Play();
        StartCoroutine(TransitionAbout());
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene(4);
        popSoundEffect.Play();
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
        popSoundEffect.Play();  
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

    private IEnumerator TransitionControls()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }

    private IEnumerator TransitionAbout()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }

}
