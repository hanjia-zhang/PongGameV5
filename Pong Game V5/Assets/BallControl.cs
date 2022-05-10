using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

	private Rigidbody2D rb2d;
	AudioSource Audio;

	void GoBall() {
		float rand = Random.Range (0, 2);
		if (rand < 1) {
			rb2d.AddForce (new Vector2 (15,-20));
		} else {
			rb2d.AddForce (new Vector2 (-15, -20));
		}
	}

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		Invoke ("GoBall", 2);
		Audio = GetComponent<AudioSource>();
	}

	void ResetBall() {
		rb2d.velocity = new Vector2 (0, 1.75f);
		transform.position = Vector2.zero;
	}

	void RestartGame() {
		ResetBall ();
		Invoke ("GoBall", 1);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.CompareTag ("Player")) {
			Vector2 vel;
			Audio.Play();
			vel.x = rb2d.velocity.x;
			vel.y = (rb2d.velocity.y/2) + (coll.collider.attachedRigidbody.velocity.y/3);
			rb2d.velocity = vel;
			
		}

		
	}

}
