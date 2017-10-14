using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
	// Fade Images Simultaneously
	public IEnumerator FadeImagesSimultaneously(Image[] images, bool isFadingIn, float fadeSpeed)
	{
		float tempAlpha;

		if (isFadingIn) {
			tempAlpha = images [0].color.a;

			while (tempAlpha <= 0.99f) {
				tempAlpha = Mathf.MoveTowards (tempAlpha, 1.0f, fadeSpeed * Time.deltaTime);

				foreach (Image image in images) {
					image.color = new Color (image.color.r, image.color.g, image.color.b, tempAlpha);
				}

				yield return null;
			}

		} else {
			tempAlpha = images [0].color.a;

			while (tempAlpha >= 0.01f) {
				tempAlpha = Mathf.MoveTowards (tempAlpha, 0.0f, fadeSpeed * Time.deltaTime);

				foreach (Image image in images) {
					image.color = new Color (image.color.r, image.color.g, image.color.b, tempAlpha);
				}

				yield return null;
			}

			yield return null;
		}
	}
}