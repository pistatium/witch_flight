using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseEnemy : MonoBehaviour {

	protected Rigidbody2D r2d;

	public void Start() {
		r2d = GetComponent<Rigidbody2D> ();
	}

	public void Update () {
		checkAndDestroy (transform.position);	
	}

	void checkAndDestroy(Vector3 position) {
		if (position.y < -7.0f || Mathf.Abs (position.x) > 6.0f) {
			Destroy(gameObject);
		}
	}
}
