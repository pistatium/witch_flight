﻿using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -8.0f) {
			Destroy(gameObject);
		}
	}
}
