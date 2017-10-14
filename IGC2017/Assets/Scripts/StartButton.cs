using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject InstructionsPanel;

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
        InstructionsPanel.SetActive(false);
        SceneManager.LoadScene("LineDrawing");        
    }
}
