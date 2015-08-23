using UnityEngine;
using System.Collections;

public class MarioSpawner : MonoBehaviour {


	public string prefabName;
	public float      delayInSeconds;
	//public bool       isActive= true;
	//public float      decreaseInTime;
	public float      decreaseDelay;
	//public float      increaseInTime;

	// Use this for initialization
	void Start () 
	{

		StartCoroutine ("Spawn");
		//increaseInTime = decreaseInTime;

	}
	
	// Update is called once per frame
	void Update () 
	{
		//Decrease the seconds in with to decrease the delay time
		/*decreaseInTime -= Time.deltaTime;

		//Decreases the delay time and resets decrease in Time;
		if (decreaseInTime <= 0) 
			{
			    decreaseInTime += increaseInTime;
				//delayInSeconds -= decreaseDelay;
			}*/
	
	}

	IEnumerator Spawn()
	{
		while (true) 
		{
			GameObject mario = Instantiate(Resources.Load(prefabName, typeof(GameObject))) as GameObject;
			mario.transform.position = transform.position;


			yield return new WaitForSeconds(delayInSeconds);

			delayInSeconds -= decreaseDelay;
		}
	}
}
