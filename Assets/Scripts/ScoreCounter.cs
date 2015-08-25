using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCounter {

	static private ScoreCounter _instance;
	private long score;
	private Text scoreDisplay;

	public long getScore()
	{
		return score;
	}

	public static ScoreCounter instance()
	{
		if (ScoreCounter._instance == null)
			ScoreCounter._instance = new ScoreCounter ();
		return _instance;
	}

	private ScoreCounter() {
		score = 0;
		scoreDisplay = GameObject.Find("Score").GetComponent<Text>();
	}

	private void updateText() {
		scoreDisplay.text = score.ToString ("D5");
	}

	public void marioEaten() {
		score += 10;
		updateText ();
	}

	public void marioSurvived() {
		score -= 10;
		if (score < 0)
			score = 0;
		updateText ();
	}
}
