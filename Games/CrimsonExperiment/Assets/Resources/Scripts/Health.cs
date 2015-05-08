using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
 public int maxHealth = 100;
 public int curHealth = 100;
 double damageTimer = 0.0;
 public float healthBarLength;
 public GameObject Enemy;
 public GameObject Blood;
 // Use this for initialization
 void Start () {
  healthBarLength = Screen.width /2;
 }
 
 // Update is called once per frame
 void Update () {
  updateHealth ();
  if(curHealth == 0)
   Destroy(gameObject); 
 }

 
 void updateHealth(){
  if(Input.GetKeyDown(KeyCode.Delete)) 
   changeHP(-1);

  if(curHealth == 0) 
   Destroy(gameObject);
  if(curHealth > maxHealth) 
   curHealth = maxHealth;
  
  healthBarLength =(Screen.width /2) * (curHealth / (float)maxHealth);

 }
 
 void DoDamage(){
  if(damageTimer == 0.0){
   damageTimer = Time.time;
  } 
  if((damageTimer + 0.5) > Time.time){
   return;
  } else {
   changeHP (-10);
   damageTimer = Time.time;
  }
 }
 void changeHP(int change) {
  curHealth += change;
 }
 
 void OnTriggerStay(Collider collider){
 	if(collider.ToString() == "Enemy")
 		DoDamage ();
	if(collider.ToString() == "Blood")
		changeHP(10);
  }
 // This function checks if the player has entered a trigger
 /*void OnTriggerStay(Collider other)
 {
  // The switch statement checks what tag the other gameobject is, and reacts accordingly.
  switch(other.gameObject.tag)
  {
  case "Potion":
   changeHP(10);
   break;
  case "Enemy":
   DoDamage();
   break;
  }
 }*/
 //Displays health on the screen
 void OnGUI(){
     GUI.Box (new Rect(10,10, healthBarLength, 20), curHealth + "/" + maxHealth);   
    }
}