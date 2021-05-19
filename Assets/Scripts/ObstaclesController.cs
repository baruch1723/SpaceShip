using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Vector2 obstacleSpawnPos = new Vector2(-15, -25);
    [SerializeField] private int obstaclesSize = 5;
    [SerializeField] private float spawnRate = 3f;
    [SerializeField] private float obstacleMinYPos = -1f;
    [SerializeField] private float obstacleMaxYPos = 3.5f;
    [SerializeField] private float spawnXPos = 10f;
    [SerializeField] private float scrollSpeed = -1.5f;

    private GameObject[] obstacles;
    private int currentObstacle = 0;
    private float timeSinceLastSpawned;

    void Start()
    {
        timeSinceLastSpawned = 0f;
        obstacles = new GameObject[obstaclesSize];
        for (int i = 0; i < obstaclesSize; i++)
        {
            obstacles[i] = Instantiate(obstaclePrefab, obstacleSpawnPos, Quaternion.identity);
            var rb = obstacles[i].transform.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2 (scrollSpeed, 0);
        }
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;
            var spawnYPos = Random.Range(obstacleMinYPos, obstacleMaxYPos);
            obstacles[currentObstacle].transform.position = new Vector2(spawnXPos, spawnYPos);
            currentObstacle++;
            if (currentObstacle >= obstaclesSize)
            {
                currentObstacle = 0;
            }
        }
    }
}