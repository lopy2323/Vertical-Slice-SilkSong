using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //[SerializeField] float speed = 1;
    [SerializeField] private float speed;
    
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
    }
}
