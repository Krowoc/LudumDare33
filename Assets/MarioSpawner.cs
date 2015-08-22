using UnityEngine;
using System.Collections;

public class MarioSpawner : MonoBehaviour {


	public GameObject Mario;
	public float      delayInSeconds;
	public bool       isActive= true;
	public float      decreaseInTime;
	public float      decreaseDelay;
	public float      increaseInTime;

	// Use this for initialization
	void Start () 
	{

		StartCoroutine ("Spawn");

	}
	
	// Update is called once per frame
	void Update () 
	{
		decreaseInTime -= Time.deltaTime;

		if (decreaseInTime <= 0) 
			{
			    decreaseInTime += increaseInTime;
				delayInSeconds -= decreaseDelay;
			}
	
	}

	IEnumerator Spawn()
	{
		while (isActive) 
		{
			GameObject mario = Instantiate(Resources.Load(Mario.name, typeof(GameObject))) as GameObject;
			mario.transform.position = transform.position;
			body_Mario.velocity = (Vector2.right * 10);


			yield return new WaitForSeconds(delayInSeconds);

		}
	}
}
