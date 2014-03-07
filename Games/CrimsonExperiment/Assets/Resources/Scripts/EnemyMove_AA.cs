using UnityEngine;
using System.Collections;

public class EnemyMove_AA : MonoBehaviour {
	float speed = 2.0f;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = (GameObject)GameObject.FindGameObjectWithTag("Player");
	}
	
	//Moves the enemy when within distance of player
	void Update () {
		var spacebtwn = Vector3.Distance(transform.position, player.transform.position);
		var direction = player.transform.position-transform.position;
//		direction.y=0;
		direction.z=0;
		if((spacebtwn <= 8)&&(spacebtwn >= 2)){
			var moveVector = direction.normalized * speed * Time.deltaTime;
			transform.position += moveVector;
/*			if(direction.magnitude>=0)
				moveLeft();
			if(direction.magnitude<=0)
				moveRight();
*/		}
	}
/*	
	void moveLeft(){
		transform.Translate(Vector3.left * speed * Time.deltaTime);
	}
	
	void moveRight(){
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
*/	
}
