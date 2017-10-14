using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager> 
{
	private static AudioManager instance = null;

	public static AudioManager Instance
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
