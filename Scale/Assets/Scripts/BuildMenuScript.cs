using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class BuildMenuScript : MonoBehaviour {

	public enum Direction {UP, DOWN, LEFT, RIGHT};
	public GameObject[] buildMenus;//0=DOWN, 1=LEFT, 2=UP, 3=RIGHT
	public GameObject[] popups;
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
		callMenu (Direction.DOWN, tile);
		callMenu (Direction.LEFT, tile);
		//callMenu (Direction.RIGHT, tile);


		//populate the popup menu array
		popups = new GameObject[buildMenus.Length];
		for (int i = 0; i<buildMenus.Length; i++) {
			foreach(Transform child in buildMenus[i].transform){
				if(child.gameObject.tag.Equals("Popup")){
					popups[i] = child.gameObject;
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
			if(menu.activeSelf){
				//StartCoroutine (Continue (tile, Color.red));
				return;
			}
			selectedTiles[0] = tile;
			tileHighlightLights[0] = lightGameObject;
			highlightColor = Color.red;
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

		highlightTile (tile, highlightColor, lightGameObject);

		//retrieve building options menu
		GameObject buildingOptionsList = null;
		//print (menu);
		//print(menu.transform.Find ("ScrollView"));
		GameObject scrollView = menu.transform.Find ("ScrollView").gameObject;
		int l = 0;
		foreach (Transform child in scrollView.transform) {
			print ("child" + l++ + " " + child);
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
				this.openPopup(newChild, menu);
			});
		}
		
		
		menu.SetActive (true);
		/*
		print("index " + 0 + ":" + selectedTiles[0]);
		print ("========================");
		*/
	}

	public void openPopup(Button button, GameObject menu){
		string buttonAsString = button.ToString().Split('(', ' ')[0];
		
		int index = getIndex (menu);

		//build sumn		
		TileScript selectedTileScript = selectedTiles [index].
			GetComponent<TileScript>();
		GameObject building = null;		
		for (int i = 0; i<buildingOptions.Length; i++) {
			
			//split the string to get it's name
			string buildingAsString = buildingOptions[i].ToString().Split('(', ' ')[0];
			
			if(buttonAsString.Equals(buildingAsString)){
				building = buildings[i];				
				break;
			}
		}

		BuildingScript buildingScript = building.GetComponent<BuildingScript> ();

		GameObject popup = popups [index];
		popup.SetActive (true);

		Transform[] popupChildren = popup.GetComponentsInChildren<Transform> ();//{0 = Image, 1 = ResourceImgs, 2 = ResourceCostTexts, 3 = ResourceGrowthTexts, 4 = CloseButton, 5 = AcceptButton, 6 = MessageBar}

		//print (popup.GetComponentsInParent<RectTransform>());

		//add cost text
		Text[] resourceCostTexts = null;
		foreach (Transform t in popupChildren) {
			if(t.tag.Equals("ResourceCostText")){
				resourceCostTexts = t.gameObject.GetComponentsInChildren<Text>();
			}
		}
		resourceCostTexts [0].text = buildingScript.materialCost.ToString();
		resourceCostTexts [1].text = buildingScript.populationCost.ToString();
		resourceCostTexts [2].text = 0.ToString();
		resourceCostTexts [3].text = buildingScript.pollutionCost.ToString();

		//add growth rate text
		Text[] growthRateTexts = popupChildren [3].GetComponentsInChildren<Text> (true);
		foreach (Transform t in popupChildren) {
			if(t.tag.Equals("ResourceGrowthText")){
				growthRateTexts = t.gameObject.GetComponentsInChildren<Text>();
			}
		}
		growthRateTexts [0].text = buildingScript.materialGrowth.ToString();
		growthRateTexts [1].text = buildingScript.populationGrowth.ToString();
		growthRateTexts [2].text = buildingScript.foodGrowth.ToString();
		growthRateTexts [3].text = buildingScript.pollutionGrowth.ToString();


		Button image = null;
		foreach (Transform t in popupChildren) {
			if(t.tag.Equals("Image")){
				image = t.gameObject.GetComponent<Button>();
			}
		}

		//image = Instantiate(buildingOptions[index]);

		Text messageBar = null;
		foreach (Transform t in popupChildren) {
			if(t.tag.Equals("MessageBar")){
				messageBar = t.gameObject.GetComponent<Text>();
			}
		}

		//add message: if cannot build color should be red and should say "Do not have sufficient resources". If can build color should be green and should say "Tap building image to build"
		if (!GameController.gameController.sufficientResourses (buildingScript.populationCost, buildingScript.materialCost, buildingScript.pollutionCost, 0)) {
			messageBar.color = Color.red;
			messageBar.text = "Do not have sufficient resources";
			return;
		}
		if (!GameController.gameController.sufficientUnemployed (buildingScript.employmentCost)) {
			messageBar.color = Color.red;
			messageBar.text = "Do not have sufficient unemployed";
			return;
		}
		messageBar.color = Color.green;
		messageBar.text = "Tap building image to build";

		selectedTileScript.building = building;
		image.onClick.AddListener(() => {
			selectedTileScript.build ();
			closeMenu(menu);
		});

		//add accept button
		/*selectedTileScript.building = building;
		selectedTileScript.build ();
		closeMenu(menu);*/






	}


	//adds the highlgihting for a given tile. will add a point light 1 unit above teh given game object
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
