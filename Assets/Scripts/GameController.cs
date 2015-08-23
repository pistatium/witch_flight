using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameController : BaseGameController {

	private float start_time;

	public Camera cam;
	public Text scoreLabel;

	void Awake() {
		base.initAds ();
		base.setupWindow (cam);
	}

	// Use this for initialization
	void Start () {
		start_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		updateScore ();

		// Android BackKey 
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKey(KeyCode.Escape))
			{
				Application.Quit();
				return;
			}
		}
	}

	void updateScore() {
		float current_time = Time.time - start_time;
		int score = (int)(current_time * 10);
		scoreLabel.text = score.ToString ();
	}

}
