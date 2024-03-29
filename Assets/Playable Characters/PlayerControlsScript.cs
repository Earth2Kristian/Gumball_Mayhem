using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlsScript : MonoBehaviour
{
    private static PlayerControlsScript instance = null;
    public InputAction playerControls;

    // Body Variables
    public Rigidbody rb;
    public CapsuleCollider cc;
    public CharacterController controller;

    // Basic Movement Variables
    private Vector2 movementInput = Vector2.zero;
    private Vector3 velocity;
    private float startingSpeed = 12f;
    public float currentSpeed;

    public Transform playerBody;

    private Vector2 rotationInput;
    private float xRotation = 0f;

    // Basic Running Variables
    private bool running = false;
    private float runningSpeed = 16f;
    public bool isRunning = false;

    // Basic Jump Variables
    private bool jumped = false;
    public float jumpHeight = 5f;
    public float jumpLimited = 1f;
    public float gravity = -9.8f;

    // Basic Dodge Variables
    private bool dodged = false;
    public bool isDodged = false;
    public float dodgeDistance = 12f;
    public float dodgeTimeLimited = 0.2f;

    // Ground Check
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public bool isGrounded;

    // Weapon Change System Variables
    public bool changed = false;
    public GameObject pistol;
    public bool pistolOn;
    public GameObject rifle;
    public bool rifleOn;
    public GameObject shotgun;
    public bool shotgunOn;

    // Basic Shooting Variables
    public bool shooted = false;
    public GameObject strawberryGumballProjectiles;
    public GameObject raspberryGumballProjectiles;
    public GameObject blackberryGumballProjectiles;
    public Transform gunPoint;
    
    // Basic Bombing Variables (Scrapped)
    public bool bombed = false;
    public GameObject bombProjectiles;
    public Transform bombPoint;
    public float bombThrowHeight = 2f;

    // Sound Effects
    public AudioSource gumballShootSoundEffect;
    public AudioSource jumpSoundEffect;
    public AudioSource dashSoundEffect;
  
    // Pause Settings for the Player
    public bool paused = false;


    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }


    void Start()
    {
        currentSpeed = startingSpeed;

        pistolOn = true;
        rifleOn = false;
        shotgunOn = false;

        rb.GetComponent<Rigidbody>();
        cc.GetComponent<CapsuleCollider>();
        controller.GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // When the player move the left stick left or right
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // When the player select (X button for PS or A button for Xbox)
        jumped = context.action.triggered;
        jumped = context.performed;

        if (context.performed && isGrounded && GameManager.Instance.playing == true)
        {
            // When the player jumps from the ground
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpSoundEffect.Play();
        }
        

    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        // When the player select (Square for PS or X button for Xbox)
        dodged = context.action.triggered;
        dodged = context.performed;

        if (context.performed && !isDodged)
        {
            if (GameManager.Instance.dashCurrent > 0 && GameManager.Instance.playing == true)
            {
                isDodged = true;
                Vector3 dodgeDirection = transform.forward;
                velocity = dodgeDirection * (dodgeDistance / dodgeTimeLimited);
                GameManager.Instance.dashCurrent -= 1;
                GameManager.Instance.dashBar.UpdateDashBar(GameManager.Instance.dashCurrent, GameManager.Instance.dashLimited);
                dashSoundEffect.Play();
            }


            StartCoroutine(Dodge());
        }
    }

    public void OnDodgeLeft(InputAction.CallbackContext context)
    {
        // When the player select (Square for PS or X button for Xbox)
        dodged = context.action.triggered;
        dodged = context.performed;

        if (context.performed && !isDodged)
        {
            if (GameManager.Instance.dashCurrent > 0 && GameManager.Instance.playing == true)
            {
                isDodged = true;
                Vector3 dodgeDirection = -transform.right;
                velocity = dodgeDirection * (dodgeDistance / dodgeTimeLimited);
                GameManager.Instance.dashCurrent -= 1;
                GameManager.Instance.dashBar.UpdateDashBar(GameManager.Instance.dashCurrent, GameManager.Instance.dashLimited);
                dashSoundEffect.Play();
            }

            StartCoroutine(Dodge());
        }
    }

    public void OnDodgeRight(InputAction.CallbackContext context)
    {
        // When the player select (Square for PS or X button for Xbox)
        dodged = context.action.triggered;
        dodged = context.performed;

        if (context.performed && !isDodged)
        {
            if (GameManager.Instance.dashCurrent > 0 && GameManager.Instance.playing == true)
            {
                isDodged = true;
                Vector3 dodgeDirection = transform.right;
                velocity = dodgeDirection * (dodgeDistance / dodgeTimeLimited);
                GameManager.Instance.dashCurrent -= 1;
                GameManager.Instance.dashBar.UpdateDashBar(GameManager.Instance.dashCurrent, GameManager.Instance.dashLimited);
                dashSoundEffect.Play();
            }

            StartCoroutine(Dodge());
        }
    }

    public void OnDodgeBackwards(InputAction.CallbackContext context)
    {
        // When the player select (Square for PS or X button for Xbox)
        dodged = context.action.triggered;
        dodged = context.performed;

        if (context.performed && !isDodged)
        {
            if (GameManager.Instance.dashCurrent > 0 && GameManager.Instance.playing == true)
            {
                isDodged = true;
                Vector3 dodgeDirection = -transform.forward;
                velocity = dodgeDirection * (dodgeDistance / dodgeTimeLimited);
                GameManager.Instance.dashCurrent -= 1;
                GameManager.Instance.dashBar.UpdateDashBar(GameManager.Instance.dashCurrent, GameManager.Instance.dashLimited);
                dashSoundEffect.Play();
            }

            StartCoroutine(Dodge());
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        running = context.action.triggered;
        running = context.performed;
        if (context.performed)
        {
            currentSpeed = runningSpeed;
            isRunning = true;


        }
        else if (!context.performed)
        {
            currentSpeed = startingSpeed;
            isRunning = false;
        }
       
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        // Player shoots from its pistol
        shooted = context.action.triggered;
        shooted = context.performed;

        if (context.performed && pistolOn == true)
        {
            if (GameManager.Instance.pistolAmmons > 0 && GameManager.Instance.playing == true)
            {
                GameObject bullet = Instantiate(strawberryGumballProjectiles, gunPoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(gunPoint.forward * 600);
                GameManager.Instance.ballCounts += 1;
                GameManager.Instance.ballCountsText.text = "SCORE: " + Mathf.Round(GameManager.Instance.ballCounts);
                GameManager.Instance.pistolAmmons -= 1;
                GameManager.Instance.pistolAmmonsText.text = "HAND GUM AMMO: " + Mathf.Round(GameManager.Instance.pistolAmmons);
                gumballShootSoundEffect.Play();
            }
            
        }
        if (context.performed && rifleOn == true)
        {
            if (GameManager.Instance.rifleAmmons > 0 && GameManager.Instance.playing == true)
            {
                GameObject bullet = Instantiate(raspberryGumballProjectiles, gunPoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(gunPoint.forward * 1200);
                GameManager.Instance.ballCounts += 1;
                GameManager.Instance.ballCountsText.text = "SCORE: " + Mathf.Round(GameManager.Instance.ballCounts);
                GameManager.Instance.rifleAmmons -= 1;
                GameManager.Instance.rifleAmmonsText.text = "RIFLE GUM AMMO: " + Mathf.Round(GameManager.Instance.rifleAmmons);
                gumballShootSoundEffect.Play();
            }
            
        }
        if (context.performed && shotgunOn == true)
        {

            if (GameManager.Instance.shotgunAmmons > 0 && GameManager.Instance.playing == true)
            {
                GameObject bullet = Instantiate(blackberryGumballProjectiles, gunPoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(gunPoint.forward * 300);
                GameManager.Instance.ballCounts += 1;
                GameManager.Instance.ballCountsText.text = "SCORE: " + Mathf.Round(GameManager.Instance.ballCounts);
                GameManager.Instance.shotgunAmmons -= 1;
                GameManager.Instance.shotgunAmmonsText.text = "SHOT GUM AMMO: " + Mathf.Round(GameManager.Instance.shotgunAmmons);
                gumballShootSoundEffect.Play();
            }
            
        }
    }


    public void OnPistol(InputAction.CallbackContext context)
    {
        changed = context.action.triggered;
        changed = context.performed;

        if (context.performed && GameManager.Instance.playing == true)
        {
            pistolOn = true;
            rifleOn = false;
            shotgunOn = false;
        }
    }
    public void OnRifle(InputAction.CallbackContext context)
    {
        changed = context.action.triggered;
        changed = context.performed;

        if (context.performed && GameManager.Instance.playing == true)
        {
            pistolOn = false;
            rifleOn = true;
            shotgunOn = false;
        }
    }

    public void OnShotGun(InputAction.CallbackContext context)
    {
        changed = context.action.triggered;
        changed = context.performed;

        if (context.performed && GameManager.Instance.playing == true)
        {
            pistolOn = false;
            rifleOn = false;
            shotgunOn = true;
        }
    }

    public void OnBomb(InputAction.CallbackContext context)
    {
        // Player shoots from its pistol
        bombed = context.action.triggered;
        bombed = context.performed;

        if (context.performed && GameManager.Instance.playing == true)
        {
            if (GameManager.Instance.bombsAmount > 0 && GameManager.Instance.playing == true)
            {

                GameObject bomb = Instantiate(bombProjectiles, bombPoint.position, Quaternion.identity);
                bomb.GetComponent<Rigidbody>().AddForce(bombPoint.forward * 600);
                GameManager.Instance.ballCounts += 1;
                GameManager.Instance.ballCountsText.text = "SCORE: " + Mathf.Round(GameManager.Instance.ballCounts);
                GameManager.Instance.bombsAmount -= 1;
                GameManager.Instance.bombAmountText.text = "GUMMY BOMBS: " + Mathf.Round(GameManager.Instance.bombsAmount);
            }
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        // When the player paused the game
        paused = context.action.triggered;
        paused = context.performed;

        if (context.performed && GameManager.Instance.playing == true)
        {
            GameManager.Instance.isPaused = true;
        }
    }


    void Update()
    {
        // Basic Player Movement
        float moveHorizontal = movementInput.x;
        float moveVertical = movementInput.y;

        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;

        controller.Move(move * currentSpeed * Time.deltaTime);
        

        // Checks the ground for the player
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            // If the player is on the ground or on a platform
            velocity.y = 0f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }



        // Gun Model Changes
        {
            if (pistolOn == true)
            {
                pistol.SetActive(true);
                rifle.SetActive(false);
                shotgun.SetActive(false);

            }
            if (rifleOn == true)
            {
                pistol.SetActive(false);
                rifle.SetActive(true);
                shotgun.SetActive(false);
            }
            if (shotgunOn == true)
            {
                pistol.SetActive(false);
                rifle.SetActive(false);
                shotgun.SetActive(true);
            }

        }
    }


    private IEnumerator Dodge()
    {

        yield return new WaitForSeconds(dodgeTimeLimited);

        velocity = Vector3.zero;
        isDodged = false;
    }
    void Awake()
    {
        instance = this;
    }

    public static PlayerControlsScript Instance
    {
        get
        {
            return instance;
        }
    }
}
