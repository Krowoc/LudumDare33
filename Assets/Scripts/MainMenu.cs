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
			Application.Quit ();
		}
	}

	public void OnStartButton()
	{
		Application.LoadLevel ("Scene01");
	}

	public void OnCreditsButton()
	{

	}

	public void OnExitButton()
	{
		Application.Quit ();
	}
}
