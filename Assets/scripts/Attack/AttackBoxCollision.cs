using UnityEngine;

public class AttackBoxCollision : MonoBehaviour
{
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            //Add EventFlag here
        }
    }
}
