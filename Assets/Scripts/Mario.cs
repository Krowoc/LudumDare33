using UnityEngine;
using System.Collections;

public class Mario : MonoBehaviour {

	public float speed = 1.0f;
	public float maxSpeed = 40.0f;

	public bool onGround;

	Rigidbody2D rigidBody;

	GameObject groundCheck;

	// Use this for initialization
	void Start () {

		rigidBody = GetComponent<Rigidbody2D>();

		groundCheck = transform.Find ("GroundCheck").gameObject;

	}
	
	// Update is called once per frame
	void Update () {

		onGround = Physics2D.Raycast (groundCheck.transform.position, Vector2.down, 1.0f);

		Run ();
	}

	public void Run ()
	{
		rigidBody.AddForce (new Vector2(speed, 0f));

		rigidBody.velocity = Vector2.ClampMagnitude (rigidBody.velocity, maxSpeed);
	}

}
