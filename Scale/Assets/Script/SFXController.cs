using UnityEngine;
using System.Collections;

public class SFXController : MonoBehaviour {

	public AudioSource source;
	public AudioClip[] sfx;


	// Use this for initialization
	void Start () {

		//source = GetComponent<AudioSource>();



	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playClip(int clipNumber){

		source.PlayOneShot (sfx[clipNumber]);
	}
}
