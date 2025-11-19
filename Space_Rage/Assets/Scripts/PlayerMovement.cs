using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private LayerMask groundMask = ~0;
    [SerializeField] private float groundCheckDistance = 0.6f;

    private Rigidbody rb;
    private Vector2 moveInput;
    private bool jumpRequested;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.Get<float>() > 0.5f)
            jumpRequested = true;
    }

    void FixedUpdate()
    {
        Vector3 desiredLocal = new Vector3(moveInput.x, 0f, moveInput.y);
        Vector3 desiredWorld = transform.TransformDirection(desiredLocal) * moveSpeed;

        Vector3 vel = rb.linearVelocity;
        vel.x = desiredWorld.x;
        vel.z = desiredWorld.z;
        rb.linearVelocity = vel;

        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);

        //jump
        if (jumpRequested && isGrounded)
        {
            float v = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
            Vector3 v2 = rb.linearVelocity;
            v2.y = v;
            rb.linearVelocity = v2;
            SoundManager.PlaySound(SoundType.JUMP);
        }

        jumpRequested = false;
    }
}
