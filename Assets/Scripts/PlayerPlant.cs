using UnityEngine;
using System.Collections;

public class PlayerPlant : MonoBehaviour {
	
	public GameObject  plant;
	public Vector3     startpos;
	public Vector3     endpos;
	public float       moveDistance;
	public float       lerpTime;
	public float       currentLerpTime;
	public float       attackHeight;
	public float       startingHeight;
	public float       seconds;
	public bool        buttonPress;

	// Use this for initialization
	void Start () 
	{
		//startingHeight = transform.position.y;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) 
		{   
			if (buttonPress == false)
			{
			  plant = GameObject.FindGameObjectWithTag("player1");
			  startingHeight = plant.transform.position.y;
			  StartCoroutine("Attack");
			}


		} 
		else if (Input.GetButtonDown ("Fire2")) 
		{
			if (buttonPress == false)
			{
				plant = GameObject.FindGameObjectWithTag("player2");
				startingHeight = plant.transform.position.y;
				StartCoroutine("Attack");
			}
		} 
		else if (Input.GetButtonDown ("Fire3")) 
		{
			if (buttonPress == false)
			{
				plant = GameObject.FindGameObjectWithTag("player3");
				startingHeight = plant.transform.position.y;
				StartCoroutine("Attack");
			}
		}

	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		Mario mario = other.GetComponent<Mario>();
		if (mario != null)
			Destroy (mario);
	}

IEnumerator Attack()
{
	buttonPress = true;
	
	while (plant.transform.position.y < attackHeight) 
		{

			currentLerpTime = 0f;

			startpos = plant.transform.position; 
			endpos = plant.transform.position + transform.up * moveDistance;
		
			currentLerpTime += Time.deltaTime;
			if (currentLerpTime > lerpTime) {
				currentLerpTime = lerpTime;
			}
		
			float perc = currentLerpTime / lerpTime;
			plant.transform.position = Vector3.Lerp (startpos, endpos, perc);

			yield return null;
		}

		while (plant.transform.position.y > startingHeight) 
		{
			currentLerpTime = 0f;
			
			startpos = plant.transform.position; 
			endpos = plant.transform.position + -transform.up * moveDistance;
			
			currentLerpTime += Time.deltaTime;
			if (currentLerpTime > lerpTime) {
				currentLerpTime = lerpTime;
			}
			
			float perc = currentLerpTime / lerpTime;
			plant.transform.position = Vector3.Lerp (startpos, endpos, perc);
			yield return null;
		}

		buttonPress = false;
	}





}