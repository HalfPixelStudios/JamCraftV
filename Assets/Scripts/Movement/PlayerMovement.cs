using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;

    [SerializeField]
    private float jumpForce = 2.5f;

    private Rigidbody rb;

    private float x;
    private float z;

    private Vector3 move;
    private BoxCollider boxCollider;
    private bool isGrounded;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }
    private void Update()
    {
        
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        move = transform.right * x + transform.forward * z;
    }

    private void FixedUpdate()
    {
        rb.transform.Translate(Time.fixedDeltaTime * moveSpeed * move);
    }
    private void Jump()
    {       
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode.Impulse);
        isGrounded = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
