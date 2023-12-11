using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MovePositionByAxis : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpSpeed = 10.0f;
    [SerializeField]
    public bool useRawAxis = false;
    private bool isGrounded = true;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = useRawAxis ? Input.GetAxisRaw("Horizontal") : Input.GetAxis("Horizontal");
        float yAxis = useRawAxis ? Input.GetAxisRaw("Vertical") : Input.GetAxis("Vertical");
        float jump = 0.0f;
        if (isGrounded)
        {
            jump = Input.GetAxisRaw("Jump");
            isGrounded = false;
        }
        Debug.Log(xAxis);
        Debug.Log(yAxis);

        transform.Translate(xAxis * speed * Time.deltaTime, jump * jumpSpeed * Time.deltaTime, yAxis * speed * Time.deltaTime);
    }




}
