using UnityEngine;
using System.Collections;

public class ScreenShotBridge 
{
	static string path = "com.plugin.screenshot.ScreenShotPlugin";
	public delegate void ScreenShotDelegate(bool screenShotStatus);

	static public string getCapturePath(string fileName) {
		if (Application.platform == RuntimePlatform.Android) {
			return "/sdcard/witch_flight/" + fileName;
		} else {
			return Application.persistentDataPath + "/" + fileName;
		}
	}

	public static IEnumerator SaveScreenShot(string fileName,bool isScreenShotWithDateTime,ScreenShotDelegate callBack)
	{
		yield return new WaitForEndOfFrame ();
		Application.CaptureScreenshot (fileName+".png");
		if (Application.platform == RuntimePlatform.Android) {
			#if UNITY_ANDROID
			string origin = System.IO.Path.Combine (Application.persistentDataPath, fileName + ".png");
			string destination = getCapturePath(fileName);
			if (!System.IO.Directory.Exists ("/sdcard/witch_flight")) {
					System.IO.Directory.CreateDirectory (destination);
			}
			if (System.IO.File.Exists (origin)) {
				System.IO.File.Move (origin, destination);
				AndroidJavaClass playerClass = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
				AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject> ("currentActivity");		
				AndroidJavaClass pluginClass = new AndroidJavaClass (path);
				pluginClass.CallStatic ("RefreshGallery", new object[2] {activity, destination});
			}
			#endif
		}
		callBack(true);

	}
}
