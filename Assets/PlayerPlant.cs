using UnityEngine;
using System.Collections;

public class PlayerPlant : MonoBehaviour {
	
	public GameObject  plant;
	public Vector3     startpos;
	public Vector3     endpos;
	public float       moveDistance;
	public float       lerpTime;
	public float       currentLerpTime;
	public bool        atBase = true;
	                   GameObject  baseCheck;

	// Use this for initialization
	void Start () 
	{
//		baseCheck = transform.FindChild ("baseCheck").gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) 
		{   
//			atBase = GroundTest();
//			if(atBase){
			 	currentLerpTime = 0f;
				plant = GameObject.FindGameObjectWithTag("player1");
				Attack ();
//			  }
		} 
		else if (Input.GetButtonDown ("Fire2")) 
		{
			currentLerpTime = 0f;
			plant = GameObject.FindGameObjectWithTag("player2");
			Attack ();
		} 
		else if (Input.GetButtonDown ("Fire3")) 
		{
			currentLerpTime = 0f;
			plant = GameObject.FindGameObjectWithTag("player3");
			Attack ();
		}

	}

//	bool GroundTest()
//	{
//		return Physics2D.Raycast (baseCheck.transform.position, Vector2.down, 0.1f);
//	}

	void OnCollisionEnter2D(Collision2D coll) 
	{

		if (coll.gameObject.name == "Mario(Clone)") 
		{
			Debug.Log("Mario collided with plant");
			Destroy(coll.gameObject);
		} 
	}

	void Attack()
	{
		startpos = plant.transform.position; 
		endpos = plant.transform.position + transform.up * moveDistance;
		
		currentLerpTime += Time.deltaTime;
		if (currentLerpTime > lerpTime) 
		{
			currentLerpTime = lerpTime;
		}
		
		float perc = currentLerpTime / lerpTime;
		plant.transform.position = Vector3.Lerp(startpos, endpos, perc);
		plant.transform.position = Vector3.Lerp(endpos, startpos, perc);
	}





}