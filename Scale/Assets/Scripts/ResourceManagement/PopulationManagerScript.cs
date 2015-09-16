using UnityEngine;
using System.Collections;

public class PopulationManagerScript : MonoBehaviour {

	private int maxPopulation;
	private int currentPopulation;
	private int employed;//currentPop - employed = unemployed
	private int populationGrowthRate = 1;
	public int foodRequirement = 1;
	

	// Update is called once per frame
	void Update () {
		if (currentPopulation + populationGrowthRate <= maxPopulation) {
			currentPopulation += populationGrowthRate;
			GameController.gameController.addResources (populationGrowthRate, 0, 0, 0);

		} else {
			currentPopulation = maxPopulation;
			GameController.gameController.addResources (maxPopulation-(maxPopulation-currentPopulation), 0, 0, 0);
		}
	}

	public void increaseMaxPopulation(int increase){
		maxPopulation += increase;
	}

	public void addEmployed(int increase){
		employed += increase;
	}

	public bool hasSufficientUnemployed(int population){
		return (currentPopulation-employed) > population;
	}
}