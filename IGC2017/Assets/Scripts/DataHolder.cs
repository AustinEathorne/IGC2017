using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : Singleton<DataHolder>
{
	private static DataHolder instance = null;

	public int lastPainting = 0;

	public static DataHolder Instance
	{
		get
		{
			return instance;
		}
	}

	public void Awake()
	{
		if(instance != null && instance != this)
		{
			Destroy (this.gameObject);
		}

		instance = this;
		DontDestroyOnLoad (this);
	}
}
