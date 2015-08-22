using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private float start_time;
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
