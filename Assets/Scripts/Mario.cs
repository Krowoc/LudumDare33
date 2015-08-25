using UnityEngine;
using System.Collections;

public class Mario : MonoBehaviour {

	public float speed = 50.0f;
	public float maxSpeed = 8.0f;

	public float jumpForce = 20.0f;

	public bool onGround;

	Rigidbody2D rigidBody;

	AudioSource sound;

	GameObject groundCheck;

	Vector3 lastPosition = Vector2.zero;
	Quaternion originalRotation;
	int stuck;

	// Use this for initialization
	void Start () {

		rigidBody = GetComponent<Rigidbody2D>();
		sound = GameObject.Find ("Sound").GetComponent<AudioSource>();

		groundCheck = transform.Find ("GroundCheck").gameObject;

		originalRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		onGround = GroundTest();

		if(onGround)
			Run ();

	}

	void Update()
	{
		if(lastPosition == transform.position)
		{
			if(stuck++ == 150)
			{
				//stuck = 0;
				//lastPosition = transform.position;
				//transform.rotation = originalRotation;
				Destroy (gameObject);
			}

		}
		else
			lastPosition = transform.position;
	}

	bool GroundTest()
	{
		return Physics2D.Raycast (groundCheck.transform.position, Vector2.down, 0.1f);
	}

	public void Run ()
	{
		rigidBody.AddForce (new Vector2(speed, 0f));

		Vector2 newVelocity = rigidBody.velocity;

		newVelocity.x = Mathf.Clamp (newVelocity.x, 0f, maxSpeed);

		rigidBody.velocity = newVelocity;
	}

	public void Jump()
	{
		if(onGround)
		{
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);//
		}
	}

	public void Die()
	{
		if(!sound.isPlaying)
			sound.Play ();

		//ScoreCounter.instance().marioEaten ();
		ScoreManager.marioEaten ();

		Destroy (gameObject);

	}

}
