using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject InstructionsPanel;

	public List<Image> images;

	public float imageFadeSpeed = 5.0f;

    private void Start()
    {
        InstructionsPanel.SetActive(false);
    }

    public void ShowInstructions()
    {
        InstructionsPanel.SetActive(true);   
    }

    public void StartGame()
	{
		this.StartCoroutine (this.StartGameCo());      
    }

	public IEnumerator StartGameCo()
	{
		this.gameObject.GetComponent<FadeScript> ().FadeImagesSimultaneously (images.ToArray(), false, imageFadeSpeed);


		InstructionsPanel.SetActive(false);
		SceneManager.LoadScene("LineDrawing");

		yield return null;
	}
}
