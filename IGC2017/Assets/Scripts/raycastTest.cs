using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastTest : MonoBehaviour {

	[SerializeField]
	private Transform cubeTransform;

	Vector3 hitLocation;

	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit))
			{
				hitLocation = ray.GetPoint (hit.distance);
				Debug.Log (hitLocation);
			}
		}

		cubeTransform.position = Vector3.MoveTowards(cubeTransform.position, hitLocation, Time.deltaTime * 5.0f);
	}



}
