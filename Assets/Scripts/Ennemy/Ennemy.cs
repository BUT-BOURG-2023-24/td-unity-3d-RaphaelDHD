using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ennemy : MonoBehaviour
{
    public Rigidbody body = null;
    public float speed = 5f;

    private Transform player = null;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerGo = GameObject.FindGameObjectWithTag("Player");
        player = playerGo.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0;

            body.velocity = new Vector3(direction.normalized.x * Time.deltaTime * speed
                , body.velocity.y
                , direction.normalized.z * Time.deltaTime * speed);

            transform.LookAt(player);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.reloadScene();
        }
    }
}