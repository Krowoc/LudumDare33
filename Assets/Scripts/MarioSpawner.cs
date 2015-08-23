using UnityEngine;
using System.Collections;

public class MarioSpawner : MonoBehaviour {


	public string     prefabName;
	public float      delayInSeconds;
	public float      decreaseDelay;

	public GameObject marioPrefab;

	// Use this for initialization
	void Start () 
	{

		marioPrefab = Resources.Load<GameObject> (prefabName);

		StartCoroutine ("Spawn");
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	IEnumerator Spawn()
	{
		while (true) 
		{
			SpawnMario();

			yield return new WaitForSeconds(delayInSeconds);

			DecreaseDelay ();
		}
	}

	public void SpawnMario()
	{
		GameObject mario = Instantiate<GameObject>(marioPrefab);
		mario.transform.position = transform.position;

	}

	public void DecreaseDelay()
	{
		delayInSeconds -= decreaseDelay;

		if(delayInSeconds < 0.0f)
			delayInSeconds = 0.0f;
	}

	public void IncreaseDelay()
	{
		delayInSeconds += decreaseDelay;
	}
}
