using UnityEngine;
using System.Collections;

public class ScreenShotBridge 
{
	static string path = "com.plugin.screenshot.ScreenShotPlugin";
	public delegate void ScreenShotDelegate(bool screenShotStatus);

	static public string getCapturePath(string fileName) {
		if (Application.platform == RuntimePlatform.Android) {
			return moveScreenShotToShare(fileName);
		} else {
			return Application.persistentDataPath + "/" + fileName;
		}
	}

	public static IEnumerator saveScreenShot(string fileName, ScreenShotDelegate callBack) {
		Application.CaptureScreenshot (fileName);
		yield return new WaitForEndOfFrame ();
		callBack(true);
	}

	private static string moveScreenShotToShare(string fileName) {
		#if UNITY_ANDROID
		string origin = System.IO.Path.Combine (Application.persistentDataPath, fileName);
		string destination = "/sdcard/witch_flight/" + fileName;
		if (!System.IO.Directory.Exists ("/sdcard/witch_flight")) {
			System.IO.Directory.CreateDirectory ("/sdcard/witch_flight");
		}
		if (System.IO.File.Exists (origin)) {
			if (System.IO.File.Exists(destination)) {
				System.IO.File.Delete(destination);
			}
			System.IO.File.Move (origin, destination);
			AndroidJavaClass playerClass = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
			AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject> ("currentActivity");		
			AndroidJavaClass pluginClass = new AndroidJavaClass (path);
			pluginClass.CallStatic ("RefreshGallery", new object[2] {activity, destination});
		}
		return destination;
		#endif
		return "";
	}
}
