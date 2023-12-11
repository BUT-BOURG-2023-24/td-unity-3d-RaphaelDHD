using UnityEngine;
using UnityEngine.InputSystem;

public class JumpBehavior : MonoBehaviour
{
    public InputActionReference jumpActionRef = null;
    public Rigidbody body = null;
    public float jumpPower = 10.0f;
    private bool isGrounded = true;


    private void OnEnable()
    {
        jumpActionRef.action.performed += OnJumpInputPressed;
    }

    private void OnJumpInputPressed(InputAction.CallbackContext context)
    {
        Jump();
    }

    private void OnDisable()
    {
        jumpActionRef.action.performed -= OnJumpInputPressed;
    }

    private void Jump()
    {
        if (isGrounded)
        {
            body.AddForce(Vector3.up * jumpPower);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
