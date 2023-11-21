using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MovePositionByNewInput : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    public InputActionReference moveInputRef = null;
    private bool isGrounded = true;
    Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 inputMovement = moveInputRef.action.ReadValue<Vector2>();

        transform.position += new Vector3(
            inputMovement.x * speed * Time.deltaTime,
            0.0f,
            inputMovement.y * speed * Time.deltaTime);

        // jump system 
        if (isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            m_Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
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
