using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Mario mario = other.GetComponent<Mario>();

		mario.Jump ();
		Debug.Log (mario);

		if(mario != null)
			mario.Jump ();
	}
}
