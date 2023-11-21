using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateCubeOnMouseClick : MonoBehaviour
{
    public GameObject cube = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(cube, hit.point, Quaternion.identity);
            }
        }

    }
}
