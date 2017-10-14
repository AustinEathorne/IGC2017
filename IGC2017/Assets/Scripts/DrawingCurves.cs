using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingCurves : MonoBehaviour
{
    public GameObject drawPrefab;
    GameObject thisLine;
    Vector3 startPosition;
    Plane objPlane;
    public float zOffsetdForPlane = -1;

    [SerializeField]
	private GameManager gameManager;

	private GameObject lastLine;

	private bool isDrawing = false;

    // Use this for initialization
    void Start()
    {
        objPlane = new Plane(Camera.main.transform.forward * zOffsetdForPlane, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) ||
			Input.GetMouseButtonDown(0))
        {
			this.isDrawing = true;

            thisLine = (GameObject)Instantiate(drawPrefab, this.transform.position, Quaternion.identity);

			lastLine = thisLine;

            // Grab selected colour from the game manager
            this.thisLine.GetComponent<TrailRenderer>().material.color = gameManager.GetSelectedColour();
            this.thisLine.GetComponent<TrailRenderer>().material.SetColor("_Albedo", gameManager.GetSelectedColour());
            this.thisLine.GetComponent<TrailRenderer>().material.SetColor("_EmissionColor", gameManager.GetSelectedColour());

            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
			RaycastHit hit;
			if (objPlane.Raycast(myRay, out rayDistance))
            {
                startPosition = myRay.GetPoint(rayDistance);
            }
        }
        else if ((((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) ||
			Input.GetMouseButton(0))) && thisLine.gameObject != null)
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(myRay, out rayDistance))
            {
                thisLine.transform.position = myRay.GetPoint(rayDistance);
            }
        }
        else if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) ||
			Input.GetMouseButtonUp(0)) && thisLine.gameObject != null)
        {
            if (Vector3.Distance(thisLine.transform.position, startPosition) < 0.1f)
            {
				this.isDrawing = false;

                Destroy(thisLine);
            }
        }
    }

	public void DestroyLastLine()
	{
		Destroy (lastLine);
	}
}
