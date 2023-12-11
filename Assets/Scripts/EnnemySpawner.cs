using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    public GameObject ennemyPrefab = null;
    public float spawnDelay = 1.0f;
    public int maxEnnemies = 10;
    private int currentEnnemies = 0;
    private float spawnTimer = 0.0f;

    void Start()
    {
        spawnTimer = spawnDelay;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDelay && currentEnnemies < maxEnnemies)
        {
            spawnTimer = 0.0f;
            currentEnnemies++;

            // Calculate a random position within the bounds of the gameObject's transform
            Vector3 spawnPosition = new Vector3(
                Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2),
                transform.position.y,
                Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2)
            );
            GameObject.Instantiate(ennemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
