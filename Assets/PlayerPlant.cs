using UnityEngine;
using System.Collections;

public class PlayerPlant : MonoBehaviour {
	
	public Rigidbody2D plant;
	public Vector3     startpos;
	public Vector3     endpos;
	public float       moveDistance;
	public float       lerpTime;
	public float       currentLerpTime;

	// Use this for initialization
	void Start () 
	{
		startpos = transform.position; 
		endpos = transform.position + transform.up * moveDistance;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetButtonDown("Fire1")) 
		{
			currentLerpTime = 0f;

			currentLerpTime += Time.deltaTime;
			if (currentLerpTime > lerpTime) 
			{
				currentLerpTime = lerpTime;
			}

			float perc = currentLerpTime / lerpTime;
			transform.position = Vector3.Lerp(startpos, endpos, perc);
			transform.position = Vector3.Lerp(endpos, startpos, perc);
		 }

	}
	void OnCollisionEnter2D(Collision2D coll) 
	{

		if (coll.gameObject.name == "Mario(Clone)") 
		{
			Debug.Log("Mario collided with plant");
			Destroy(coll.gameObject);
		} 
	}



}