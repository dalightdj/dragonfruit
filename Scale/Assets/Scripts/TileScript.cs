using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	public int population;
	public int material;
	public int pollution;
	public int food;
	public TileType tileType;
	public GameObject building;

	public enum TileType{WATER, LAND, FOREST};

	public void build(){
		Instantiate(building);
	}

}
