using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovePositionByKeys : MonoBehaviour
{
    public float speed = 10.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputMovement = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputMovement.z = 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            inputMovement.z = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputMovement.x  = 1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputMovement.x = -1f;
        }
        transform.position = transform.position + (inputMovement * speed * Time.deltaTime);
    }
}
