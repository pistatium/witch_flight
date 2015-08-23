using UnityEngine;
using System.Collections;

public class HomeController : BaseGameController {

	public Camera cam;

	void Start () {
		setupWindow (cam);
	}
	
	void Update () {
	
	}

	public void onClickStart() {
		Application.LoadLevel ("Main");
	}
}
