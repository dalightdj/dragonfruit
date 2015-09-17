using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {

	public int populationGrowth;
	public int materialGrowth;
	public int pollutionGrowth;
	public int foodGrowth;

	public int populationCost;
	public int materialCost;
	public int pollutionCost;
	public int employmentCost;

	void Start(){
		print (this);
		GameController gc = GameController.gameController;
		gc.addResourceGrowthRate (populationGrowth, materialGrowth, pollutionGrowth, foodGrowth);
	}

}
