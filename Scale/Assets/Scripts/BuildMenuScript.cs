using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildMenuScript : MonoBehaviour {

	public enum Direction {UP, DOWN, LEFT, RIGHT};
	public GameObject[] buildMenus;//0=DOWN, 1=LEFT, 2=UP, 3=RIGHT

	//for building buildings
	public Button[] buildingOptions;//the building options available in the build menu
	public GameObject[] buildings;//each index of this array should have the corresponding building to the building options


	// Use this for initialization
	void Start () {
		//for (int i = 0; i<buildMenus.Length; i++) {
		//	asdf (buildMenus[i]);
		//}
		//callMenu (Direction.UP);
		//callMenu (Direction.DOWN);
		//callMenu (Direction.LEFT);
		//callMenu (Direction.RIGHT);
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

		//retrieve building options menu
		GameObject buildingOptionsList = null;
		foreach (Transform child in menu.transform) {
			if(child.gameObject.tag.Equals("BuildingOptionsList")){
				buildingOptionsList = child.gameObject;
				break;
			}
		}

		//populate the building options menu
		foreach (Transform child in buildingOptionsList.transform) {
			Destroy(child.gameObject);
		}
		for (int i = 0; i<buildingOptions.Length; i++) {
			Button newChild = Instantiate (buildingOptions[i]);
			newChild.transform.SetParent(buildingOptionsList.transform, false);
		}


		menu.SetActive (true);
	}

	//Assuming 'pos' is a Vector 2 with (0,0) at the top-left. 'x' increases to the right. 'y' decreases to the bottom.
	public void callMenu(Direction dir){
		GameObject menu;
		Vector2 newPos;
		
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
		
		//retrieve building options menu
		GameObject buildingOptionsList = null;
		foreach (Transform child in menu.transform) {
			if(child.gameObject.tag.Equals("BuildingOptionsList")){
				buildingOptionsList = child.gameObject;
				break;
			}
		}
		
		//populate the building options menu
		foreach (Transform child in buildingOptionsList.transform) {
			Destroy(child.gameObject);
		}
		for (int i = 0; i<buildingOptions.Length; i++) {
			Button newChild = Instantiate (buildingOptions[i]);
			newChild.transform.SetParent(buildingOptionsList.transform, false);
		}
		
		
		menu.SetActive (true);
	}

	private void asdf(GameObject menu){
		//retrieve building options menu
		GameObject buildingOptionsList = null;
		foreach (Transform child in menu.transform) {
			if(child.gameObject.tag.Equals("BuildingOptionsList")){
				buildingOptionsList = child.gameObject;
				break;
			}
		}
		
		//populate the building options menu
		foreach (Transform child in buildingOptionsList.transform) {
			Destroy(child.gameObject);
		}
		for (int i = 0; i<buildingOptions.Length; i++) {
			Button newChild = Instantiate (buildingOptions[i]);
			newChild.transform.SetParent(buildingOptionsList.transform, false);
		}

		menu.SetActive (true);
	}

	public void closeMenu(GameObject menu){
		menu.SetActive (false);
	}


	public void BuildBuilding(Button button){
		string buttonAsString = button.ToString().Split('(', ' ')[0];

		for (int i = 0; i<buildingOptions.Length; i++) {

			//split the string to get it's name
			string buildingAsString = buildingOptions[i].ToString().Split('(', ' ')[0];

			if(buttonAsString.Equals(buildingAsString)){
				Instantiate(buildings[i]);
				return;
			}
		}
	}
}
