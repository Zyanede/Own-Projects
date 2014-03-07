using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	public Transform Enemy;
	public int delay;
	GameObject target;
	
	public void Start(){
	target = GameObject.FindWithTag("Player");
	}
	
	public void update(){
		target = GameObject.FindWithTag("Player");
		if (target.transform.position.x <= transform.position.x){Spawn ();}
	}
	
	/*public void Awake(){
	InvokeRepeating("Spawn", 0, delay);
	}*/
	
	private void Spawn (){
		Instantiate (Enemy, transform.position, transform.rotation);

	}
}

