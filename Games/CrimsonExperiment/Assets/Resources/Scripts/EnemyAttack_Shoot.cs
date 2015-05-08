using UnityEngine;
using System.Collections;

public class EnemyAttack_Shoot : MonoBehaviour {
	public Rigidbody bullet;
	public float bulletSpeed = 5;
	public float range = 3;
	Rigidbody clone;
	GameObject player;
	Vector3 playPos, enemPos;
	bool left, under;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		StartCoroutine( Shoot() );
		under = true;
	}
	
	// Update is called once per frame
	void Update () {
		playPos = player.transform.position;
		enemPos = transform.position;
		
		if( (playPos.x <= enemPos.x + range) && (playPos.x >= enemPos.x + .5f) ){
			left = true;
			under = false;
		} else if( (playPos.x >= enemPos.x - range) && (playPos.x <= enemPos.x - .5f) ){
			left = false;
			under = false;
		} else 
			under = true;
		
	}
	
	IEnumerator Shoot(){
		while(true){
		shootLeft ();
		shootRight ();
		yield return new WaitForSeconds(1);
		}
		
	}
	
	void shootLeft(){
		if(left == true && under == false){
			Vector3 pos = new Vector3(transform.position.x+1.2f, transform.position.y, transform.position.z);
    	// Instantiate the projectile at the position and rotation of this transform
    		clone = (Rigidbody)Instantiate(bullet, pos, transform.rotation);
    	// Add force to the cloned object in the object's forward direction
    		clone.rigidbody.velocity = (player.transform.position - transform.position) * bulletSpeed;
		}
		
	}
	
	void shootRight(){
		if(left == false && under == false){
			Vector3 pos = new Vector3(transform.position.x-1.2f, transform.position.y, transform.position.z);
    	// Instantiate the projectile at the position and rotation of this transform
    		clone = (Rigidbody)Instantiate(bullet, pos, transform.rotation);
    	// Add force to the cloned object in the object's forward direction
    		clone.rigidbody.velocity = (player.transform.position - transform.position) * bulletSpeed;
		}
	}
	
}
