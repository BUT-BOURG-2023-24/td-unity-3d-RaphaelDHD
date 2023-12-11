using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveByJoystick : MonoBehaviour
{

    public Joystick joystick = null;
    public float speed = 10.0f;
    public Rigidbody body = null;


    // Update is called once per frame
    void Update()
    {
        Vector2 inputMovement = joystick.Direction;

        body.velocity = new Vector3(
            inputMovement.x * speed,
            body.velocity.y,
            inputMovement.y * speed);

    }
}