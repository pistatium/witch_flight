using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class GameController : BaseGameController {

	private float start_time;

	public Camera cam;
	public Text scoreLabel;
	public Text finalLabel;
	public Image gameOverPanel;

	void Awake() {
		base.initAds ();
		base.setupWindow (cam);
		gameOverPanel.transform.localScale = Vector3.zero;
	}

	void Start () {
		start_time = Time.time;
	}
	
	void Update () {
		updateScore ();

		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKey(KeyCode.Escape))
			{
				Application.LoadLevel ("HomeScene");
				return;
			}
		}
	}

	void updateScore() {
		float current_time = Time.time - start_time;
		int score = (int)(current_time * 10);
		scoreLabel.text = score.ToString ();
	}

	public void onClickShare() {
		share();
	}

	public void onClickHome() {
		Application.LoadLevel ("HomeScene");
	}
	public void onClickPlay() {
		Application.LoadLevel ("Main");
	}

	public void gameover() {
		string finalScore = scoreLabel.text;
		scoreLabel.enabled = false;
		finalLabel.text = "Score: " + finalScore;
		gameOverPanel.transform.localScale = new Vector3(1, 1, 0);
		if(Advertisement.isReady ()) {
			//			Advertisement.Show(null, new ShowOptions {
			//				pause = true,
			//				resultCallback = result => {
			//					Application.LoadLevel ("Main");
			//				}
			//			});
		}
	}

	void share() {
		string text = "#WitchFlight";
		string url = "";
		string texture_url = ScreenShotBridge.getCapturePath ("capture.png");		
		SocialConnector.Share (text, url, texture_url);
	}


}
