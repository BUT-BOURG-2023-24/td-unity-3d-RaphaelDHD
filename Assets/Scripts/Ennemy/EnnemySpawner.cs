using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    public BoxCollider levelBox = null;
    public GameObject enemyPrefab = null;
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 4f;


    private float nextSpawnTime = 0.0f;

    private void Update()
    {
        // Tirer un nombre aléatoire entre minSpawnTime et maxSpawnTime
        // Attendre que ce temps là s'écoule
        // Repeat

        if(nextSpawnTime <= 0)
        {
            nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);

            // Si ce temps là est écoulé, faire spawner l'ennemi
            float randomX = Random.Range(levelBox.bounds.min.x, levelBox.bounds.max.x);
            float randomZ = Random.Range(levelBox.bounds.min.z, levelBox.bounds.max.z);
            Vector3 spawnPos = new Vector3(randomX, 1, randomZ);
            GameObject.Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            nextSpawnTime -= Time.deltaTime;
        }
    }


}
