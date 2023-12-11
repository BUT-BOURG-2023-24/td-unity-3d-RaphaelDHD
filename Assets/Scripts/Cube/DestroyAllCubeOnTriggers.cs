using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllCubeOnTriggers : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject[] gameObject = GameObject.FindGameObjectsWithTag("Cube");

            foreach (GameObject cube in gameObject)
            {
                Destroy(cube);
            }
        }
    }
    
}
