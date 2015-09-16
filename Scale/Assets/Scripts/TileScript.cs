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
		print ("JUST BUILDT");
		if (building.name.Equals ("House") || building.name.Equals ("Apartment")) {
			GameController.gameController.increaseMaxPopulation (20);

		} else {
			int employment = 10;

			//UNCOMMENT THIS FOR BUILDING RESTRICTION
			 /* if(!GameController.gameController.hasSufficientUnemployed(employment)){
				print ("CANNOT BUILD");
				return;
			}*/
			GameController.gameController.addEmployed(employment);
		}
		print ("INSTANTITATION");
			   GameObject build = Instantiate(building);
			   build.transform.position = tile.transform.position;
		print (build.transform.position);
	}


	public void destroyBuilding(){
		if (building != null) {
			Destroy (building);

			if (building.name.Equals ("House") || building.name.Equals ("Apartment")) {
				GameController.gameController.increaseMaxPopulation (-20);
			} else {
				GameController.gameController.addEmployed (-10);
			}
		}
	}
}
