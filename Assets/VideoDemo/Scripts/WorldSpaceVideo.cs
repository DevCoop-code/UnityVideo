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

	public Text currentMinutes;
	public Text currentSeconds;
	public Text totalMinutes;
	public Text totalSeconds;

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
		if (videoPlayer.isPlaying) {
			SetCurrentTimeUI ();
		}
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
		SetTotalTimeUI ();
		videoPlayer.Play ();
	}

	void SetCurrentTimeUI(){
		string minutes = Mathf.Floor ((int)videoPlayer.time / 60).ToString ("00");
		string seconds = ((int)videoPlayer.time % 60).ToString ("00");

		currentMinutes.text = minutes;
		currentSeconds.text = seconds;
	}

	void SetTotalTimeUI(){
		string minutes = Mathf.Floor ((int)videoPlayer.clip.length / 60).ToString ("00");
		string seconds = ((int)videoPlayer.clip.length % 60).ToString ("00");

		totalMinutes.text = minutes;
		totalSeconds.text = seconds;
	}
}
