using System;
using UnityEngine;

public class AttackBoxCollision : MonoBehaviour
{
    public static event Action OnPlayerAttackHit; //Definitie van een Action Event
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            OnPlayerAttackHit?.Invoke();
            //Add EventFlag here
        }
    }
}
