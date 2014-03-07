using UnityEngine;
using System.Collections;

//Script attached to Passenger prefab.  determines all virus related info for each object
public class CheckInfection : MonoBehaviour {
	//used to randomize symptoms and sayings
	static System.Random rand = new System.Random();
	//the bools that show the symptoms each passenger has
	public bool isInfected,isSymptoms,nausea,fever,cough,sneeze, highBP, rash;
	//sets a generic normal random temperature for all passengers
	public double temperature = rand.NextDouble() * (99.00 - 98.00) + 98.00;
	//sets a generic normal random Blood pressure for all passengers
	public int diastolicBP = rand.Next (60, 80);
	public int systolicBP = rand.Next (100, 120);
	//string that will show what each passenger has to say to you
	public string speak = "";
	
	
	// Use this for initialization
	void Start () {
		//set all symptoms to false
		isInfected = false;
		isSymptoms = false;
		nausea = false;
		fever = false;
		cough = false;
		sneeze = false;
		highBP = false;
		rash = false;
		//select a random number between 1 and 100 for every passenger
		//if less than 50, passenger displays symptoms
		int range = rand.Next (1,100);

		if (range <= 50)
			isSymptoms = true;
   		else
   			isSymptoms = false;
		//gives the passengers with no symptoms something to say
			int fine = rand.Next (1,3);
			if (fine == 1);
			speak = "I've been feeling fine";
			if (fine == 2);
			speak = "Leave me alone";
			if (fine == 3);
			speak = "What's it to you?";
	}
	
	// Update is called once per frame
	void Update () {
		checkForSymptoms();
	}
	
	
	//sets symptoms for all passengers requiring symptoms
	void checkForSymptoms(){
		//becoming infected overrides symptoms
		if (isInfected == true)
			isSymptoms = false;
		
		if (isSymptoms == true){
			//assign a random 1 of 6 symptoms to all affected
			int symptom = rand.Next(1,6);
			
			//sneeze symptom and dialouge
			if (symptom == 1){
				//animation.Play("sneeze");
				sneeze = true;
				int dia = rand.Next (1,2);
				if(dia == 1){
					speak = "Oh this, I think its just a cold";
				}
				if(dia == 2){
					speak = "I've just had the sniffles for a couple days";
				}
			}
			
			//cough symptom and dialouge
			if (symptom == 2){
				//animation.Play("cough");
				cough = true;
				speak = "*cough cough* mmmgghmmm, sorry.  I picked up a cough the other day";
			}
			
			//nausea symptom and dialouge
			if (symptom == 3){
				nausea = true;
				int dia = rand.Next (1,2);
				if(dia == 1){
					speak = "...ugh.  I think this flight is gettin to me";
				}
				if(dia == 2){
					speak = "Must have had some bad take-out the other night";
				}
				
			}
			
			//fever symptom and dialouge
			if(symptom == 4){
				temperature = 99.5;
				fever = true;
				speak = "I think the altitude's getting to me.  My head is killing me";
			}
			
			//rash symptom and dialouge
			if(symptom == 5){
				rash = true;
				//whatever we do to make the rash show up on the model
				speak = "I've been so itchy lately";
			}
			
			//high blood pressure symptom and dialouge
			if(symptom == 6){
				highBP = true;
				diastolicBP = rand.Next (80, 100);
				systolicBP = rand.Next (125, 160);
				int dia = rand.Next (1,2);
				if(dia == 1){
					speak = "It's always been high like that, don't bother with it";
				}
				if(dia == 2){
					speak = "It's probably just my weight or something";
				}
			}
		}
	}
}
