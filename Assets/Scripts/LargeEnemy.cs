using UnityEngine;
using System.Collections;

public class LargeEnemy : BaseEnemy {
	
	// Use this for initialization
	public void Start () {
		transform.position = new Vector2(transform.position.x + Random.Range(-3f, 3f), transform.position.y);
	}
	
	// Update is called once per frame
	public void Update () {
		base.Update ();
		
	}
}
