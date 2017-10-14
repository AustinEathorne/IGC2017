using UnityEngine;


public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instanceObject;

	private static object lockObject = new object();

	public static T Instance
	{
		get
		{
			Debug.Log ("get");
			lock(lockObject)
			{
				Debug.Log ("lock");
				if(instanceObject == null)
				{
					instanceObject = (T)FindObjectOfType (typeof(T));

					if (FindObjectsOfType (typeof(T)).Length > 1) 
					{
						Debug.Log ("More than one " + typeof(T).ToString ());
						return instanceObject;
					}

					if (instanceObject == null) 
					{
						GameObject singleton = new GameObject ();
						instanceObject = singleton.AddComponent<T> ();

						MonoBehaviour.DontDestroyOnLoad (singleton);
					}
				}

				return instanceObject;
			}
		}
	}
}