using UnityEngine;
using System.Collections;

public class RandomEnemy : BaseEnemy {

	public GameObject player;

	private int count = 0;

	// Update is called once per frame
	void Update () {
		if (count++ % 15 == 0) {
			Vector2 direct = (player.transform.position - transform.position).normalized;
			base.r2d.velocity = direct + new Vector2 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f));
		}
	}
}
