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

	//Assuming 'pos' is a Vector 2 with (0,0) at the top-left. 'x' increases to the right. 'y' decreases to the bottom.
	public void callMenu(Direction dir, Vector2 pos){
		GameObject menu;
		Vector2 newPos;
		
		if (dir == Direction.DOWN) {
			menu = buildMenus[0];
			//DOWN center is (x-75)
			newPos = new Vector2(pos.x-75, pos.y);
		}
		else if (dir == Direction.LEFT) {
			menu = buildMenus[1];
			//LEFT center is (y+75)
			newPos = new Vector2(pos.x, pos.y+75);
		}
		else if (dir == Direction.UP) {
			menu = buildMenus[2];
			//UP center is (x+75)
			newPos = new Vector2(pos.x+75, pos.y);
		}
		else{//(dir == Direction.RIGHT) {
			menu = buildMenus[3];
			//RIGHT center is (y-75)
			newPos = new Vector2(pos.x, pos.y-75);
		}
		
		menu.GetComponent<RectTransform> ().anchoredPosition = newPos;
		menu.SetActive (true);
	}

	public void closeMenu(GameObject menu){
		menu.SetActive (false);
	}
}
