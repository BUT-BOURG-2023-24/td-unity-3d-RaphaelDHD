using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePositionByVelocity : MonoBehaviour
{

    public float speed = 10.0f;
    public InputActionReference moveInputRef = null;
    public Rigidbody body = null;


    // Update is called once per frame
    void Update()
    {
        Vector2 inputMovement = moveInputRef.action.ReadValue<Vector2>();

        body.velocity = new Vector3(
            inputMovement.x * speed,
            body.velocity.y,
            inputMovement.y * speed);

    }
}
