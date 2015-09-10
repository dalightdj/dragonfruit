﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController gameController;

	public int timeLimit = 60;//the losing condition i.e. 60 seconds

	private float time;
	private GameObject[] scoreTexts;//the Text components that will show the score
	
	private int totalPopulation;
	private int totalMaterial;
	private int totalPollution;
	private int totalFood;

	private PopulationManagerScript populationManager = new PopulationManagerScript();
	
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
	}


	// Use this for initialization
	void Start () {
		scoreTexts = GameObject.FindGameObjectsWithTag ("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {

		//A simple countdown
		time += Time.deltaTime;
		for(int i = 0; i<scoreTexts.Length; i++){
			Text textComponent = scoreTexts[i].GetComponent<Text>();

			textComponent.text = string.Format("{0:n0}", ((timeLimit+0.5)-time));
			textComponent.text = textComponent.text + "  Pop:" + totalPopulation + "  Mat:" + totalMaterial + "  Pol:" + totalPollution + "  Food:" + totalFood;
		}


		//END GAME
		if (time >= timeLimit) {
			Application.LoadLevel("Ending");
		}
	}

	public void addResources(int population, int material, int pollution, int food){
		totalPopulation += population;
		totalMaterial += material;
		totalPollution += pollution;
		totalFood += food;
	}

	public void increaseMaxPopulation(){
		populationManager.increaseMaxPopulation ();
	}

	public void decreaseMaxPopulation(){
		populationManager.decreaseMaxPopulation ();
	}

	public void increaseEmployment(int population){
		populationManager.increaseEmployment (population);
	}

	public void decreaseEmployment(int population){
		populationManager.decreaseEmployment (population);
	}

	public bool hasSufficientUnemployed(int population){
		return populationManager.hasSufficientUnemployed (population);
	}
}
