using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenShotTest : MonoBehaviour 
{

	private string filePath = "Art/ScreenCaptures";
	private string captureName = "test";

	private int captureCount = 0;

	[SerializeField]
	private DataHolder dataHolder;

	/*
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log ("Capture");

			string path = Application.persistentDataPath + "/" + (captureCount++).ToString() + "/" + "test.png";

			ScreenCapture.CaptureScreenshot (path);
		}
	}
	*/

	public void TakeScreenshot()
	{
		Debug.Log ("Capture");

		int temp = PlayerPrefs.GetInt ("captureCount");
		Debug.Log ("temp" + temp.ToString());

		string path = Application.persistentDataPath + "/" + "test" + temp.ToString() + ".png";

		temp++;

		PlayerPrefs.SetInt ("captureCount", temp);

		//Debug.Log (temp.ToString());

		ScreenCapture.CaptureScreenshot (path, 4);

		Debug.Log ("path: " + path);
	}
}
