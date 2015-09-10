using UnityEngine;
using System.Collections;

public class PopulationManagerScript : MonoBehaviour {

	private int maxPopulation;
	private int currentPopulation;
	private int employed;//currentPop - employed = unemployed
	private int populationGrowthRate = 5;
	public int foodRequirement = 1;
	

	// Update is called once per frame
	void Update () {
		GameController.gameController.addResources (0, 0, 0, -currentPopulation);

		if (currentPopulation + populationGrowthRate <= maxPopulation) {
			currentPopulation += populationGrowthRate;
			GameController.gameController.addResources (populationGrowthRate, 0, 0, 0);

		} else {
			currentPopulation = maxPopulation;
			GameController.gameController.addResources (maxPopulation-currentPopulation, 0, 0, 0);
		}


	}

	public void increaseMaxPopulation(){
		maxPopulation += 20;
	}

	public void decreaseMaxPopulation(){
		maxPopulation -= 20;
	}
}
