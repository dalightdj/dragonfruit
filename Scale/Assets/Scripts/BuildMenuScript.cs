using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class BuildMenuScript : MonoBehaviour {

	public enum Direction {UP, DOWN, LEFT, RIGHT};
	public GameObject[] buildMenus;//0=DOWN, 1=LEFT, 2=UP, 3=RIGHT
	//public GameObject tile;

	//for building buildings
	public Button[] buildingOptions;//the building options available in the build menu
	public GameObject[] buildings;//each index of this array should have the corresponding building to the building options

	private GameObject[] selectedTiles = new GameObject[4];

	// Use this for initialization
	void Start () {
		//for (int i = 0; i<buildMenus.Length; i++) {
		//	asdf (buildMenus[i]);
		//}
		//callMenu (Direction.UP, null);
		//callMenu (Direction.DOWN, tile);
		//callMenu (Direction.LEFT, null);
		//callMenu (Direction.RIGHT, null);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Assuming 'pos' is a Vector 2 with (0,0) at the top-left. 'x' increases to the right. 'y' decreases to the bottom.
	public void callMenu(Direction dir, GameObject tile){
		GameObject menu;

		print ("tile:" + tile);
		print (dir);
		print ("index 0:" + selectedTiles [0]);
		print ("----------------------");
		if (dir == Direction.DOWN) {
			menu = buildMenus[0];
			selectedTiles[0] = tile;
		}
		else if (dir == Direction.LEFT) {
			menu = buildMenus[1];
			selectedTiles[1] = tile;
		}
		else if (dir == Direction.UP) {
			menu = buildMenus[2];
			selectedTiles[2] = tile;
		}
		else{//(dir == Direction.RIGHT) {
			menu = buildMenus[3];
			selectedTiles[3] = tile;
		}
		print ("index 0:" + selectedTiles [0]);

		
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
			newChild.onClick.AddListener(() => {
				this.BuildBuilding(newChild);
			});
		}
		
		
		menu.SetActive (true);
		print("index " + 0 + ":" + selectedTiles[0]);
		print ("========================");
	}


	/*
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
	}*/


	public void BuildBuilding(Button button){
		print("index " + 0 + ":" + selectedTiles[0]);
		string buttonAsString = button.ToString().Split('(', ' ')[0];

		string getIndex = button.transform.parent.parent.gameObject.ToString().Substring(9, 1);
		int index = int.Parse (getIndex);

		print (index);
		for (int i = 0; i<selectedTiles.Length; i++) {
			print("index " + i + ":" + selectedTiles[i]);
		}

		TileScript selectedTileScript = selectedTiles [index].
			GetComponent<TileScript>();


		for (int i = 0; i<buildingOptions.Length; i++) {

			//split the string to get it's name
			string buildingAsString = buildingOptions[i].ToString().Split('(', ' ')[0];

			if(buttonAsString.Equals(buildingAsString)){
				selectedTileScript.building = buildings[i];
				selectedTileScript.build ();
				return;
			}
		}
	}
}
