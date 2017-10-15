using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager> 
{
	private static AudioManager instance = null;

    private AudioSource clipToPlay;

    [SerializeField]
    private AudioClip OnStartClip;
    [SerializeField]
    private AudioClip OnRaceModeClip;
    [SerializeField]
    private AudioClip OnEndClick;

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

    public void Start()
    {
        clipToPlay = GetComponentInChildren<AudioSource>();
    }

    public void PlayStartClip()
    {
        clipToPlay.clip = OnStartClip;
        clipToPlay.Play();
    }

    public void PlayRaceModeClip()
    {
        clipToPlay.clip = OnRaceModeClip;
        clipToPlay.Play();
    }

    public void PlayEndClip()
    {
        clipToPlay.clip = OnEndClick;
        clipToPlay.Play();
    }
}
