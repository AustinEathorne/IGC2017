using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheDude : MonoBehaviour {

	[SerializeField]
	private float moveSpeed = 5.0f;

	[SerializeField]
	private float waitTime = 2.0f;

	[SerializeField]
	private Transform point1;

	[SerializeField]
	private Transform point2;



	public void CallMove()
	{
		this.StartCoroutine (this.Move ());
	}

	private IEnumerator Move()
	{
		while(Vector3.Distance(this.transform.localPosition, point1.localPosition) >= 0.5f)
		{
			this.transform.localPosition = Vector3.MoveTowards (this.transform.localPosition, point1.transform.localPosition, Time.deltaTime * moveSpeed);
			yield return null;
		}

		yield return new WaitForSeconds(waitTime);

		while(Vector3.Distance(this.transform.localPosition, point2.localPosition) >= 0.5f)
		{
			this.transform.localPosition = Vector3.MoveTowards (this.transform.localPosition, point2.transform.localPosition, Time.deltaTime * moveSpeed);
			yield return null;
		}

		yield return null;
	}
}
