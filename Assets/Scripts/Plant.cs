using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour {

	public string button;

	public float life = 100f;
	public float lifeDrain = 0.05f;
	public float marioHealth = 20f;

	public float attackHeight = 5.0f;
	public float attackSpeed = 0.1f;
	public float retractSpeed = 10.0f;

	Vector2 attackingPosition;
	Vector2 startingPosition;

	float close = 0.3f;

	bool isAttacking = false;

	AudioSource[] sounds;

	Animator anim;

	// Use this for initialization
	void Start () {

		startingPosition = transform.position;
		attackingPosition = transform.position;
		attackingPosition.y += attackHeight;

		sounds = GetComponents<AudioSource>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (life > 0)
		{
			life -= lifeDrain;
			anim.SetFloat ("life", life);

			if(life <= 0)
			{
				Die ();
			}
			else if(Input.GetButtonDown (button) && !isAttacking)
			{
				StartCoroutine (Attack ());
			}
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

	void Die()
	{
		sounds[1].Play ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		sounds[0].Play ();
		
		Mario mario = other.GetComponent<Mario>();
		
		if(mario != null)
		{
			//mario.transform.SetParent (gameObject.transform);
			mario.Die ();

			life += marioHealth;

		}
		
		
	}
}
