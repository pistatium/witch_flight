using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HomeController : BaseGameController {

	public Camera cam;
	public Text scoreLabel;
	void Start () {
		setupWindow (cam);
		int highScore = new ScoreManager ().getHighScore ();
		scoreLabel.text = "HighScore: " + highScore;
	}
	
	void Update () {
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

	public void onClickStart() {
		Application.LoadLevel ("Main");
	}
}
