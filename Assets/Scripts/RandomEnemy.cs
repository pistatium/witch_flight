using UnityEngine;
using System.Collections;

public class RandomEnemy : BaseEnemy {

	public GameObject player;

	private int count = 0;
	public float speed = 0.1f;
	private Vector2 direct = new Vector2 (0, 0);

	public void initFromScript(GameObject playerObject) {
		player = playerObject;
	}

	// Update is called once per frame
	void Update () {
		if (player == null) {
			return;
		}
		count++;

		if (count % 100 == 0) {
			//count = 0;
			Vector2 toPlayer = (player.transform.position - transform.position).normalized;
			direct = (toPlayer + new Vector2 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f))).normalized * speed;
		}
		base.r2d.velocity = base.r2d.velocity * 0.8f + direct;
	}
}
