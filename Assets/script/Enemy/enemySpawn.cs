using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject rectangularPrefab; // Reference to the rectangular prefab
    public float spawnDelay = 1f; // Delay between spawns
    public float roundDuration = 30f; // Duration of a round
    public int enemiesPerRound = 5; // Number of enemies to spawn per round
    private float timer = 0f; // Timer to track the elapsed time
    private int enemiesSpawned = 0; // Number of enemies spawned in the current round

    void Update()
    {
        timer += Time.deltaTime; // Increase the timer based on the elapsed time

        if (timer >= roundDuration)
        {
            timer = 0f; // Reset the timer for the next round
            enemiesSpawned = 0; // Reset the number of enemies spawned
        }
        else if (timer >= spawnDelay && enemiesSpawned < enemiesPerRound)
        {
            SpawnRectangularObject(); // Spawn enemy
            timer = 0f; // Reset the timer for the next spawn
            enemiesSpawned++; // Increment the number of enemies spawned
        }
    }

    public void SpawnRectangularObject()
    {
        // Instantiate the rectangular prefab as a child of the current GameObject
        GameObject newObject = Instantiate(rectangularPrefab, transform.position, Quaternion.identity, transform);
    }

}