using UnityEngine;
using System.Collections;

public class TriggerDestroy : MonoBehaviour {

	AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//ScoreCounter.instance().marioSurvived ();
		ScoreManager.marioSurvived ();

		if(audioSource != null)
			audioSource.Play ();
		
		Destroy (other.gameObject);
		/*Mario mario = other.GetComponent<Mario>();
			
		if(mario != null)
			Destroy (other.gameObject);*/

	}
}
