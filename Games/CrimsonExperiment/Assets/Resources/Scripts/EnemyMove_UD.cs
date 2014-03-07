using UnityEngine;
using System.Collections;

public class EnemyMove_UD: MonoBehaviour {
	Vector3 startPos;
	Vector3 aPos, bPos;
	bool up;
	public static float range = 5;
	public static float speed = 3;
	// Use this for initialization
	void Start () {
		startPos = this.transform.position;
		aPos = new Vector3(startPos.x, (startPos.y+range), startPos.z);
		bPos = new Vector3(startPos.x, (startPos.y-range), startPos.z);
		up = false;
	}
	
	// Update is called once per frame
	void Update () {
		patrol ();	
	}
	
	void moveUp(){
		transform.Translate (Vector3.up * speed * Time.deltaTime);
	}
	void moveDown(){
		transform.Translate (Vector3.down * speed * Time.deltaTime);
	}
	
	void patrol(){
		if(up == false){
			moveDown ();	
		} else
			moveUp ();

		
		if (transform.position.y <= bPos.y){
			up = true;
		}
		
		if (transform.position.y >= aPos.y){
			up = false;
		}
		
	}


}
