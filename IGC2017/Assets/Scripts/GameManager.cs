using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	private float firstFadeDelay = 1.0f;
	[SerializeField]
	private float drawTime = 30.0f;
	[SerializeField]
	private float initialFadeSpeed = 3.0f;
	[SerializeField]
	private float imageFadeSpeed = 3.0f;

	private float currentTimeLimit;

	[Header("Images")]
	[SerializeField]
	private List<Image> scenePainting;
	[SerializeField]
	private Image scenePalette;
	[SerializeField]
	private Image BG;

	[Header("Sprites")]
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

	[SerializeField]// why no list :(
	private Sprite pallete1;
	[SerializeField]
	private Sprite pallete2;
	[SerializeField]
	private Sprite pallete3;
	[SerializeField]
	private Sprite pallete4;
	[SerializeField]
	private Sprite pallete5;

	[SerializeField]
	private List<Sprite> BGs;

	[Header("Buttons")]
	[SerializeField]
	private GameObject finishButton;
	[SerializeField]
	private GameObject paletteButton;

	[Header("Utility")]
	[SerializeField]
	private FadeScript fadeScript;

	[Header("Text")]
	[SerializeField]
	private Text timeText;

    private DataHolder dataHolder;

    private bool isGessoSet;

    [SerializeField]
    private GameObject gessoButton;

	private float elapsedTime;
	private bool hasStarted = false;

	private IEnumerator Start()
	{
		dataHolder = GameObject.FindGameObjectWithTag ("DataHolder").GetComponent<DataHolder>();
        isGessoSet = false;
        gessoButton.SetActive(true);

		this.StartCoroutine (this.SetupGame());
		yield return null;
	}

	private void Update()
	{
		if(hasStarted)
		{
			currentTimeLimit -= Time.deltaTime;

			if(currentTimeLimit > 0.0f)
			{
				timeText.text = currentTimeLimit.ToString ("F0");
			}
		}
	}

	private IEnumerator SetupGame()
	{
		// Ensure images are transparent
		for (int i = 0; i < scenePainting.Count; i++)
		{
			Color col = Color.white;
			col.a = 0.0f;
			scenePainting [i].color = col;
		}

		// Choose random painting
		this.selectedImage = Random.Range (0, paintingCount);
		while(this.selectedImage == dataHolder.lastPainting)
		{
			this.selectedImage = Random.Range (0, paintingCount);

			yield return null;
		}
 
		dataHolder.lastPainting = this.selectedImage;
		// Debug.Log ("Using painting " + this.selectedImage);

		// pass scene images the appropriate sprites
		switch(selectedImage)
		{
		case 0:
			for(int i = 0; i < 4; i++)
			{
				scenePainting [i].sprite = imageList1 [i];
				scenePalette.sprite = pallete1;
				BG.sprite = BGs [0];
			}
			break;
		case 1:
			for(int i = 0; i < 4; i++)
			{
				scenePainting [i].sprite = imageList2 [i];
				scenePalette.sprite = pallete2;
				BG.sprite = BGs [1];
			}
			break;
		case 2:
			for(int i = 0; i < 4; i++)
			{
				scenePainting [i].sprite = imageList3 [i];
				scenePalette.sprite = pallete3;
				BG.sprite = BGs [2];
			}
			break;
		case 3:
			for(int i = 0; i < 4; i++)
			{
				scenePainting [i].sprite = imageList4 [i];
				scenePalette.sprite = pallete4;
				BG.sprite = BGs [3];
			}
			break;
		case 4:
			for(int i = 0; i < 4; i++)
			{
				scenePainting [i].sprite = imageList5 [i];
				scenePalette.sprite = pallete5;
				BG.sprite = BGs [4];
			}
			break;

		default:
			break;
		}


		// Fade images in
		yield return this.fadeScript.StartCoroutine(this.fadeScript.FadeImagesSimultaneously(scenePainting.ToArray(), true, this.initialFadeSpeed));

        yield return new WaitUntil(() => isGessoSet == true);
        //yield return new WaitForSeconds (this.firstFadeDelay);

        // Fade out desired images
        yield return this.StartCoroutine(this.FadePaintingPart(0));
		this.hasStarted = true;

		// Wait for round time
		this.currentTimeLimit = this.drawTime;
		yield return new WaitForSeconds(this.drawTime);

		// Fade out desired images
		yield return this.StartCoroutine(this.FadePaintingPart(3));

		// Wait for round time
		this.currentTimeLimit = this.drawTime;
		yield return new WaitForSeconds(this.drawTime);

		yield return this.StartCoroutine (this.FadePaintingPart(1));

		// Wait for round time
		this.currentTimeLimit = this.drawTime;
		yield return new WaitForSeconds(this.drawTime);

		yield return this.StartCoroutine (this.FadePaintingPart(2));

		// Turn off line drawing and enable button to finish
		this.lineDrawer.SetActive(false);
		this.finishButton.SetActive (true);
		this.paletteButton.SetActive (false);
	}

	private IEnumerator FadePaintingPart(int index)
	{
		yield return this.fadeScript.StartCoroutine(this.fadeScript.FadeImage(scenePainting[index], false, this.initialFadeSpeed));
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

	public void SetPaletteButtonActive()
	{
		this.paletteButton.SetActive (true);
	}

    public void SetGesso()
    {
        isGessoSet = true;
        gessoButton.SetActive(false);
    }

	public void LoadMenuScene()
	{
		timeText.gameObject.SetActive (false);
		finishButton.gameObject.SetActive (false);

		SceneManager.LoadScene ("Gallery");
	}

}
