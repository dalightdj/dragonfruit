using UnityEngine;
using System.Collections;

public class BuildMenuScript : MonoBehaviour {

	public enum Direction {UP, DOWN, LEFT, RIGHT};
	public GameObject[] buildMenus;//0=DOWN, 1=LEFT, 2=UP, 3=RIGHT

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void callMenu(Direction dir, Vector2 pos){
		GameObject menu;

		if (dir == Direction.DOWN) {
			menu = buildMenus[0];
		}
		else if (dir == Direction.LEFT) {
			menu = buildMenus[1];
		}
		else if (dir == Direction.UP) {
			menu = buildMenus[2];
		}
		else{//(dir == Direction.RIGHT) {
			menu = buildMenus[3];
		}


		menu.SetActive (true);
	}
}
