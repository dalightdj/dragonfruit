using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {

	public int population;
	public int material;
	public int pollution;
	public int food;

	void Start(){
		GameController gc = GameController.gameController;
		gc.addResources (population, material, pollution, food);
	}

}
