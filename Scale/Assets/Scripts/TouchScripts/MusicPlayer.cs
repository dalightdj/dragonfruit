using UnityEngine;
using System.Collections;


//class for playing music in game.
public class MusicPlayer : MonoBehaviour {
	//audio source to play from. dragon and drop in editor.
	public AudioSource source;
	//array of music clips. change in editor.
	public AudioClip[] music;


	// Use this for initialization
	void Start () {
	    //starts by playing track 0

		source.clip = music [0];
		source.loop = true;
		source.Play ();

	}
	
	// Update is called once per frame
	void Update () {



	
	}
	//change song to index specified. specify index based on selections in editor
	public bool changeSong(int songIndex){

		source.Pause ();
		source.clip = music [songIndex];
		source.Play();
		return true;

	}

}
