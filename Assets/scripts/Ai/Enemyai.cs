using UnityEngine;
using System.Collections;
using System;


public class Enemyai : MonoBehaviour
{
    private int Health = 100;
    private bool Attacking = false;

    private void TakeDamageEnemy(int Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            DieEnemy();
        }
    }
    private void DieEnemy()
    {
        Destroy(gameObject);
    }

    void Update()
    {
         Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        if (Vector2.Distance(transform.position,player.position) > 2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, 3f * Time.deltaTime);
        }else
        {
            Attacking = true;      
        }
        if (Attacking)
        {
            // Attack logic here
            Debug.Log("Enemy is attacking!");
        }
    }
}
