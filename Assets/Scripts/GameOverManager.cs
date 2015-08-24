using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	//int topScore;
	//int hiScore;
	//int score;

	//Text topScore;
	Text hiScoreDisplay;
	Text scoreDisplay;

	// Use this for initialization
	void Start () {

		//topScore = GameObject.Find ("TopScore").GetComponent<Text>();
		hiScoreDisplay = GameObject.Find ("HiScore").GetComponent<Text>();
		scoreDisplay = GameObject.Find ("Score").GetComponent<Text>();

		int hiScore = PlayerPrefs.GetInt("HiScore", 0);
		int score = ScoreManager.GetScore ();
		
		if (score > hiScore)
		{
			hiScore = score;
			PlayerPrefs.SetInt ("HiScore", score);
		}

		//topScore.text = tScore.ToString ("D5");
		hiScoreDisplay.text = hiScore.ToString ("D5");
		scoreDisplay.text = score.ToString ("D5");

		ScoreManager.ResetScore ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
