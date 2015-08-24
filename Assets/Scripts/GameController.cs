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

	public void onClickShare() {
		StartCoroutine(share ());
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
		//Destroy (gameObject);

	}

	IEnumerator share() {
		Application.CaptureScreenshot ("screenShot.png");		
		yield return new WaitForSeconds (1.0f);
		string text = "シェアする内容";
		string url = "http://google.com/";
		string texture_url = Application.persistentDataPath + "/screenShot.png";		
		SocialConnector.Share (text, url, texture_url);
	}


}
