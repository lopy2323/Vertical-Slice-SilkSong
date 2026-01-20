using System;
using UnityEngine;

public class pogo : MonoBehaviour
{
    public static event Action OnPogoHit;

    [SerializeField] private Rigidbody2D playerRigidbody;
    private Vector3 pogoDirection = new Vector3 (0, 1, 0);
    [SerializeField] private float pogoForce = 500;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //playerRigidbody.gravityScale = 6f;
           // playerRigidbody.AddForce(pogoDirection * pogoForce);
           Debug.Log("Pogo Hit Invoked!");
            OnPogoHit.Invoke();
        }
        
    }
}
