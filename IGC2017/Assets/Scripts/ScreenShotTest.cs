using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenShotTest : MonoBehaviour 
{

	private string filePath = "Art/ScreenCaptures";
	private string captureName = "test";

	private int captureCount = 0;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log ("Capture");

			string path = Application.persistentDataPath + "/" + (captureCount++).ToString() + "/" + "kjfbjkfbjk.png";

			ScreenCapture.CaptureScreenshot (path);
		}
	}
}
