using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class BuildMenuScript : MonoBehaviour {

	public enum Direction {UP, DOWN, LEFT, RIGHT};
	public GameObject[] buildMenus;//0=DOWN, 1=LEFT, 2=UP, 3=RIGHT
	public GameObject[] popups;//the popup menu for each build menu
	public GameObject tile;//a tile for testing
	private GameObject[] selectedTiles = new GameObject[4];//for holding the currently selected tile for each player
	private GameObject[] tileHighlightLights = new GameObject[4];//for holding the light on the currently selected tile for each player

	//for building buildings
	public Button[] buildingOptions;//the building options available in the build menu
	public GameObject[] buildings;//each index of this array should have the building corresponding to the building options


	// Use this for initialization
	void Start () {
		//For testing
		//for (int i = 0; i<buildMenus.Length; i++) {
		//	asdf (buildMenus[i]);
		//}
		//callMenu (Direction.UP, tile);
		callMenu (Direction.DOWN, tile);
		callMenu (Direction.LEFT, tile);
		//callMenu (Direction.RIGHT, tile);


		//populate the popup menu array
		popups = new GameObject[buildMenus.Length];
		for (int i = 0; i<buildMenus.Length; i++) {
			foreach(Transform child in buildMenus[i].transform){
				if(child.gameObject.tag.Equals("Popup")){
					popups[i] = child.gameObject;//grab the build menu's popup menu
				}
			}

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Assuming 'pos' is a Vector 2 with (0,0) at the top-left. 'x' increases to the right. 'y' decreases to the bottom.
	public void callMenu(Direction dir, GameObject tile){
		GameObject menu;
		GameObject lightGameObject = new GameObject("The Light");
		Color highlightColor;

		/*
		print ("tile:" + tile);
		print (dir);
		print ("index 0:" + selectedTiles [0]);
		print ("----------------------");
		*/
		if (dir == Direction.DOWN) {
			menu = buildMenus[0];
			if(menu.activeSelf){//if the menu is already open
				//StartCoroutine (Continue (tile, Color.red));
				return;//don't do anything
			}
			selectedTiles[0] = tile;//set player one's tile to the selected tile
			tileHighlightLights[0] = lightGameObject;//set the light to player one
			highlightColor = Color.red;//the light will be player one's colour
		}
		else if (dir == Direction.LEFT ) {
			menu = buildMenus[1];
			if(menu.activeSelf){
				return;
			}
			selectedTiles[1] = tile;
			tileHighlightLights[1] = lightGameObject;
			highlightColor = Color.blue;
		}
		else if (dir == Direction.UP) {
			menu = buildMenus[2];
			if(menu.activeSelf){
				return;
			}
			selectedTiles[2] = tile;
			tileHighlightLights[2] = lightGameObject;
			highlightColor = Color.green;
		}
		else{//(dir == Direction.RIGHT) {
			menu = buildMenus[3];
			if(menu.activeSelf){
				return;
			}
			selectedTiles[3] = tile;
			tileHighlightLights[3] = lightGameObject;
			highlightColor = Color.magenta;
		}
		/*
		print ("index 0:" + selectedTiles [0]);

		for (int i = 0; i<tileHighlightLights.Length; i++) {
			print ("TILE ARRAY: " + tileHighlightLights[i]);
		}
		*/

		//Turn the selection light on
		highlightTile (tile, highlightColor, lightGameObject);

		//Retrieve building options menu
		GameObject buildingOptionsList = null;
		GameObject scrollView = menu.transform.Find ("ScrollView").gameObject;
		int l = 0;
		foreach (Transform child in scrollView.transform) {
			print ("child" + l++ + " " + child);
			if(child.gameObject.tag.Equals("BuildingOptionsList")){
				buildingOptionsList = child.gameObject;
				break;
			}
		}
		
		//Populate the building options menu
		foreach (Transform child in buildingOptionsList.transform) {
			Destroy(child.gameObject);//destroy everything that is currently in the options menu
		}
		for (int i = 0; i<buildingOptions.Length; i++) {
			//Repopulate the options menu with the appropriate building options
			Button newChild = Instantiate (buildingOptions[i]);
			newChild.transform.SetParent(buildingOptionsList.transform, false);
			newChild.onClick.AddListener(() => {
				this.openPopup(newChild, menu, i);
			});
		}
		
		
		menu.SetActive (true);
		/*
		print("index " + 0 + ":" + selectedTiles[0]);
		print ("========================");
		*/
	}

	public void openPopup(Button button, GameObject menu, int buildingOptionIndex){		
		int index = getIndex (menu);//get the index of this menu which is also the index of the popup menu

		TileScript selectedTileScript = selectedTiles [index].GetComponent<TileScript>();//get the tile that will hold the building we want to build
		string buttonAsString = button.ToString().Split('(', ' ')[0];//get the button name so that it can be used to find the correct building
		GameObject building = null;
		for (int i = 0; i<buildingOptions.Length; i++) {
			
			//split the string to get it's name
			string buildingAsString = buildingOptions[i].ToString().Split('(', ' ')[0];//get the building name so that it can be used to find the correct building
			
			if(buttonAsString.Equals(buildingAsString)){//if it is the correct building
				building = buildings[i];
				break;
			}
		}

		//Get the script that holds all of the cost and growth values for the building
		BuildingScript buildingScript = building.GetComponent<BuildingScript> ();

		//Get the correct popup and make it visible
		GameObject popup = popups [index];
		popup.SetActive (true);

		//Get all popup menu elements
		Transform[] popupChildren = popup.GetComponentsInChildren<Transform> ();//{0 = Image, 1 = ResourceImgs, 2 = ResourceCostTexts, 3 = ResourceGrowthTexts, 4 = CloseButton, 5 = AcceptButton, 6 = MessageBar}

		//Display resource cost text values
		Text[] resourceCostTexts = null;
		foreach (Transform t in popupChildren) {
			if(t.tag.Equals("ResourceCostText")){//find the correct element
				resourceCostTexts = t.gameObject.GetComponentsInChildren<Text>();
			}
		}
		//Add the text to the text component
		resourceCostTexts [0].text = buildingScript.materialCost.ToString("+#;-#;0");
		resourceCostTexts [1].text = buildingScript.populationCost.ToString("+#;-#;0");
		resourceCostTexts [2].text = 0.ToString("+#;-#;0");
		resourceCostTexts [3].text = buildingScript.pollutionCost.ToString("+#;-#;0");


		//Display growth rate text
		Text[] growthRateTexts = popupChildren [3].GetComponentsInChildren<Text> (true);
		foreach (Transform t in popupChildren) {
			if(t.tag.Equals("ResourceGrowthText")){
				growthRateTexts = t.gameObject.GetComponentsInChildren<Text>();
			}
		}
		//Add the text to the text component
		growthRateTexts [0].text = buildingScript.materialGrowth.ToString("+#;-#;0");
		growthRateTexts [1].text = buildingScript.populationGrowth.ToString("+#;-#;0");
		growthRateTexts [2].text = buildingScript.foodGrowth.ToString("+#;-#;0");
		growthRateTexts [3].text = buildingScript.pollutionGrowth.ToString("+#;-#;0");


		Transform image = null;
		foreach (Transform t in popupChildren) {
			if(t.tag.Equals("Image")){//get the button from the popup elements
				image = t;
			}
		}
		Button imageButton = image.GetComponent<Button> ();
		//Destroy (image.gameObject);
		//image = Instantiate ();
		//image = Instantiate (buildingOptions[0]);
		//image.transform.SetParent(popup.transform, false);
		
		//Display appropriate message
		Text messageBar = null;
		foreach (Transform t in popupChildren) {
			if(t.tag.Equals("MessageBar")){//get the message bar from the popup elements
				messageBar = t.gameObject.GetComponent<Text>();
			}
		}
		//Do not have enough resources
		if (!GameController.gameController.sufficientResourses (buildingScript.populationCost, buildingScript.materialCost, buildingScript.pollutionCost, 0)) {
			messageBar.color = Color.red;
			messageBar.text = "Do not have sufficient resources";
			return;
		}
		//Do not have enought unemployed 
		if (!GameController.gameController.sufficientUnemployed (buildingScript.employmentCost)) {
			messageBar.color = Color.red;
			messageBar.text = "Do not have sufficient unemployed";
			return;
		}
		//Can build
		messageBar.color = Color.green;
		messageBar.text = "Tap building image to build";
		selectedTileScript.building = building;


		imageButton.onClick.RemoveAllListeners ();//to make sure there are no unwanted listeners
		//Set the button to call the build method of the current building if clicked
		imageButton.onClick.AddListener(() => {
			selectedTileScript.build ();
			closeMenu(menu);
			popup.SetActive (false);//once building is built, turn off popup
		});
	}


	//Adds the highlgihting for a given tile. will add a point light 1 unit closer to the screen from the given game object
	void highlightTile(GameObject tile, Color highLightColor, GameObject lightGameObject){		
		Light lightComp = lightGameObject.AddComponent<Light>();
		lightComp.color = highLightColor;
		Vector3 raise = new Vector3 (0,1,0);
		lightGameObject.transform.position = tile.transform.position + raise;		
	}
	

	public void closeMenu(GameObject menu){
		int index = getIndex (menu);

		//remove highlight and close menu
		Destroy (tileHighlightLights[index]);
		tileHighlightLights[index] = null;
		menu.SetActive (false);
	}

	public void closePopup(GameObject popup){
		popup.SetActive (false);
	}


	public void BuildBuilding(Button button, GameObject menu){
		string buttonAsString = button.ToString().Split('(', ' ')[0];

		int index = getIndex (menu);

		TileScript selectedTileScript = selectedTiles [index].
			GetComponent<TileScript>();


		for (int i = 0; i<buildingOptions.Length; i++) {

			//split the string to get it's name
			string buildingAsString = buildingOptions[i].ToString().Split('(', ' ')[0];

			if(buttonAsString.Equals(buildingAsString)){
				selectedTileScript.building = buildings[i];
				selectedTileScript.build ();

				closeMenu(menu);
				return;
			}
		}
	}

	private int getIndex(GameObject menu){
		string getIndex = menu.ToString().Substring(9, 1);
		int index = int.Parse (getIndex);
		return index;
	}

	/*
	IEnumerator Continue(Tile tile, Color col){

		//what to do before waiting

		yield return new WaitForSeconds (1);


		//what to do after waiting
	}
	*/
}
