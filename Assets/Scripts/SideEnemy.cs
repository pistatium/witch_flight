using UnityEngine;
using System.Collections;

public class SideEnemy :BaseEnemy {

	private bool toRight = false; 
	public float speed = 0.3f;

	// Use this for initialization
	new public void Start () {
		base.Start ();
		float randX = Random.Range (-0.3f, -0.3f);
		float randY = Random.Range (-4.0f, 0.0f);
		toRight = (randX > 0);
		if (toRight) {
			transform.position = new Vector2 (transform.position.x + randX, randY);
		} else {
			transform.position = new Vector2 (-transform.position.x + randX, randY);
		}
	}
	
	// Update is called once per frame
	new public void Update () {
		base.Update ();
		if (toRight) {
			base.r2d.velocity = new Vector2 (2, -0.5f) * speed * Time.deltaTime;
		} else {
			base.r2d.velocity = new Vector2 (-2, -0.5f) * speed * Time.deltaTime;
		}
	}
}
