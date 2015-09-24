using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public AudioSource source;
	public AudioClip[] music;


	// Use this for initialization
	void Start () {
	
		//source = GetComponent<AudioSource>();
		source.clip = music [0];
		source.loop = true;
		source.Play ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool changeSong(int songIndex){

		source.Pause ();
		source.clip = music [songIndex];
		source.Play();
		return true;

	}

}
