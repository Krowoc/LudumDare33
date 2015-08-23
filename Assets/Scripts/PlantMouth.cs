using UnityEngine;
using System.Collections;

public class PlantMouth : MonoBehaviour {

	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		audioSource.Play ();

		Mario mario = other.GetComponent<Mario>();

		if(mario != null)
		{
			mario.transform.SetParent (gameObject.transform);
			mario.Die ();

		}
			

	}
}
