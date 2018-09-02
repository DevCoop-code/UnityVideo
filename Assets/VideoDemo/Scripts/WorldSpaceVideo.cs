using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class WorldSpaceVideo : MonoBehaviour {

	public Material playButtonMaterial;
	public Material pauseButtonMaterial;
	public Renderer playButtonRenderer;
	public VideoClip[] videoClips;

	private VideoPlayer videoPlayer;
	private int videoClipIndex;

	void Awake(){
		videoPlayer = GetComponent<VideoPlayer> ();
	}
	// Use this for initialization
	void Start () {
		videoPlayer.clip = videoClips [0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayPause(){
		if (videoPlayer.isPlaying) 
		{
			videoPlayer.Pause ();
			playButtonRenderer.material = playButtonMaterial;
		} else 
		{
			videoPlayer.Play ();
			playButtonRenderer.material = pauseButtonMaterial;
		}
	}

	public void setNextClip(){
		videoClipIndex++;

		if (videoClipIndex >= videoClips.Length) {
			videoClipIndex = videoClipIndex % videoClips.Length;
		}

		videoPlayer.clip = videoClips [videoClipIndex];
		videoPlayer.Play ();
	}
}
