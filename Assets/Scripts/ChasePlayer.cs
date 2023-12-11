using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{

    public float speed = 10.0f;
    private GameObject player = null;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
