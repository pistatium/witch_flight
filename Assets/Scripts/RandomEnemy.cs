using UnityEngine;
using System.Collections;

public class RandomEnemy : BaseEnemy {

	public GameObject player;

	private int count = 0;
	public float speed = 0.5f;

	public void initFromScript(GameObject playerObject) {
		player = playerObject;
	}

	// Update is called once per frame
	void Update () {
		if (player == null) {
			return;
		}
		if (count++ % 400 == 0) {
			count = 0;
			Vector2 direct = (player.transform.position - transform.position).normalized;
			base.r2d.velocity = (direct + new Vector2 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f))).normalized * speed;
		}
	}
}
