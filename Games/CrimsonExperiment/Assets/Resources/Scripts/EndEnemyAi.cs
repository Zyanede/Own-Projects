using UnityEngine;
using System.Collections;

public class EndEnemyAi : MonoBehaviour {
	float speed = 4.0f;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = (GameObject)GameObject.FindGameObjectWithTag("Player");
	}
	
	//Moves the enemy when within distance of player
	void Update () {
		var spacebtwn = Vector3.Distance(transform.position, player.transform.position);
		var direction = player.transform.position-transform.position;
		direction.z=0;
		if((spacebtwn <= 10)/*&&(spacebtwn >= 1)*/){
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
