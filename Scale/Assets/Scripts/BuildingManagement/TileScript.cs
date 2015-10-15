using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	private int housePopIncrease = 10;
	private int apartmentPopIncrease = 20;

	public int population;
	public int material;
	public int pollution;
	public int food;
	public TileType tileType;
	public GameObject tile;
	public GameObject building;

	public enum TileType{WATER, LAND, FOREST};


	//Builds a building on this tile
	public void build(){
		//To retrieve the values
		BuildingScript buildingScript = building.GetComponent<BuildingScript> ();

		//House increases the max population by 10 while apartment increases the max population by 20
		if (building.name.Equals ("House")) {
			GameController.gameController.increaseMaxPopulation (housePopIncrease);
		} else if (building.name.Equals ("Apartment")) {
			GameController.gameController.increaseMaxPopulation (apartmentPopIncrease);
		} else {
			GameController.gameController.addEmployed(buildingScript.employmentCost);
		}

		//Build the building in the correct position and remove the appropriate amount of resources
		GameController.gameController.addResources (0, -buildingScript.materialCost, buildingScript.pollutionCost, 0);
		GameObject build = Instantiate (building);
		build.transform.position = tile.transform.position;
	}
	

	//Destroys the building on this tile
	public void destroyBuilding(){
		if (building != null) {
			BuildingScript buildingScript = building.GetComponent<BuildingScript>();

			if (building.name.Equals ("House")) {
				GameController.gameController.increaseMaxPopulation (-housePopIncrease);
			} 
			else if(building.name.Equals ("Apartment")){
				GameController.gameController.increaseMaxPopulation (-apartmentPopIncrease);
			} else {
				GameController.gameController.addEmployed (-buildingScript.employmentCost);
			}

			Destroy (building);
			building = null;
		}
	}
}
