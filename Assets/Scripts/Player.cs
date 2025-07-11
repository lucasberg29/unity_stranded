using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isGrounded;
    private bool isWithinReachOfLog = false;
    private bool hasLog = false;
    private bool isGameOver = false;
    private bool isCampFireWithinReach = false;

    private int logsInInventory = 0;

    private Vector3 inputVector;
    private Animator playerAnimator;
    private Rigidbody playerRb;
    private Collider logFinderRb;
    
    [SerializeField]
    private LayerMask groundLayer;

    public float playerSpeed = 1.0f;

    public GameObject gameOverCanvas;
    public GameObject campFire;

    private GameObject logInReach;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponentInChildren<Animator>();
        logFinderRb = GetComponentInChildren<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * playerSpeed;
        float z = Input.GetAxis("Vertical") * playerSpeed;

        playerRb.linearVelocity = new Vector3(x, playerRb.linearVelocity.y, z);

        Vector3 vel = playerRb.linearVelocity;
        vel.y = 0;

        if (playerRb.linearVelocity.magnitude > 0.4)
        {

            playerAnimator.SetBool("isMoving", true);
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
        }

        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGameOver)
        {
            GameManager.instance.PlayLevel("Menu");
        }

        if(Input.GetKeyDown(KeyCode.Space) && isCampFireWithinReach)
        {
            Debug.Log("It wordkkks.");
            campFire.GetComponent<CampFire>().FuelFlames(logsInInventory);
            logsInInventory = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isWithinReachOfLog)
        {
            GetLog();
        }

        if(transform.position.y < -10)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Log")
        {
            logInReach = collision.gameObject;
            isWithinReachOfLog = true;
            logInReach.GetComponentInParent<Log>().ToggleInteractionPopUp(true);
        }

        if(collision.gameObject.tag == "Fire")
        {
            isCampFireWithinReach = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Log")
        {
            logInReach = collision.gameObject;
            isWithinReachOfLog = false;
            logInReach.GetComponentInParent<Log>().ToggleInteractionPopUp(false);
        }

        if (collision.gameObject.tag == "Fire")
        {
            isCampFireWithinReach = false;
        }
    }

    public void GetLog()
    {
        if(logInReach != null)
        {
            Destroy(logInReach.transform.parent.gameObject);
            ++logsInInventory;
        }
    }

    public void GameOver()
    {
        StartCoroutine(Ui.instance.GameOverText("You Drowned", gameOverCanvas));

        isGameOver = true;
    }
}
