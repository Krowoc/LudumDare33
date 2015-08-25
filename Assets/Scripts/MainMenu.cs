using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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

	public void OnExitButton()
	{
		Application.Quit ();
	}
}
