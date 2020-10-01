using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour {

	GameObject player;

	GameObject scoreText;
	GameObject healthText;

	GameObject retryButton;
	GameObject gameOverText;
	GameObject endScoreText;
	GameObject highScoreText;

	public static int score;

	public static UIManager singleton;

	// Use this for initialization
	void Start () {
		
		player = GameObject.Find ("Player");

		scoreText = GameObject.Find ("ScoreText");
		healthText = GameObject.Find ("HealthText");

		retryButton = GameObject.Find ("RetryButton");
		endScoreText = GameObject.Find ("EndScoreText");
		gameOverText = GameObject.Find ("GameOverText");
		highScoreText = GameObject.Find ("HighScoreText");

		retryButton.SetActive (false);
		endScoreText.SetActive (false);
		gameOverText.SetActive (false);
		highScoreText.SetActive (false);

		score = 0;
		singleton = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<Player> ().health <= 0) {
			Cursor.visible = true;
			scoreText.SetActive (false);
			healthText.SetActive (false);

			retryButton.SetActive (true);
			endScoreText.SetActive (true);
			gameOverText.SetActive (true);
			highScoreText.SetActive (true);
			endScoreText.GetComponent<Text> ().text = "Score: " + score;

			if (score > PlayerPrefs.GetInt ("High Score")) {
				PlayerPrefs.SetInt ("High Score", score);
				endScoreText.GetComponent<Text> ().text = "New High Score!";
			}
			highScoreText.GetComponent<Text> ().text = "High Score: " + PlayerPrefs.GetInt ("High Score");
		} else {
			Cursor.visible = false;
			scoreText.GetComponent<Text> ().text = "Score: " + score;
			healthText.GetComponent<Text> ().text = "Health: " + player.GetComponent<Player> ().health;
		}
	}

	public void Reload() {
		SceneManager.LoadScene ("Level1");
		score = 0;
		Player.isDead = false;
	}
}
