using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[AddComponentMenu("Singletons/ScoreManager")]
public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
	public static int eatScore = 10;
	public static int marioScore = 10;

	private static int score;
	private static int hiScore;
	private Text scoreDisplay;
	private Text hiScoreDisplay;

	private Hearts hearts;

	// Use this for initialization
	void Awake () {
		//score = 0;
		hiScore = PlayerPrefs.GetInt ("HiScore", 0);

		FindGameObjects ();

		updateText ();
		/*scoreDisplay = GameObject.Find("Score").GetComponent<Text>();
		hiScoreDisplay = GameObject.Find("HiScore").GetComponent<Text>();
		hearts = GameObject.Find ("Hearts").GetComponent<Hearts>();*/
	}

	void OnLevelWasLoaded()
	{
		FindGameObjects ();
	}

	void FindGameObjects()
	{
		GameObject go = GameObject.Find("Score");
		if(go != null)
			scoreDisplay = go.GetComponent<Text>();

		go = GameObject.Find("HiScore");
		if(go != null)
			hiScoreDisplay = go.GetComponent<Text>();

		go = GameObject.Find("Hearts");
		if(go != null)
			hearts = go.GetComponent<Hearts>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static int GetScore()
	{
		return score;
	}

	public static int GetHiScore()
	{
		return hiScore;
	}

	public static void ResetScore()
	{
		score = 0;
	}

	public void ModifyScore(int number)
	{
		score += number;
		
		if(score < 0)
			score = 0;
		
		/*if(score > hiScore)
			hiScore = score;*/
	}

	private void updateText() {
		scoreDisplay.text = score.ToString ("D5");
		hiScoreDisplay.text = hiScore.ToString ("D5");
		/*if(Score.score > Score.hiScore)
		{
			Score.hiScore = Score.score;
			hiScoreDisplay.text = Score.hiScore.ToString ("D5");
		}*/
	}
	
	public static void marioEaten() {
		ScoreManager.singleton.ModifyScore (eatScore);
		ScoreManager.singleton.updateText ();
	}
	
	public static void marioSurvived() {
		//ScoreManager.singleton.ModifyScore (-marioScore);
		//ScoreManager.singleton.updateText ();

		ScoreManager.singleton.hearts.LoseLife ();

	}

	public void EndLevel()
	{
		//PlayerPrefs.SetInt ("HiScore", hiScore);
		Debug.Log ("End");

		Application.LoadLevel ("GameOverScreen");
	}
}
