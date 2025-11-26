using System;
using UnityEngine;

public class AttackBox : MonoBehaviour
{

    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkRadius = 0.1f;
    public LayerMask groundLayer;

    [Header("Attack Boxes")]
    [SerializeField] private GameObject attackBoxLeft;
    [SerializeField] private GameObject attackBoxRight;
    [SerializeField] private GameObject attackBoxUp;
    [SerializeField] private GameObject attackBoxDownRight;
    [SerializeField] private GameObject attackBoxDownLeft;

    [Header("Attack Delay")]
    private float attackTimer;
    [SerializeField] private float attackDuration = 0.2f;

    //Determines which way the player is facing
    private int faceDirection = 0;// 0=Right, 1=Left, 2=Up, 3=down
    void Start()
    {
        //disables the attack box at start
        attackBoxRight.SetActive(false);
        attackBoxLeft.SetActive(false);
        attackBoxUp.SetActive(false);
        attackBoxDownRight.SetActive(false);
        attackBoxDownLeft.SetActive(false);
    }

    void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        //Determines which way the player is facing
        if (Input.GetKeyDown(KeyCode.D))
        {
            faceDirection = 0;
            Debug.Log("right");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            faceDirection = 1;
            Debug.Log("left");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            faceDirection = 2;
            Debug.Log("up");
        }
        

        attackTimer += Time.deltaTime;
        //Enables apropriate attack box when attack button is pressed
        if (isGrounded == false && Input.GetKey(KeyCode.S))
        {
            //Down Right attack
            if (Input.GetKeyDown(KeyCode.E) && faceDirection == 0 && Input.GetKey(KeyCode.S))
            {
                attackTimer = 0f;
                attackBoxDownRight.SetActive(true);
            }
            //Down left attack
            if (Input.GetKeyDown(KeyCode.E) && faceDirection == 1 && Input.GetKey(KeyCode.S))
            {
                attackTimer = 0f;
                attackBoxDownLeft.SetActive(true);
            }
        }
        
        else
        {
            //Right attack
            if (Input.GetKeyDown(KeyCode.E) && faceDirection == 0)
            {
                attackTimer = 0f;
                attackBoxRight.SetActive(true);
            }

            //Left attack
            if (Input.GetKeyDown(KeyCode.E) && faceDirection == 1)
            {
                attackTimer = 0f;
                attackBoxLeft.SetActive(true);
            }

            //Up attack
            if (Input.GetKeyDown(KeyCode.E) && faceDirection == 2)
            {
                attackTimer = 0f;
                attackBoxUp.SetActive(true);
            }
        }



        //Disables attack box when attack duration is over.
        if (attackTimer > attackDuration)
        {
            attackBoxRight.SetActive(false);
            attackBoxLeft.SetActive(false);
            attackBoxUp.SetActive(false);
            attackBoxDownRight.SetActive(false);
            attackBoxDownLeft.SetActive(false);
        }
    }
}
