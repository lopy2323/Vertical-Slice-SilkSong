using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float knockbackForce = 10f;

    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)

    {

        if (collision.gameObject.CompareTag("AttackBox"))

        {

            //Vector2 knockbackDirection = (rb.position - (Vector2)collision.transform.position).normalized;

            //rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

            Debug.Log("Player hit by enemy");

        }
    }
}
