using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class WorldSpaceVideo : MonoBehaviour {

	public Material playButtonMaterial;
	public Material pauseButtonMaterial;
	public Renderer playButtonRenderer;

	private VideoPlayer videoPlayer;

	void Awake(){
		videoPlayer = GetComponent<VideoPlayer> ();
	}
	// Use this for initialization
	void Start () {
		
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
}
