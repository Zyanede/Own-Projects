using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//spreads the infection amongst the passengers
public class InfectionAlgo : MonoBehaviour {
	
	//the array of all 35 passengers
	public GameObject [] PassengerArray = new GameObject[35];
	
	//randomly picks a passenger to be patient zero
	static System.Random rand = new System.Random();
	int PatientZero = rand.Next (1,35);
	
	//Coroutine to spread the infection
	IEnumerator InfectionSpread(){
		
		//loops untill all are infected
		for (int InfectedCount = 1; InfectedCount <= 34; InfectedCount ++){
			//whats used untill 5 passengers are infected
			if(InfectedCount <= 5){
				//decreases the time it takes for someone to be infected as more people become infected
				yield return new WaitForSeconds((60f/InfectedCount) + (1.2f*InfectedCount));
				//chooses from a range of passengers close to patient zero (or last passenger infected)
				int min = PatientZero - 7;
				if (min < 0) min = 0;
				int max = PatientZero + 7;
				if (max > 34)max = 34;
				int newInfected = rand.Next(min,max);
				CheckInfection ci = new CheckInfection();
				//change the newly infected persons symptoms
				ci = (CheckInfection)PassengerArray[newInfected].GetComponent("CheckInfection");
				ci.isInfected = true; ci.nausea = true; ci.fever = true; ci.cough = true; ci.sneeze = true; ci.highBP = true; ci.rash = true;
				ci.temperature = rand.NextDouble() * (102.50 - 100.00) + 100.00;
				ci.diastolicBP = rand.Next (81, 100);
				ci.systolicBP = rand.Next (125, 160);
				//SOMETHING TO MAKE RASH APPEAR
				//assigns a new speak for the infected
				int dia = rand.Next (1,5);
				if (dia == 1)
					ci.speak = "Oh this, I think its just a cold";
				if (dia == 2)
					ci.speak = "*cough cough* mmmgghmmm, sorry.  I picked up a cough earlier today";
				if (dia == 3)
					ci.speak = "...ugh.  I think this flight is gettin to me";
				if (dia == 4)
					ci.speak = "I think the altitude's getting to me.  My head is killing me";
				if (dia == 5)
					ci.speak = "I don't know what it is, kust started feeling bad today";
				//sets new patient zero to start over
				PatientZero = newInfected;
			}
			else{
				//after 5 or more are infected, but more or less the same
				yield return new WaitForSeconds(15f);
				int min = PatientZero - 7;
				if (min < 0) min = 0;
				int max = PatientZero + 7;
				if (max > 34)max = 34;
				int newInfected = rand.Next(min,max);
				CheckInfection ci = new CheckInfection();
				ci.isInfected = true; ci.nausea = true; ci.fever = true; ci.cough = true; ci.sneeze = true; ci.highBP = true; ci.rash = true;
				ci.temperature = rand.NextDouble() * (102.50 - 100.00) + 100.00;
				ci.diastolicBP = rand.Next (81, 100);
				ci.systolicBP = rand.Next (125, 160);
				//SOMETHING TO MAKE THE RASH APPEAR
				int dia = rand.Next (1,5);
				if (dia == 1)
					ci.speak = "Oh this, I think its just a cold";
				if (dia == 2)
					ci.speak = "*cough cough* mmmgghmmm, sorry.  I picked up a cough earlier today";
				if (dia == 3)
					ci.speak = "...ugh.  I think this flight is gettin to me";
				if (dia == 4)
					ci.speak = "I think the altitude's getting to me.  My head is killing me";
				if (dia == 5)
					ci.speak = "I don't know what it is, kust started feeling bad today";
				PatientZero = newInfected;
			}
		
		}
	}

	void Start () {
		//fill array with the passengers of different tags
		for(int i = 1; i <= 35; i++){
			PassengerArray[i-1] = GameObject.FindGameObjectWithTag("Pass"+i);
		}
		//infects first person
		CheckInfection ciF = new CheckInfection();
		ciF = (CheckInfection)PassengerArray[PatientZero].GetComponent("CheckInfection");
		ciF.isInfected = true; ciF.nausea = true; ciF.fever = true; ciF.cough = true; ciF.sneeze = true; ciF.highBP = true; ciF.rash = true;
		ciF.temperature = rand.NextDouble() * (102.50 - 100.00) + 100.00;
		ciF.diastolicBP = rand.Next (81, 100);
		ciF.systolicBP = rand.Next (125, 160);
		//SOMETHING TO MAKE RASH APPEAR
		int diaF = rand.Next (1,5);
		if (diaF == 1)
			ciF.speak = "Oh this, I think its just a cold";
		if (diaF == 2)
			ciF.speak = "*cough cough* mmmgghmmm, sorry.  I picked up a cough earlier today";
		if (diaF == 3)
			ciF.speak = "...ugh.  I think this flight is gettin to me";
		if (diaF == 4)
			ciF.speak = "I think the altitude's getting to me.  My head is killing me";
		if (diaF == 5)
			ciF.speak = "I don't know what it is, kust started feeling bad today";
		
		//begin the spread!!!
		StartCoroutine (InfectionSpread());
	}
}
