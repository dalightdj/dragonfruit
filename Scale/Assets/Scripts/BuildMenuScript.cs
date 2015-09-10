using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class BuildMenuScript : MonoBehaviour {

	public enum Direction {UP, DOWN, LEFT, RIGHT};
	public GameObject[] buildMenus;//0=DOWN, 1=LEFT, 2=UP, 3=RIGHT
	public GameObject tile;

	//for building buildings
	public Button[] buildingOptions;//the building options available in the build menu
	public GameObject[] buildings;//each index of this array should have the corresponding building to the building options

	private GameObject[] selectedTiles = new GameObject[4];
	private GameObject[] tileHighlightLights = new GameObject[4];

	// Use this for initialization
	void Start () {
		//for (int i = 0; i<buildMenus.Length; i++) {
		//	asdf (buildMenus[i]);
		//}
		//callMenu (Direction.UP, tile);
		//callMenu (Direction.DOWN, tile);
		//callMenu (Direction.LEFT, tile);
		//callMenu (Direction.RIGHT, tile);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Assuming 'pos' is a Vector 2 with (0,0) at the top-left. 'x' increases to the right. 'y' decreases to the bottom.
	public void callMenu(Direction dir, GameObject tile){
		GameObject menu;
		GameObject lightGameObject = new GameObject("The Light");
		Color highlightColor;

		print ("tile:" + tile);
		print (dir);
		print ("index 0:" + selectedTiles [0]);
		print ("----------------------");
		if (dir == Direction.DOWN) {
			menu = buildMenus[0];
			selectedTiles[0] = tile;
			tileHighlightLights[0] = lightGameObject;
			highlightColor = Color.red;
		}
		else if (dir == Direction.LEFT) {
			menu = buildMenus[1];
			selectedTiles[1] = tile;
			tileHighlightLights[1] = lightGameObject;
			highlightColor = Color.blue;
		}
		else if (dir == Direction.UP) {
			menu = buildMenus[2];
			selectedTiles[2] = tile;
			tileHighlightLights[2] = lightGameObject;
			highlightColor = Color.green;
		}
		else{//(dir == Direction.RIGHT) {
			menu = buildMenus[3];
			selectedTiles[3] = tile;
			tileHighlightLights[3] = lightGameObject;
			highlightColor = Color.magenta;
		}
		print ("index 0:" + selectedTiles [0]);

		for (int i = 0; i<tileHighlightLights.Length; i++) {
			print ("TILE ARRAY: " + tileHighlightLights[i]);
		}

		highlightTile (tile, highlightColor, lightGameObject);

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
				this.BuildBuilding(newChild, menu);
			});
		}
		
		
		menu.SetActive (true);
		print("index " + 0 + ":" + selectedTiles[0]);
		print ("========================");
	}


	//adds the highlgihting for a given tile. will add a point light 1 unit above teh given game object
	void highlightTile(GameObject tile, Color highLightColor, GameObject lightGameObject){		
		Light lightComp = lightGameObject.AddComponent<Light>();
		lightComp.color = highLightColor;
		Vector3 raise = new Vector3 (0,1,0);
		lightGameObject.transform.position = tile.transform.position + raise;		
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
	}*/

	public void closeMenu(GameObject menu){
		menu.SetActive (false);
	}


	public void BuildBuilding(Button button, GameObject menu){
		string buttonAsString = button.ToString().Split('(', ' ')[0];

		string getIndex = button.transform.parent.parent.gameObject.ToString().Substring(9, 1);
		int index = int.Parse (getIndex);

		TileScript selectedTileScript = selectedTiles [index].
			GetComponent<TileScript>();


		for (int i = 0; i<buildingOptions.Length; i++) {

			//split the string to get it's name
			string buildingAsString = buildingOptions[i].ToString().Split('(', ' ')[0];

			if(buttonAsString.Equals(buildingAsString)){
				selectedTileScript.building = buildings[i];
				selectedTileScript.build ();

				//remove highlight and close menu
				Destroy (tileHighlightLights[index]);
				closeMenu(menu);
				return;
			}
		}
	}
}
