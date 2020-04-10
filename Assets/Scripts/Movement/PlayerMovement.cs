using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;

    [SerializeField]
    private float jumpForce = 5f;

    private Rigidbody2D rb;

    private float x;
    private float z;

    private Vector3 move;
    private BoxCollider2D boxCollider;
    private bool isGrounded;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        move = transform.right * x + transform.forward * z;
    }
    private void FixedUpdate()
    {
        rb.transform.Translate(move * moveSpeed * Time.fixedDeltaTime);
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("H");
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
