using UnityEngine;
using System.Collections;

public class MarioSpawner : MonoBehaviour {


	public GameObject Mario;
	public float delayInSeconds;
	public bool isActive = true;

	// Use this for initialization
	void Start () 
	{

		StartCoroutine ("Spawn");

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	IEnumerator Spawn()
	{
		while (isActive) 
		{
			GameObject mario = Instantiate(Resources.Load(Mario.name, typeof(GameObject))) as GameObject;
			mario.transform.position = transform.position;

			yield return new WaitForSeconds(delayInSeconds);

		}
	}
}
