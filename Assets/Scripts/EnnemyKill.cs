using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyKill : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ennemy"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ennemy"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            Destroy(collision.gameObject);
        }
    }

}
