using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class GameController : MonoBehaviour {

	private float start_time;

	public Camera cam;
	private float width = 640f;
	private float height = 960f;
	private float pixelPerUnit = 100f;

	void Awake() {
		if (Advertisement.isSupported) {
			Advertisement.allowPrecache = true;
			Advertisement.Initialize ("64783"); //Movie
		} else {
			Debug.Log("Platform not supported");
		}

		float aspect = (float)Screen.height / (float)Screen.width;
		float bgAcpect = height / width;

		// カメラのorthographicSizeを設定
		cam.orthographicSize = (height / 2f / pixelPerUnit);
		
		
		if (bgAcpect > aspect) {
			// 倍率
			float bgScale = height / Screen.height;
			// viewport rectの幅
			float camWidth = width / (Screen.width * bgScale);
			// viewportRectを設定
			cam.rect = new Rect ((1f - camWidth) / 2f, 0f, camWidth, 1f);
		} else {
			// 倍率
			float bgScale = width / Screen.width;
			// viewport rectの幅
			float camHeight = height / (Screen.height * bgScale);
			// viewportRectを設定
			cam.rect = new Rect (0f, (1f - camHeight) / 2f, 1f, camHeight);
		}

	}

	// Use this for initialization
	void Start () {
		start_time = Time.time;
	}
	
	// Update is called once per frame
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

	void OnGUI () {
		float current_time = Time.time - start_time;
		int score = (int)(current_time * 10);
		GUI.Label(new Rect(20, 20, 100, 50), "Score:" + score.ToString());
	
	}

}
