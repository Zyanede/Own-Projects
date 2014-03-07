using UnityEngine;
using System.Collections;

public class PlayerAttack_Shoot : MonoBehaviour {
	public Rigidbody bullet,melee;
	public float bulletSpeed = 10;
	public float superBulletSpeed = 20;
	Rigidbody clone;
	GameObject player;
	public AudioClip shooting;
	public AudioClip swiping;

	
	void Start () {
		player = GameObject.Find("Player");
	}
	
	void Update () {
		shoot ();
		attack ();

	}//update
	
	void shoot(){
			
    	if ((Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown (KeyCode.RightShift)) && MovePlayer.right == false){
			audio.PlayOneShot(shooting);
			Vector3 pos = new Vector3(transform.position.x+.5f, transform.position.y, transform.position.z);
    	// Instantiate the projectile at the position and rotation of this transform
    		clone = (Rigidbody)Instantiate(bullet, pos, transform.rotation);
    	// Add force to the cloned object in the object's forward direction
    		clone.rigidbody.AddForce(-Vector3.left * bulletSpeed, ForceMode.Impulse);
			PlayerHealth.curHP = PlayerHealth.curHP - 2;
			print ("player HP = " + PlayerHealth.curHP);
			
		}//if
    	else if ((Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown (KeyCode.RightShift)) && MovePlayer.right == true){
			audio.PlayOneShot(shooting);
			Vector3 pos = new Vector3(transform.position.x-.5f, transform.position.y, transform.position.z);
    	// Instantiate the projectile at the position and rotation of this transform
    		clone = (Rigidbody)Instantiate(bullet, pos, transform.rotation);
    	// Add force to the cloned object in the object's forward direction
    		clone.rigidbody.AddForce(-Vector3.right * bulletSpeed, ForceMode.Impulse);
			PlayerHealth.curHP = PlayerHealth.curHP - 2;
			print ("player HP = " + PlayerHealth.curHP);
			
		}//if
		else if ((Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown (KeyCode.RightShift)) && MovePlayer.right == false && PlayerHealth.isSuper == true){
			audio.PlayOneShot(shooting);
			Vector3 pos = new Vector3(transform.position.x+.5f, transform.position.y, transform.position.z);
    	// Instantiate the projectile at the position and rotation of this transform
    		clone = (Rigidbody)Instantiate(bullet, pos, transform.rotation);
    	// Add force to the cloned object in the object's forward direction
    		clone.rigidbody.AddForce(-Vector3.left * superBulletSpeed, ForceMode.Impulse);
		}
		else if ((Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown (KeyCode.RightShift)) && MovePlayer.right == true && PlayerHealth.isSuper == true){
			audio.PlayOneShot(shooting);
			Vector3 pos = new Vector3(transform.position.x-.5f, transform.position.y, transform.position.z);
    	// Instantiate the projectile at the position and rotation of this transform
    		clone = (Rigidbody)Instantiate(bullet, pos, transform.rotation);
    	// Add force to the cloned object in the object's forward direction
    		clone.rigidbody.AddForce(-Vector3.right * superBulletSpeed, ForceMode.Impulse);
		}
	}
	void attack(){
		if (Input.GetKeyDown("space") && MovePlayer.right == true) {
			audio.PlayOneShot(swiping);
			Vector3 pos = new Vector3(transform.position.x-.5f, transform.position.y, transform.position.z);
			clone = (Rigidbody)Instantiate(melee, pos, transform.rotation);
			PlayerHealth.curHP--;
			print ("player HP = " + PlayerHealth.curHP);
		}
		else if (Input.GetKeyDown("space") && MovePlayer.right == false) {
			audio.PlayOneShot(swiping);
			Vector3 pos = new Vector3(transform.position.x+.5f, transform.position.y, transform.position.z);
			clone = (Rigidbody)Instantiate(melee, pos, transform.rotation);
			PlayerHealth.curHP--;
			print ("player HP = " + PlayerHealth.curHP);
		}
		else if (Input.GetKeyDown("space") && MovePlayer.right == true && PlayerHealth.isSuper == true) {
			audio.PlayOneShot(swiping);
			Vector3 pos = new Vector3(transform.position.x-.5f, transform.position.y, transform.position.z);
			clone = (Rigidbody)Instantiate(melee, pos, transform.rotation);
		
		}
		else if (Input.GetKeyDown("space") && MovePlayer.right == false && PlayerHealth.isSuper == true) {
			audio.PlayOneShot(swiping);
			print ("Player did melee!");
			Vector3 pos = new Vector3(transform.position.x+.5f, transform.position.y, transform.position.z);
			clone = (Rigidbody)Instantiate(melee, pos, transform.rotation);
		}
	}
}//cla
