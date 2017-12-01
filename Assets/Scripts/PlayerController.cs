using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

	public float walkSpeed = 5;
	public float jumpSpeed = 350;
	public Vector2 velocity;
	public GameObject gameOver;
	public GameObject buttonRestart;

	private Rigidbody2D body;
	private Collider2D coll;
	private SpriteRenderer spriteRenderer;
	private bool facingRight = true;
	private bool playerDead = false;

	void Start ()
	{
		body = GetComponent<Rigidbody2D> ();
		coll = GetComponent<Collider2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		gameOver.SetActive (false);
		buttonRestart.SetActive (false);
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Jump") && coll.GetContacts (GameObject.FindWithTag ("Cenario").GetComponents<Collider2D> ()) == 1) {
			body.AddForce (Vector2.up * jumpSpeed);
		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		if (moveHorizontal > 0.0f && !facingRight) {
			flipPlayer ();
		}
		if (moveHorizontal < 0.0f && facingRight) {
			flipPlayer ();
		}
		velocity = new Vector2 (moveHorizontal * walkSpeed, body.velocity.y);
	}

	void FixedUpdate ()
	{
		body.velocity = velocity;
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		gameOver.SetActive (true);
		buttonRestart.SetActive (true);
		playerDead = true;
		Time.timeScale = 0;
	}

	void flipPlayer ()
	{
		spriteRenderer.flipX = !spriteRenderer.flipX;
		facingRight = !facingRight;
	}
}
