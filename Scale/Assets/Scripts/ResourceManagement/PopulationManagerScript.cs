using UnityEngine;
using System.Collections;

public class PopulationManagerScript : MonoBehaviour {

	private int maxPopulation = 50;
	private int currentPopulation = 5;
	private int employed;//currentPop - employed = unemployed
	private float populationGrowthRate = 1;
	private float count = 0;
	public float foodRequirementPerPerson = 0.01f;

	// Use this for initialization
	void Start () {
		GameController.gameController.addResources (currentPopulation, 0, 0, 0);
	}
	

	// Update is called once per frame
	void Update () {
		GameController.gameController.addResources (0, 0, 0, -(foodRequirementPerPerson*currentPopulation));

		count += populationGrowthRate;

		print ("Max pop:" + maxPopulation);
		if (count / 100 >= 1) {
			if(currentPopulation+1 <= maxPopulation){
				currentPopulation += 1;
				GameController.gameController.addResources(1, 0, 0, 0);
			}
			count = 0;
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