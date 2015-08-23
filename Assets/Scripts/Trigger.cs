using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public int chanceToTrigger;

	void OnTriggerStay2D(Collider2D other)
	{
		if(Random.Range (0, 100) <= chanceToTrigger)
		{
			Mario mario = other.GetComponent<Mario>();

			if(mario != null)
				mario.Jump ();
		}
	}
}
