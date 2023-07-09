using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpForce = 400f;

    [SerializeField] private Transform footPosition;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // check if we are on the ground
        bool isGrounded = false;
        RaycastHit2D hit = Physics2D.Raycast(footPosition.position, Vector3.down, 0.1f, groundLayer);
        if (hit.collider != null) {
            isGrounded = true;
        }

        // handle jump inputs
        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.AddForce(new Vector3(0f, jumpForce, 0f));
        }

        // handle lateral movement
        float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        Vector3 movement = new Vector3(horizontalMovement, 0f, 0f);
        transform.Translate(movement);
    }

}
