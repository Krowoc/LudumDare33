using UnityEngine;
using System.Collections;

public class PlayerPlant : MonoBehaviour {

	public float speed;
	public Rigidbody2D plant;

	// Use this for initialization
	void Start () 
	{
		plant = gameObject.GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			//Debug.Log ("Button pressed");
			plant.velocity = (Vector2.up * speed);
		}

	}
	void OnCollisionEnter2D(Collision2D coll) 
	{

		if (coll.gameObject.name == "Mario-sheet_0(Clone)") 
		{
			Debug.Log("Mario collided with plant");
			Destroy(coll.gameObject);
		} 

	}



}