using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

	private bool isInArea = true;
	public Rigidbody2D r2d;
	public float speed = 1.0f;
	private float angle;
	private float angleDirection = 1.0f;
	private float angleSpeed = 1.0f;
	private float maxAngle = 10.0f;

	// Use this for initialization
	void Start () {
		r2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float originalAngle = angle;

		if (-maxAngle < angle && angle < maxAngle) {
			angle += angleDirection * 0.8f;
		} else {
			// Switch Back
			angle = (maxAngle - angleSpeed) * angleDirection;
			angleDirection *= -1.0f;
			originalAngle = angle;
		}

		float rad = Mathf.Deg2Rad * angle * 3.0f;
		if (Input.GetMouseButton (0)) {
			r2d.velocity = new Vector2(-Mathf.Sin(rad) * 5.0f, speed);
			angle = originalAngle;
		} else {
			r2d.velocity = new Vector2(0, -speed * 0.5f);
		}

		transform.localRotation = Quaternion.Euler (0.0f, 0.0f, angle);
	}

	void OnTriggerEnter2D(Collider2D c){
		isInArea = true;
	}

	float range(float x, float max, float min) {
		if (max > x) {
			return max;
		}
		if (min < x) {
			return min;
		}
		return x;
	}


	void OnTriggerExit2D(Collider2D c){
		isInArea = false;
	}
}
