using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public int chanceToTrigger;
	public int rnd;

	void OnTriggerEnter2D(Collider2D other)
	{
		rnd = Random.Range (0, 100);
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(rnd <= chanceToTrigger)
		{
			Mario mario = other.GetComponent<Mario>();

			if(mario != null)
				mario.Jump ();
		}
	}
}
