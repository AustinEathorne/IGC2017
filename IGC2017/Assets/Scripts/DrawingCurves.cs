using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingCurves : MonoBehaviour
{
    public GameObject drawPrefab;
    GameObject thisLine;
    Vector3 startPosition;
    Plane objPlane;

    // Use this for initialization
    void Start()
    {
        objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) ||
                Input.GetMouseButtonDown(0))
        {
            thisLine = (GameObject)Instantiate(drawPrefab, this.transform.position, Quaternion.identity);

            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(myRay, out rayDistance))
            {
                startPosition = myRay.GetPoint(rayDistance);
            }
        }
        else if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) ||
            Input.GetMouseButton(0)))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(myRay, out rayDistance))
            {
                thisLine.transform.position = myRay.GetPoint(rayDistance);
            }
        }
        else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) ||
            Input.GetMouseButtonUp(0))
        {
            if (Vector3.Distance(thisLine.transform.position, startPosition) < 0.1f)
            {
                Destroy(thisLine);
            }
        }
    }
}
