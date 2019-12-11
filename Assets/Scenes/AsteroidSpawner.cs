using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private float timeFromLastSpawnAttempt;
    private GameObject[] asteroids;

    public GameObject blueAsteroid;
    public GameObject redAsteroid;
    public GameObject mine1;
    public GameObject mine2;
    public float spawnAttemptPeriod;
    public float spawnProbability;

    void Start()
    {
        timeFromLastSpawnAttempt = float.PositiveInfinity;
        asteroids = new GameObject[] { blueAsteroid, redAsteroid, mine1, mine2 };
    }

    void Update()
    {
        timeFromLastSpawnAttempt += Time.deltaTime;

        if (timeFromLastSpawnAttempt > spawnAttemptPeriod)
        {
            TrySpawn();
        }
    }

    private void TrySpawn()
    {
        if (Random.Range(0f, 1f) >= spawnProbability)
        {
            timeFromLastSpawnAttempt = 0;

            var asteroid = asteroids[Random.Range(0, asteroids.Length)];
            var position = new Vector3(Random.Range(-40f, 40f), 0, 70);

            var spawned = Instantiate(asteroid, position, Random.rotation);
        }
    }

}
