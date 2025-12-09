using UnityEngine;
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
    private void GetEnemyPoints()
    {              //Als het bericht binnenkomt dat de enemy dood is voeren we de functie uit
        Debug.Log("Enemy Hit");

        //enemyRigidbody.AddForce(moveDirection * -1f);
        GameObject.Destroy(this.gameObject);
    }
}
