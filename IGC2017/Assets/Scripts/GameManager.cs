using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	[Header("Setup")]
	[SerializeField]
	private int selectedImage = 0;
	[SerializeField]
	private int paintingCount = 5;

	[Header("Drawing")]
	[SerializeField]
	private GameObject lineDrawer;
	[SerializeField]
	private GameObject colourPalette;

	private Color32 selectedColour;

	[Header("Timing")]
	[SerializeField]
	private float initialFadeSpeed = 3.0f;
	[SerializeField]
	private float imageFadeSpeed = 3.0f;

	[SerializeField]
	private float roundTime = 30.0f;

	[Header("Images")]
	[SerializeField]
	private Image scenePainting;
	[SerializeField]
	private Image scenePalette;

	[SerializeField]
	private List<Sprite> imageList1 = new List<Sprite>();
	[SerializeField]
	private List<Sprite> imageList2 = new List<Sprite>();
	[SerializeField]
	private List<Sprite> imageList3 = new List<Sprite>();
	[SerializeField]
	private List<Sprite> imageList4 = new List<Sprite>();
	[SerializeField]
	private List<Sprite> imageList5 = new List<Sprite>();

	[SerializeField]
	private Sprite pallete1;
	[SerializeField]
	private Sprite pallete2;
	[SerializeField]
	private Sprite pallete3;
	[SerializeField]
	private Sprite pallete4;
	[SerializeField]
	private Sprite pallete5;

	[Header("Utility")]
	[SerializeField]
	private FadeScript fadeScript;

	private DataHolder dataHolder;

	private IEnumerator Start()
	{
		dataHolder = GameObject.FindGameObjectWithTag ("DataHolder").GetComponent<DataHolder>();

		this.StartCoroutine (this.SetupGame());
		yield return null;
	}

	private IEnumerator SetupGame()
	{
		this.selectedImage = Random.Range (0, paintingCount);

		while(this.selectedImage == dataHolder.lastPainting)
		{
			this.selectedImage = Random.Range (0, paintingCount);

			yield return null;
		}

		Debug.Log ("Using painting " + this.selectedImage);



		//this.fadeScript.StartCoroutine(this.fadeScript.FadeImagesSimultaneously(, true, this.initialFadeSpeed);

		yield return null;
	}

	public void OpenPalette()
	{
		this.lineDrawer.SetActive (false);
		this.colourPalette.SetActive (true);

		lineDrawer.GetComponent<DrawingCurves> ().DestroyLastLine ();
	}

	public void ClosePalette()
	{
		this.lineDrawer.SetActive (true);
		this.colourPalette.SetActive (false);
	}

	public void SetSelectedColour(Color32 col)
	{
		this.selectedColour = col;
	}

	public Color32 GetSelectedColour()
	{
		return this.selectedColour;
	}
}
