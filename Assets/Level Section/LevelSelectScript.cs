using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    public Animator transitionScene;
    public AudioSource popSoundEffect;

    void Start()
    {
        Time.timeScale = 1f;
        transitionScene.SetTrigger("startScene");
    }
    public void TownSelect()
    {
        transitionScene.SetTrigger("endScene");
        StartCoroutine(WaitingToLoadTown());
        popSoundEffect.Play();
    }

    public void ParkSelect()
    {
        transitionScene.SetTrigger("endScene");
        StartCoroutine(WaitingToLoadPark());
        popSoundEffect.Play();
    }

    public IEnumerator WaitingToLoadTown()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(5);
    }

    public IEnumerator WaitingToLoadPark()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(6);
    }
}
