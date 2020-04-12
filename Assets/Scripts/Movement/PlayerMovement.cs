using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed = 2f;
    private float x;
    private float z;
    private Vector3 move;

    [SerializeField] private float jumpForce = 2.5f;

    private Rigidbody rb;
    private BoxCollider boxCollider;

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void Update() {

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");


        move = transform.right * x + transform.forward * z;
    }

    private void FixedUpdate() {
        rb.transform.Translate(Time.fixedDeltaTime * moveSpeed * move);
    }

}
