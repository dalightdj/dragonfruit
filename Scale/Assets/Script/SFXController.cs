using UnityEngine;
using System.Collections;
//SFX controller, controls sound effects in the game.
//call 
public class SFXController : MonoBehaviour {
	//teh audiosource to play from.
	public AudioSource source;
	//the array holding the clips to be played. controlled in editor.
	public AudioClip[] sfx;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//playes clip of given indice in the array.
	public void playClip(int clipNumber){

		source.PlayOneShot (sfx[clipNumber]);
	}
}
