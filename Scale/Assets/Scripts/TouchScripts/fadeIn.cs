using UnityEngine;
using System.Collections;

public class fadeIn : MonoBehaviour {
	//texture to fade to or from.
	public Texture2D texture;
	//speed of fade.
	public float fadeSpeed = 0.1f;
	//draws over everything.
	private int drawDepth = -1000;
	//alpha controls how see through the texture is.
	public float alpha = 1.0f;
	//controls direction of fade. -1 fades to clear +1 darkens.
	public int fadeDir = -1;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		//fades picture in given direction.
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.b, GUI.color.g, alpha);

		GUI.depth = drawDepth;

		GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height), texture);
	}
}
