using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour {

	public string button;

	public float attackHeight = 5.0f;
	public float attackSpeed = 0.1f;
	public float retractSpeed = 10.0f;

	Vector2 attackingPosition;
	Vector2 startingPosition;

	float close = 0.3f;

	bool isAttacking = false;

	// Use this for initialization
	void Start () {

		startingPosition = transform.position;
		attackingPosition = transform.position;
		attackingPosition.y += attackHeight;

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown (button) && !isAttacking)
		{
			StartCoroutine (Attack ());
		}
	}

	IEnumerator Attack()
	{
		isAttacking = true;

		float t = 0.0f;

		while(transform.position.y < attackingPosition.y)
		{
			transform.position = Vector2.Lerp (startingPosition, attackingPosition, t += attackSpeed);
				
			yield return null;
		}
		
		while(transform.position.y > startingPosition.y + close)
		{
			transform.position = Vector2.Lerp (transform.position, startingPosition, Time.deltaTime * retractSpeed);
				
			yield return null;
		}

		isAttacking = false;
	}
}
