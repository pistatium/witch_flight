﻿using UnityEngine;
using System.Collections;

public class FallEnemy : BaseEnemy {

	// Use this for initialization
	new public void Start () {
		transform.position = new Vector2(transform.position.x + Random.Range(-1f, 1f), transform.position.y);
	}
	
	// Update is called once per frame
	new public void Update () {
		base.Update ();
	}
}
