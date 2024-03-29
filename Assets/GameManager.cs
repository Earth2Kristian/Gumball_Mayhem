using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public Animator playerCameraAnimate;

    public bool ableToClick = true;
    public float countdownTimer = 300;

    // Player's Status
    public float health = 100;
    public float ballCounts = 0;
    public float enemyCounts = 0;
    public float pistolAmmons = 50f;
    public float rifleAmmons = 200f;
    public float shotgunAmmons = 10f;
    public float bombsAmount = 3f;

    // Player's Health Status
    public float healthCurrent;
    public float healthLimited = 100;
    public HealthBarScript healthBar;
    public bool playerGotHit;

    // Player's Dash Status
    public float dashCurrent;
    public float dashLimited = 3;
    public DashBarScript dashBar;

    // Texts
    public TMP_Text healthText;
    public TMP_Text ballCountsText;
    public TMP_Text timerText;
    public TMP_Text enemyCounterText;
    public TMP_Text pistolAmmonsText;
    public TMP_Text rifleAmmonsText;
    public TMP_Text shotgunAmmonsText;
    public TMP_Text bombAmountText;

    // Welcome Settings
    public bool playing;
    public GameObject welcomeUI;

    // Pause Settings
    public bool isPaused;
    public GameObject pausedUI;

    // Gameover Settings
    public bool gameOver;
    public GameObject gameoverUI;
    public GameObject wonUI;
    public TMP_Text finalScoreText;

    // Sound Effect
    public AudioSource playerStartGameSoundEffect;

    
    public bool gameLost = false;
    public bool gameWon = false;

    void Start()
    {
        // Set the Text
        healthText.text = "HP: " + Mathf.Round(health);
        ballCountsText.text = "SCORE: " + Mathf.Round(ballCounts);
        timerText.text = "TIMER: " + Mathf.Round(countdownTimer);
        enemyCounterText.text = "ENEMY: " + Mathf.Round(enemyCounts);
        pistolAmmonsText.text = "HAND GUM AMMO: " + Mathf.Round(pistolAmmons);
        rifleAmmonsText.text = "RIFLE GUM AMMO: " + Mathf.Round(rifleAmmons);
        shotgunAmmonsText.text = "SHOT GUM AMMO: " + Mathf.Round(shotgunAmmons);
        bombAmountText.text = "GUMMY BOMBS: " + Mathf.Round(bombsAmount);

        // Camera is set to idle
        playerCameraAnimate.SetBool("playerGotHit", false);


        // Game will play
        Time.timeScale = 0f;

        // Set the Health Bar for the Player 
        healthCurrent = healthLimited;
        healthBar.UpdateHealthhBar(healthCurrent, healthLimited);

        // Set the Dash Bar for the Player
        dashCurrent = dashLimited;
        dashBar.UpdateDashBar(dashCurrent, dashLimited);

        playerGotHit = false;

        ableToClick = true;
        playing = false;
        isPaused = false;  
        gameOver = false;


        // Set Setting UIs
        welcomeUI.SetActive(true);
        pausedUI.SetActive(false);
        gameoverUI.SetActive(false);
        wonUI.SetActive(false);
    }

    
    void Update()
    {
        countdownTimer -= 1 * Time.deltaTime;
        timerText.text = "TIMER: " + Mathf.Round(countdownTimer);

        if (countdownTimer <= 0)
        {
            countdownTimer = 0;
            timerText.text = "TIMER: " + Mathf.Round(countdownTimer);
            Time.timeScale = 0f;
            wonUI.SetActive(true);
            finalScoreText.text = " SCORE:  " + Mathf.Round(ballCounts);
            playing = false;
            gameOver = true;
            gameWon = true;
            return;
            //gameOver = true;
        }

        if (healthCurrent >= 100)
        {
            healthCurrent = healthLimited;
            healthBar.UpdateHealthhBar(healthCurrent, healthLimited);

        }

        if (healthCurrent <= 0)
        {
            Time.timeScale = 0f;
            gameoverUI.SetActive(true);
            finalScoreText.text = " SCORE:  " + Mathf.Round(ballCounts);
            healthBar.UpdateHealthhBar(healthCurrent, healthLimited);
            playing = false;
            ableToClick = true;
            gameOver = true;
            gameLost = true; 
            return;
        }
        // Dash Bar
        //dashBar.UpdateDashBar(dashCurrent, dashLimited);

        if (dashCurrent < 3)
        {
            StartCoroutine(RecoverDash());
        }

        if (dashCurrent >= 3)
        {
            dashCurrent = dashLimited;
            dashBar.UpdateDashBar(dashCurrent, dashLimited);
        }

        // Condition when the player got hit
        if (playerGotHit == true)
        {
            playerCameraAnimate.SetBool("playerGotHit", true);
            StartCoroutine(CameraShakingDelay());
        }
        else if (playerGotHit == false)
        {
            playerCameraAnimate.SetBool("playerGotHit", false);
        }

        // Maxmium Ammons
        if (pistolAmmons >= 50)
        {
            pistolAmmons = 50;
            pistolAmmonsText.text = "HAND GUM AMMO: " + Mathf.Round(pistolAmmons);
        }

        if (rifleAmmons >= 200)
        {
            rifleAmmons = 200;
            rifleAmmonsText.text = "RIFLE GUM AMMO: " + Mathf.Round(rifleAmmons);
        }    

        if (shotgunAmmons >= 10)
        {
            shotgunAmmons = 10;
            shotgunAmmonsText.text = "SHOT GUM AMMO: " + Mathf.Round(shotgunAmmons);
        }

        if (bombsAmount >= 3)
        {
            bombsAmount = 3;
            bombAmountText.text = "GUMMY BOMBS: " + Mathf.Round(bombsAmount);
        }
        
        // Contidtions when the player has paused the game
        if (isPaused == true && playing)
        {
            Time.timeScale = 0f;
            pausedUI.SetActive(true);
        }
        else if (isPaused == false && playing)
        {
            Time.timeScale = 1f;
            pausedUI.SetActive(false);
        }
    }

    private IEnumerator RecoverDash()
    {
        yield return new WaitForSeconds(3);
        dashCurrent += 1 * Time.deltaTime;
        dashBar.UpdateDashBar(dashCurrent, dashLimited);

    }
    public IEnumerator CameraShakingDelay()
    {
        yield return new WaitForSeconds(0.5f);
        playerGotHit = false;
    }

    public void PlayButton()
    {
        ableToClick = false;
        playing = true;
        Time.timeScale = 1f;
        playerStartGameSoundEffect.Play();
        welcomeUI.SetActive(false);
    }

    public void ResumeButton()
    {
        isPaused = false;
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
        countdownTimer = 300;
        healthCurrent = healthLimited;
        dashCurrent = dashLimited;
        ballCounts = 0;
        healthText.text = "HP: " + Mathf.Round(health);
        ballCountsText.text = "SCORE: " + Mathf.Round(ballCounts);
        timerText.text = "TIMER: " + Mathf.Round(countdownTimer);

        // Set the Health Bar for the Player 
        healthCurrent = healthLimited;
        healthBar.UpdateHealthhBar(healthCurrent, healthLimited);

        // Set the Dash Bar for the Player
        dashCurrent = dashLimited;
        dashBar.UpdateDashBar(dashCurrent, dashLimited);

        gameOver = false;
        playing = false;
        ableToClick = true;

        welcomeUI.SetActive(true);
        gameoverUI.SetActive(false);
        wonUI.SetActive(false);

        gameLost = false;
        gameWon = false;
    }


    void Awake()
    {
        instance = this;
    }

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
}
