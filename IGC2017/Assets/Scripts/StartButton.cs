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
<<<<<<< HEAD
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
=======
    {
        InstructionsPanel.SetActive(false);
        SceneManager.LoadScene("LineDrawing");  
        
        //while (true)
        //{            
        //    setPeeps();            
        //}
    }
    //static void setPeeps()
    //{
    //    string ian;
    //    string mack = "ENDO GAMEZZZ FOR LIFE";        
    //    ian = "coolest";
    //    while (ian == "coolest")
    //    {
    //        mack = "Baby Enzo";
    //    }

    //    if (mack == "Baby Enzo")
    //    {
    //        Debug.Log("wooooooooooooooooooooooooooooooooooooooo!");
    //    }

    //}


>>>>>>> a42c0e2de7304c41125e2545a43b023b4b161d85
}
