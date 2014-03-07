using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public GameObject blood;
	public float enemyHealth=10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Bullet"){
//			GameObject clone = (GameObject)Instantiate(blood, transform.position, transform.rotation);
			//Destroy(this.gameObject);
			enemyHealth-=1;
		}
		if(other.gameObject.tag == "PlayerMelee"){
	//		GameObject clone = (GameObject)Instantiate(blood, transform.position, transform.rotation);
			//Destroy(this.gameObject);
			enemyHealth-=3;
		}
		if(enemyHealth<=0){
			GameObject clone = (GameObject)Instantiate(blood, transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
	}
}
