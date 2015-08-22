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
	new void Update () {
		if (player == null) {
			return;
		}
		base.Update ();

		count++;

		if (count % 60 == 1) {
			Vector2 toPlayer = (player.transform.position - transform.position);
			direct = (toPlayer + new Vector2 (Random.Range (-0.5f, 0.5f), Random.Range (-0.5f, 0.5f))).normalized * speed * Time.deltaTime;
		}
		base.r2d.velocity = base.r2d.velocity * 0.8f + direct;
	}
}
