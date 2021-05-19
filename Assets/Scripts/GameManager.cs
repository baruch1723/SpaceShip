using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public static GameManager Instance;
	
	private const string ScoreString = "Distance: ";
	
	[SerializeField] private GameObject _gameOverText;
	[SerializeField] private Text _distanceText;
	
	private float _distance;
	private float _distanceForce = 100f;
	private bool _isGameOver = false;
	private bool _gameStarted = false;
	public bool GameStarted => _gameStarted;
	
	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy (gameObject);
		}

		StartGame();
	}
	
	public void StartGame()
	{
		Time.timeScale = 1;
		_distanceText.gameObject.SetActive(true);
		_gameOverText.SetActive(false);
		_gameStarted = true;
		_isGameOver = false;
		_distance = 0f;
	}

	public void GameOver()
	{
		Time.timeScale = 0;
		_gameOverText.SetActive(true);
		_isGameOver = true;
	}
	
	void Update()
	{
		if (!_gameStarted) return;
		_distance += Time.deltaTime * _distanceForce;
		_distanceText.text = ScoreString + _distance.ToString();

		if (_isGameOver && Input.GetKeyDown(KeyCode.Space)) 
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
