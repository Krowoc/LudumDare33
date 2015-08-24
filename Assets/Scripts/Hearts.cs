using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hearts : MonoBehaviour {

	[SerializeField]
	public List<GameObject> hearts = new List<GameObject>();

	int lives;

	// Use this for initialization
	void Start () {
		lives = hearts.Count;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void LoseLife()
	{
		lives -= 1;

		for(int i = 0; i < hearts.Count; i++)
		{
			if (i < lives)
				hearts[i].SetActive (true);
			else
				hearts[i].SetActive (false);
		}

		if (lives <= 0)
		{
			ScoreManager.singleton.EndLevel ();

		}
	}
}
