using UnityEngine;
using System.Collections;
using System;


public class PalyerHealth : MonoBehaviour
{
    [SerializeField]private int Health = 100;
    public event Action OnPlayerDeath;
    public event Action<int> OnDamage;

    private void Start()
    {
        OnDamage += TakeDamage;
        OnPlayerDeath += Die;
    }
    private void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            OnPlayerDeath.Invoke();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
