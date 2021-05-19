using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstaclesController : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private Vector2 _obstacleSpawnPos = new Vector2(-15, -25);
    
    [SerializeField] private int _obstaclesSize = 5;
    [SerializeField] private float _spawnRate = 3f;
    [SerializeField] private float _obstacleMinYPos = -1f;
    [SerializeField] private float _obstacleMaxYPos = 3.5f;
    [SerializeField] private float _spawnXPos = 10f;
    [SerializeField] private float _scrollSpeed = -1.5f;
    [SerializeField] private float _scrollSpeedMulti = 3f;

    private GameObject[] _obstacles;
    
    private int _currentObstacle = 0;
    private float _timeSinceLastSpawned;

    private void Start()
    {
        _timeSinceLastSpawned = 0f;
        _obstacles = new GameObject[_obstaclesSize];
        for (int i = 0; i < _obstaclesSize; i++)
        {
            _obstacles[i] = Instantiate(_obstaclePrefab, _obstacleSpawnPos, Quaternion.identity);
            var rb = _obstacles[i].transform.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.right * _scrollSpeed;
        }
    }
    
    void Update()
    {
        if (!GameManager.Instance.GameStarted) return;
        _timeSinceLastSpawned += Time.deltaTime;
        _scrollSpeed -= Time.deltaTime * _scrollSpeedMulti;

        foreach (var obstacle in _obstacles)
        {
            var rb = obstacle.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.right * _scrollSpeed;
        }

        if (_timeSinceLastSpawned >= _spawnRate)
        {
            _timeSinceLastSpawned = 0f;

            var spawnYPos = Random.Range(_obstacleMinYPos, _obstacleMaxYPos);
            _obstacles[_currentObstacle].transform.position = new Vector2(_spawnXPos, spawnYPos);
            _currentObstacle++;

            if (_currentObstacle >= _obstaclesSize)
            {
                _currentObstacle = 0;
            }
        }
    }
}