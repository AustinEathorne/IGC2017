using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GalleryManager : MonoBehaviour 
{
	// Scene Refs
	[SerializeField]
	private Transform gridLayout;
	[SerializeField]
	private GameObject imagePrefab;


	// Path Shit
	private DirectoryInfo directoryInfo;
	private FileInfo[] fileInfo;
	private string path;
	private string imagePath;

	private void Start()
	{
		this.StartCoroutine (this.LoadGallery ());
	}

	public void StartLoad()
	{
		this.StartCoroutine (this.LoadGallery());
	}

	private IEnumerator LoadGallery()
	{
		path = Application.persistentDataPath;

		directoryInfo = new DirectoryInfo (path);
		fileInfo = directoryInfo.GetFiles ("*.png");

		foreach(FileInfo info in fileInfo)
		{
			imagePath = info.FullName;

			GameObject clone = Instantiate (imagePrefab, gridLayout.position, Quaternion.identity, gridLayout);

			WWW www = new WWW (imagePath);

			yield return www;

			Sprite tempSprite = Sprite.Create (www.texture, 
				new Rect(0, 0, www.texture.width, www.texture.height),
				new Vector2(0, 0));

			clone.GetComponent<Image> ().sprite = tempSprite;
		}

		yield return null;
	}

	public void ClearGallery()
	{
		path = Application.persistentDataPath;

		directoryInfo = new DirectoryInfo (path);
		fileInfo = directoryInfo.GetFiles ("*.png");

		foreach(FileInfo info in fileInfo)
		{
			Debug.Log (info.Name);

			info.Delete ();
		}
	}

	public void LoadMenuScene()
	{
		SceneManager.LoadScene ("Menu");
	}
}
