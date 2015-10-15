using UnityEngine;
using System.Collections;

//A class for managing the population. It inherits from the ResourceManagementScript
public class PopulationManagerScript : ResourceManagementScript {

	private float maxPopulation = 0;
	private float currentPopulation = 15;
	private float employed;//currentPop - employed = unemployed
	public float foodRequirementPerPerson = 0.001f;

	// Use this for initialization
	void Start () {
		maxPopulation = GameController.gameController.getTotalPopulation ();
		GameController.gameController.addResources (-(maxPopulation-currentPopulation), 0, 0, 0);
		increaseGrowthRate (10);
	}
	

	// Update is called once per frame
	void Update () {
		//Make sure there is enough food
		if (GameController.gameController.sufficientResourses (0, 0, 0, (foodRequirementPerPerson * currentPopulation)+1)) {
			GameController.gameController.addResources (0, 0, 0, -(foodRequirementPerPerson * currentPopulation));
		} else {//If not enough food then population starts plummeting
			float popLoss = -0.15f;
			float food = GameController.gameController.getCurrentFood();
			food = 0;
			popLoss -= (food/10000);//some of the people get to eat so less people die off

			GameController.gameController.addResources (popLoss, 0, 0, food);
			currentPopulation = GameController.gameController.getTotalPopulation();
			if(employed >= currentPopulation){//if there is more employed than the current population
				employed += popLoss;//then the employed people start dying away
			}

			return;
		}

		//Do not exceed max population
		if (GameController.gameController.getTotalPopulation() < maxPopulation) {
			//print ("Current:" + currentPopulation);
			//print ("Total:" + GameController.gameController.getTotalPopulation());
			//print ("Max:" + maxPopulation);
			//print ("Employed:" + employed);
			base.Update ();//Call the ResourceManagementScript's update method
		}
	}

	public override void addResources(){
		GameController.gameController.addResources (1, 0, 0, 0);
		currentPopulation++;
	}

	public void increaseMaxPopulation(int increase){
		if (increase < 0) {
			if(maxPopulation+increase < 0){
				maxPopulation = 0;
				currentPopulation = 0;
			}
			else {
				maxPopulation += increase;
				if(maxPopulation > currentPopulation){
					currentPopulation = maxPopulation;
				}
			}
			return;
		}
		maxPopulation += increase;
	}

	public void addEmployed(float increase){
		if (getUnemployed () >= currentPopulation) {
			employed += increase;
		} else {
			print ("ERROR: TRYING TO ADD EMPLOYED WITH INSUFFICIENT POPULATION");
		}
	}

	public bool hasSufficientUnemployed(int population){
		return (currentPopulation-employed) > population;
	}

	public int getUnemployed(){
		currentPopulation = GameController.gameController.getTotalPopulation();
		return (int) (currentPopulation-employed);
	}
}