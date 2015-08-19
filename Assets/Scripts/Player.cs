using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

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
			r2d.velocity = new Vector2(-Mathf.Sin(rad * 3.0f), 0.4f).normalized * speed;
			angle = originalAngle;
		} else {
			if (transform.position.y >= -4.0f) {
				r2d.velocity = new Vector2(0, -1) * (speed * 0.5f);
			} else {
				r2d.velocity = new Vector2(0, 0);
			}
		}

		transform.localRotation = Quaternion.Euler (0.0f, 0.0f, angle);
		float x = transform.position.x;
		if (x < -3.0 || 3.0 < x) {
			transform.position = new Vector2(x * 0.97f, transform.position.y);
		}
	}
	
	void OnTriggerEnter2D(Collider2D c){
		//Application.LoadLevel ("Main");
		Invoke("Reload", 1.5f);
		Destroy (gameObject);
	}

	void Reload() {
		Application.LoadLevel ("Main");
		Debug.Log("Delay call");
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
	}
}
