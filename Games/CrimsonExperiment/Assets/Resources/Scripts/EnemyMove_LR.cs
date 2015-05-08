using UnityEngine;
using System.Collections;

public class EnemyMove_LR : MonoBehaviour {
	Vector3 startPos;
	Vector3 aPos, bPos;
	bool right;
	public static float range = 3;
	public static float speed = 3;
	// Use this for initialization
	void Start () {
		startPos = this.transform.position;
		aPos = new Vector3(startPos.x + range, startPos.y, startPos.z);
		bPos = new Vector3(startPos.x - range, startPos.y, startPos.z);
		right = true;
	}
	
	// Update is called once per frame
	void Update () {
		patrol();
	}
	
	
	
	void moveRight(){
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
	void moveLeft(){
		transform.Translate (Vector3.left * speed * Time.deltaTime);
	}
	
	
	void patrol(){
		if(right == false){
			moveLeft();	
		} else  
			moveRight ();
		
		
		if(transform.position.x <= bPos.x){
			right = false;
		}
		if(transform.position.x >= aPos.x){
			right = true;	
		}
		
		
	}
}
