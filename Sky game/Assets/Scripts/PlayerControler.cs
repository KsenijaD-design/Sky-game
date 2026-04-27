using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private InputAction move;
    [SerializeField] private float RotationSpeed, moveSpeed;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody rb;
    
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        move = InputSystem.actions.FindAction("Player/Move");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.Linecast(transform.position, transform.position - transform.up * 2, groundLayer);
        Debug.DrawRay(transform.position, transform.position - transform.up * 2);
        if (isGrounded)
        {
            Vector2 moveVector = move.ReadValue<Vector2>();
            float slopeAngle = Mathf.Abs(transform.localEulerAngles.y - 180);
            float speedMultiplayer = Mathf.Cos(Mathf.Deg2Rad * slopeAngle);
            rb.AddForce(transform.forward * moveSpeed * speedMultiplayer * Time.fixedDeltaTime);
            transform.Rotate(0, moveVector.x * RotationSpeed * Time.fixedDeltaTime, 0);
        }
        
    }
}
