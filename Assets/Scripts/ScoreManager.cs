using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[AddComponentMenu("Singletons/Scoreboard")]
public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
	public int eatScore = 10;
	public int marioScore = 10;

	private long score;
	private long hiScore;
	private Text scoreDisplay;
	private Text hiScoreDisplay;


	// Use this for initialization
	void Awake () {
		score = 0;
		hiScore = PlayerPrefs.GetInt ("HiScore", 0);
		scoreDisplay = GameObject.Find("Score").GetComponent<Text>();
		hiScoreDisplay = GameObject.Find("HiScore").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public long getScore()
	{
		return score;
	}

	private void updateText() {
		scoreDisplay.text = score.ToString ("D5");
		if(score > hiScore)
		{
			hiScore = score;
			hiScoreDisplay.text = hiScore.ToString ("D5");
		}
	}
	
	public void marioEaten() {
		score += eatScore;
		updateText ();
	}
	
	public void marioSurvived() {
		score -= marioScore;
		if (score < 0)
			score = 0;
		updateText ();
	}
}
