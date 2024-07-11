using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayTransitionScript : MonoBehaviour
{
    public Animator transitionScene;

    void Start()
    {
        Time.timeScale = 1.0f;
        transitionScene.SetTrigger("startScene");
    }

    public void BackButton()
    {
        transitionScene.SetTrigger("endScene");
        StartCoroutine(TransitionPlay());

    }

    private IEnumerator TransitionPlay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
        GameManager.Instance.gameOver = false;
        Time.timeScale = 1f;
    }
}
