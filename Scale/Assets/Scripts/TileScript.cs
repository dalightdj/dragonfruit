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
		GameObject build = Instantiate(building);
		build.transform.position = tile.transform.position;

		if(building.name.Equals("House")){
			GameController.gameController.increaseMaxPopulation();
		}
	}

	public void destroyBuilding(){
		if (building != null) {
			Destroy(building);
			GameController.gameController.decreaseMaxPopulation();
		}
	}

}
