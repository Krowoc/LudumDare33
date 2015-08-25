using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	MarioSpawner spawner;

	public GameObject pauseMenu;

	// Use this for initialization
	void Start () {

		spawner = GameObject.Find ("Spawner").GetComponent<MarioSpawner>();

		//pauseMenu = GameObject.Find ("Pause");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			if(pauseMenu.activeSelf)
			{
				CloseMenu ();
			}
			else 
			{
				ScoreManager.isPaused = true;
				pauseMenu.SetActive (true);
				AudioListener.volume = 0;
				Time.timeScale = 0.000000001f;//0.0f;//
			}

		}

		if(Input.GetKeyDown (KeyCode.Equals))
		{
			spawner.DecreaseDelay ();
			Debug.Log (spawner.delayInSeconds);
		}

		if(Input.GetKeyDown (KeyCode.Minus))
		{
			spawner.IncreaseDelay ();
		}

		if(Input.GetKeyDown (KeyCode.M))
		{
			spawner.SpawnMario ();
		}

	}

	public void CloseMenu()
	{
		ScoreManager.isPaused = false;
		pauseMenu.SetActive (false);
		Time.timeScale = 1;
		AudioListener.volume = 1;
	}
	
	public void OnResume()
	{
		CloseMenu ();
	}
	
	public void OnMainMenuButton()
	{
		CloseMenu ();
		Application.LoadLevel ("TitleScreen");
	}
	
	public void OnExitButton()
	{
		CloseMenu ();
		Application.Quit ();
	}

}
