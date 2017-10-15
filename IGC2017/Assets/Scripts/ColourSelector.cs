using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class ColourSelector : MonoBehaviour {
	
	[SerializeField]
	private Camera cam;
	[SerializeField]
	private Canvas canvas;
	[SerializeField]
	private GameManager gameManager;


	private Color32 selectedColour;

	private PointerEventData pointerEventData;

	private void Awake()
	{
		this.selectedColour = Color.white;
		pointerEventData = new PointerEventData(canvas.GetComponent<EventSystem>());
	}

	private void Update()
	{
		this.RayCastUI();
	}

	private void RayCastUI()
	{
		if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
		{
			if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
				pointerEventData.position = Input.mousePosition;
			else 
				pointerEventData.position = (Vector3)Input.GetTouch(0).position;


			pointerEventData.position = Input.mousePosition;

			List<RaycastResult> objectsHit = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData, objectsHit);

			if(objectsHit.Count > 0)
			{
				foreach (RaycastResult hit in objectsHit)
				{
					if (hit.gameObject.tag == "ColourPalette")
					{
						// get texture and bounding rectangle
						Texture2D tex = hit.gameObject.GetComponent<Image>().sprite.texture;
						Rect rect = hit.gameObject.GetComponent<RectTransform>().rect;
						Vector2 localPoint;

						// get hit point
						RectTransformUtility.ScreenPointToLocalPointInRectangle(hit.gameObject.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out localPoint);

						// convert hit point to texture coordinates
						int x = (int)(localPoint.x + (rect.width/2));
						int y = (int)(localPoint.y + (rect.height/2));

						// get pixel colour at hit point & change skin colour
						selectedColour = hit.gameObject.GetComponent<Image>().sprite.texture.GetPixel(x, y);
						gameManager.ClosePalette ();
						gameManager.SetSelectedColour (this.selectedColour);

						gameManager.SetPaletteButtonActive ();

						/*
						Debug.Log("name:" + hit.gameObject.name);
						Debug.Log("hitPos: " + localPoint.x + ", " + localPoint.y);
						Debug.Log("pixelPos: " + x + ", " + y);
						Debug.Log("col: " + selectedColour);
						*/
					}
				}
				objectsHit.Clear();
			}
		}
	}
}
