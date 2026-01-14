using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D enemyRigidbody;
    [SerializeField] private Vector3 moveDirection;

    private void Start()
    {

        AttackBoxCollision.OnPlayerAttackHit += GetEnemyPoints;
    }

    /*private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }
        
    }*/
    private void GetEnemyPoints()
    {              //Als het bericht binnenkomt dat de enemy dood is voeren we de functie uit
        Debug.Log("Enemy Hit");

        //enemyRigidbody.AddForce(moveDirection * -1f);
        //Destroy(gameObject);
    }
}
