using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	public int population;
	public int material;
	public int pollution;
	public int food;
	public TileType tileType;
	public GameObject tile;
	public GameObject building;

	public enum TileType{WATER, LAND, FOREST};

	public void build(){
		if (building.name.Equals ("House") || building.name.Equals ("Apartment")) {
			GameController.gameController.increaseMaxPopulation ();
		} else {
			int employment = 10;

			if(!GameController.gameController.hasSufficientUnemployed(employment)){
				return;
			}
			GameController.gameController.increaseEmployment(employment);
		}
			   GameObject build = Instantiate(building);
			   build.transform.position = tile.transform.position;
	}


	public void destroyBuilding(){
		if (building != null) {
			Destroy (building);

			if (building.name.Equals ("House") || building.name.Equals ("Apartment")) {
				GameController.gameController.decreaseMaxPopulation ();
			} else {
				GameController.gameController.decreaseEmployment (10);
			}
		}
	}
}
