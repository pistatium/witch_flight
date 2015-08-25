using UnityEngine;
using System.Collections;

public class HomeController : BaseGameController {

	public Camera cam;

	void Start () {
		setupWindow (cam);
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
