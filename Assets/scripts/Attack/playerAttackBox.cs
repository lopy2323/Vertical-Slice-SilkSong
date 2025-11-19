using System;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    //Assign attack box here
    [SerializeField] private GameObject attackBox;

    private float attackTimer;
    [SerializeField] private float attackDuration = 0.2f;
    void Start()
    {
        //disables the attack box at start
        attackBox.SetActive(false);
    }

    void Update()
    {
        attackTimer += Time.deltaTime;
        //Enables attack box when attack button is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            attackTimer = 0f;
            attackBox.SetActive (true);
        }
        //Disables attack box when attack duration is over.
        if (attackTimer > attackDuration)
        {
            attackBox.SetActive(false);
        }
    }
}
