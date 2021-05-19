using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public static GameManager Instance;
	
	private const string ScoreString = "Distance: ";
	
	[SerializeField] private Text distanceText;
	[SerializeField] private GameObject gameOverText;
	
	private float distance;
	private bool isGameOver = false;

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
		
		Time.timeScale = 1;
		distance = 0f;
		gameOverText.SetActive(false);
	}

	void Update()
	{
		distance += Time.deltaTime * 100f;
		distanceText.text = ScoreString + distance.ToString();

		if (isGameOver && Input.GetKeyDown(KeyCode.Space)) 
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void GameOver()
	{
		gameOverText.SetActive(true);
		isGameOver = true;
		Time.timeScale = 0;
	}
}
