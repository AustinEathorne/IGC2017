using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	[SerializeField]
	private GameObject lineDrawer;

	[SerializeField]
	private GameObject colourPalette;

	private Color32 selectedColour;

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
