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
		GameObject build = Instantiate(building);
		build.transform.position = new Vector3 (0, 0, 0);//transform.position;
	}

}
