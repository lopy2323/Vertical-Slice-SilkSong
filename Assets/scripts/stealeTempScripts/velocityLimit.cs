using UnityEngine;

public class velocityLimit : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector3 currentVelocity;
    [SerializeField] private Vector3 velocityLimi;
    void Start()
    {
        Debug.Log("");
    }

    void Update()
    {
        currentVelocity = rb.linearVelocity;

        if (true)
        {
            
        }
    }
}
