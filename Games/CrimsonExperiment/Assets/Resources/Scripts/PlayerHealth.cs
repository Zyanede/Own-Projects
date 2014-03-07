using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public static float CountAlucard = 0;
	float maxHP = 20;
	public static float curHP;
	public static bool isSuper = false;
	public float healthBarLength,superBarLength;
	
	//Plane clone;
	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width /2;
		superBarLength = Screen.width /2;
		curHP = maxHP;
		isSuper = false;
		CountAlucard = 0;
		StartCoroutine( Super() );
	}
	
	// Update is called once per frame
	void OnGUI(){
	    GUI.Box (new Rect(15,10, healthBarLength, 25), "Player Health               " + curHP + "/" + maxHP);   	
		GUI.Box (new Rect(15,40, superBarLength, 25), "Enemy Health               " + CountAlucard + "/" + 20);   
	}
	void Update () {
		if(curHP <= 0){
			Destroy (gameObject);
		} 
		else if (curHP > maxHP){
			curHP = maxHP;
			print ("player HP = " + curHP);
		}
		else if (CountAlucard >= 5){
			//Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1.5, transform.position.z);
			isSuper = true;
			//clone = (Plane)Instantiate(BloodyScreen, pos, transform.rotation);
		}
		else if(CountAlucard <= 0){
			isSuper = false;
		}
		healthBarLength =(Screen.width /2) * (curHP / (float)maxHP);
		superBarLength = (Screen.width/2)* (CountAlucard / 5f);
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Enemy"){
			curHP--;
			print ("player HP = " + curHP);
			CountAlucard = 0;
			print ("CountAlucard = " + CountAlucard);

		} 
		else if(other.gameObject.tag == "Blood"){
			Destroy(other.gameObject);
			curHP = maxHP;
			print ("player HP = " + curHP);
			CountAlucard++;
			print ("CountAlucard = " + CountAlucard);
			/*if(CountAlucard >= maxHP){
				CountAlucard++;	
				print ("DraculaRageMode!!! in " + (5 - (CountAlucard -maxHP)));
			}
			else if(CountAlucard < maxHP){
				CountAlucard = curHP;	
				print ("DraculaRageMode!!! in " + (5 - (CountAlucard -maxHP)));
				isSuper = false;
			}
			else if (CountAlucard >= maxHP+5){
				isSuper = true;
				print ("DraculaRageMode ACTIVATE!!!");
			}*/
		} 
		else if(other.gameObject.tag == "EnemyBullet"){
			curHP--;
			print ("player HP = " + curHP);
			CountAlucard = 0;
			print ("CountAlucard = " + CountAlucard);
		}
		else if(other.gameObject.tag == "Sewage"){
			curHP-=curHP-5;
		}
		else if(other.gameObject.tag == "SceneChange"){
				Application.LoadLevel("lastLevel");
		}
	}
	IEnumerator Super(){
		while(isSuper = true){
		CountAlucard--;
		yield return new WaitForSeconds(10);
		}
	
	}
}