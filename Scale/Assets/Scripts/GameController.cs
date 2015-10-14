using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameController : MonoBehaviour {

	public static GameController gameController;

	public int timeLimit = 60;//the losing condition i.e. 60 seconds

	private float time;
	private GameObject[] HUDs;//the Text components that will show the score
	
	private float totalPopulation = 50;
	private float totalMaterial = 100;
	private float totalPollution = 0;
	private float totalFood = 10;

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
			TimeSpan timeSpan = TimeSpan.FromMinutes((timeLimit+0.5)-time);

			textComponents[0].text = string.Format("{0:D2}:{1:D2}", timeSpan.Hours, timeSpan.Minutes);
			textComponents[1].text = string.Format("{0:n0}", populationManager.getUnemployed());
			textComponents[1].text = textComponents[1].text + "/";
			textComponents[1].text = textComponents[1].text + string.Format ("{0:n0}", Mathf.Min (populationManager.getUnemployed(), totalPopulation));
			textComponents[2].text = string.Format ("{0:n0}", totalMaterial);
			textComponents[3].text = string.Format ("{0:n0}", totalPollution);
			textComponents[4].text = string.Format ("{0:n0}", totalFood);
		}


		print ("GameController:" + totalPopulation);
		//END GAME
		if (totalPopulation<1) {//because total population is a float, have to check if it is smaller than 1 which means it is essentially zero
			Application.LoadLevel("PopulationAnnihilated");
		}
		else if(totalPollution>=1000){
			Application.LoadLevel("PollutedPlanet");
		}
		else if(time >= timeLimit){//run out of time
			Application.LoadLevel("TimeUp");
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
