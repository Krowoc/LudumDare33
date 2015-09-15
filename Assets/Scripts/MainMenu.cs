using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Variables
	GameObject popUp1;
	Vector3 currentPosition;
	public Text ScoreDisplay;
	public int ScoreDisplayInt;
	public Text NameDisplayText;
	public string NameDisplay;

	// Use this for initialization
	void Start () 
	{
		popUp1 = GameObject.Find ("EntryPanel");
		currentPosition = popUp1.transform.localPosition;
		popUp1.transform.localPosition = new Vector3 (1000, 1000);
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			if(Application.loadedLevel == 0)
				Application.Quit ();
			else
				OnBackButton ();
		}
	}

	public void OnStartButton()
	{
		Application.LoadLevel ("Scene01");
	}

	public void OnCreditsButton()
	{
		Application.LoadLevel ("Credits");
	}

	public void OnBackButton()
	{
		Application.LoadLevel ("TitleScreen");
	}

	public void OnUploadButton()
	{
		GameObject.Find ("UploadButton").SetActive (false);

		popUp1.transform.localPosition = currentPosition;
	}

	public static int ToInt32(string value)
	{
		if (value == null)    
			return 0;
		
		return System.Int32.Parse(value, System.Globalization.CultureInfo.CurrentCulture);
	}

	public void OnSubmitButton()
	{
		ScoreDisplay = GameObject.Find ("Score").GetComponent<Text>();
		ScoreDisplayInt = ToInt32 (ScoreDisplay.text);
		NameDisplayText = GameObject.Find ("InputText").GetComponent<Text> ();
		NameDisplay = NameDisplayText.ToString();

		Debug.Log (NameDisplay.ToString());
		GameObject.Find ("HighScoreText").GetComponent<HighScoreControl> ().PostScores(NameDisplay, ScoreDisplayInt);
		//Application.LoadLevel ("Credits");
	}

	public void OnExitButton()
	{
		Application.Quit ();
	}
}
