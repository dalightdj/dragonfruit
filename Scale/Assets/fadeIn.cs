using UnityEngine;
using System.Collections;

public class fadeIn : MonoBehaviour {

	public Texture2D texture;
	public float fadeSpeed = 0.8f;

	private int drawDepth = -1000;
	public float alpha = 1.0f;
	public int fadeDir = -1;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){

		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.b, alpha);

		GUI.depth = drawDepth;

		GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height), texture);
	}
}
