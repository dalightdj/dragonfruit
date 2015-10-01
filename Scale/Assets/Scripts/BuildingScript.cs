using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {

	//these affect how much each resource increases/decreases
	public int populationGrowth;
	public int materialGrowth;
	public int pollutionGrowth;
	public int foodGrowth;

	//these are the material costs for building this building
	public int populationCost;
	public int materialCost;
	public int pollutionCost;
	public int employmentCost;

	void Start(){
		//print ("Building Script");
		GameController gc = GameController.gameController;
		gc.addResourceGrowthRate (populationGrowth, materialGrowth, pollutionGrowth, foodGrowth);
	}

}
