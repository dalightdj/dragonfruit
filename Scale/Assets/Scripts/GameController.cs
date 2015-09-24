﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController gameController;

	public int timeLimit = 60;//the losing condition i.e. 60 seconds

	private float time;
	private GameObject[] HUDs;//the Text components that will show the score
	
	private float totalPopulation;
	private float totalMaterial;
	private float totalPollution;
	private float totalFood = 150;

	private PopulationManagerScript populationManager;
	private FoodManagerScript foodManager;
	private PollutionManagerScript pollutionManager;
	private MaterialManagerScript materialManager;
	
	//Ensures GameController is a singleton
	void Awake () 
	{
		if(gameController != null)
		{
			Destroy(this.gameObject);
		}
		else
		{
			gameController = this;
		}

		populationManager = gameObject.AddComponent<PopulationManagerScript>();
		foodManager = gameObject.AddComponent<FoodManagerScript> ();
		pollutionManager = gameObject.AddComponent <PollutionManagerScript> ();
		materialManager = gameObject.AddComponent<MaterialManagerScript> ();
	}


	// Use this for initialization
	void Start () {
		HUDs = GameObject.FindGameObjectsWithTag ("HUD");
	}
	
	// Update is called once per frame
	void Update () {

		//A simple countdown
		time += Time.deltaTime;
		for(int i = 0; i<HUDs.Length; i++){
			Text[] textComponents = HUDs[i].GetComponentsInChildren<Text>();
			print ("0     " + textComponents[0]);
			print ("1     " + textComponents[1]);
			print ("2     " + textComponents[2]);
			print ("3     " + textComponents[3]);
			print ("4     " + textComponents[4]);
			//print ("5     " + textComponents[5]);
			//print ("6     " + textComponents[6]);

			textComponents[0].text = string.Format("{0:n0}", ((timeLimit+0.5)-time));
			textComponents[1].text = string.Format ("{0:n0}", totalPopulation);
			textComponents[2].text = string.Format ("{0:n0}", totalMaterial);
			textComponents[3].text = string.Format ("{0:n0}", totalPollution);
			textComponents[4].text = string.Format ("{0:n0}", totalFood);

			/*Text textComponent = HUDs[i].GetComponent<Text>();

			textComponent.text = string.Format("{0:n0}", ((timeLimit+0.5)-time));
			//textComponent.text = textComponent.text + "  Pop:" + totalPopulation + "  Mat:" + totalMaterial + "  Pol:" + totalPollution + "  Food:" + totalFood;
			textComponent.text = textComponent.text + " Pop:";
			textComponent.text = textComponent.text + string.Format ("{0:n0}", totalPopulation);
			textComponent.text = textComponent.text + " Mat:";
			textComponent.text = textComponent.text + string.Format ("{0:n0}", totalMaterial);
			textComponent.text = textComponent.text + " Pol:";
			textComponent.text = textComponent.text + string.Format ("{0:n0}", totalPollution);
			textComponent.text = textComponent.text + " Food:";
			textComponent.text = textComponent.text + string.Format ("{0:n0}", totalFood);*/
		}

		//END GAME
		if ((time >= timeLimit) || (totalPopulation<0)) {
			Application.LoadLevel("Ending");
		}
	}

	public void addResourceGrowthRate(float population, float material, float pollution, float food){
		populationManager.increaseGrowthRate (population);
		materialManager.increaseGrowthRate (material);
		pollutionManager.increaseGrowthRate (pollution);
		foodManager.increaseGrowthRate (food);
	}

	public void addResources(float population, float material, float pollution, float food){
		//print ("Add resources: pop=" + population + " material=" + material + " pollution=" + pollution + " food=" + food);
		totalPopulation += population;
		totalMaterial += material;
		totalPollution += pollution;
		totalFood += food;
	}

	public int getTotalPopulation(){
		return (int) totalPopulation;
	}

	public bool sufficientResourses(float population, float material, float pollution, float food){
		if (totalPopulation < population || totalMaterial < material || totalPollution < pollution || totalFood < food) {
			return false;
		}
		return true;
	}

	public void increaseMaxPopulation(int increase){
		populationManager.increaseMaxPopulation (increase);
	}

	public void addEmployed(int increase){
		populationManager.addEmployed (increase);
	}

	public bool sufficientUnemployed(int population){
		return populationManager.hasSufficientUnemployed (population);
	}
}
