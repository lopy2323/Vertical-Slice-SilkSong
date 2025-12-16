using UnityEngine;
using System.Collections;
using System;


public class Enemyai : MonoBehaviour
{
    private int Health = 100;

    bool isAwake = false;

    [SerializeField] private Collider2D Awake;
    [SerializeField] private Collider2D attack;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isAwake = true;
            Awake.enabled = false;
        }
    }

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
        if (isAwake)
        {
            Awake.enabled = true;
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            transform.position = Vector2.MoveTowards(transform.position,player.position,3f * Time.deltaTime);
        }
    }
}
