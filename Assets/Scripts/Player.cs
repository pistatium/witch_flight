using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

	public Rigidbody2D r2d;
	public Animator anim;
	public GameObject splite;
	public GameController gameController;
	public float speed = 1.0f;
	private float angle;
	private float angleDirection = 1.0f;
	public float angleSpeed = 1.0f;
	private float maxAngle = 10.0f;

	// Use this for initialization
	void Start () {
		r2d = GetComponent<Rigidbody2D> ();
		anim = splite.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float originalAngle = angle;

		if (-maxAngle < angle && angle < maxAngle) {
			angle += angleDirection * angleSpeed * Time.deltaTime;
		} else {
			// Switch Back
			angle = (maxAngle - angleSpeed * Time.deltaTime) * angleDirection;
			angleDirection *= -1.0f;
			originalAngle = angle;
		}

		float rad = Mathf.Deg2Rad * angle * 3.0f;
		if (Input.GetMouseButton (0)) {
			r2d.velocity = new Vector2(-Mathf.Sin(rad * 3.0f), 0.4f).normalized * speed;
			angle = originalAngle;
			anim.SetBool("is_dash", true);
		} else {
			if (transform.position.y >= -4.0f) {
				r2d.velocity = new Vector2(0, -1) * speed * 0.3f;
			} else {
				r2d.velocity = new Vector2(0, 0);
			}
			anim.SetBool("is_dash", false);
		}

		transform.localRotation = Quaternion.Euler (0.0f, 0.0f, angle);
		float x = transform.position.x;

		if (x < -3.3 || 3.3 < x) {
			dead ();
		}
		if (transform.position.y > 4.5f) {
			transform.position = new Vector2(transform.position.x, transform.position.y * 0.97f);
		}
	}
	
	void OnTriggerEnter2D(Collider2D c){
		dead ();
	}

	float range(float x, float max, float min) {
		if (max > x) {
			return max;
		}		if (min < x) {
			return min;
		}
		return x;
	}

	void dead() {
		//  Capture Display on player dying.
		enabled = false;
		StartCoroutine(ScreenShotBridge.saveScreenShot("capture.png", afterCapture));
	}

	void afterCapture(bool isSuccess) {
		gameController.gameover ();
		Destroy (gameObject);
	}
	
}
