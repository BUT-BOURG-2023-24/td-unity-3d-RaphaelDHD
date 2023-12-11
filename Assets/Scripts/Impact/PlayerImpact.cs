using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerImpact : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Ennemy ennemy = other.GetComponent<Ennemy>();
        if (ennemy != null)
        {
            Destroy(ennemy.gameObject);
            GameManager.Instance.score++;
            Debug.LogError(GameManager.Instance.score);
        }
    }

}
