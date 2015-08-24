using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	MarioSpawner spawner;

	// Use this for initialization
	void Start () {

		spawner = GameObject.Find ("Spawner").GetComponent<MarioSpawner>();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.LoadLevel("TitleScreen");
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

}
