using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	float speed = 5.0f;
	public float jumpForce = 1000.0f;
	GameObject player;
	public static bool right = true;
	bool grounded = true;
	int count = 0;
	// Use this for initialization
 	void Start () {
		
 		player = GameObject.Find("Player");
 	}
	// Update is called once per frame
	void Update () {
		/* if (transform.rotation.x != 0){
			int xR = transform.rotation.x;
			if (xR >= 0)
				 = -xR;
		} */
		animation.CrossFade ("idle");
		var myTransform = transform;
		myTransform.position = new Vector3(myTransform.position.x,myTransform.position.y,-8);
 		Physics.gravity = new Vector3(0,-12.5f,0);
		rigidbody.freezeRotation = true;	
		if((Input.GetKey(KeyCode.RightArrow))||(Input.GetKey(KeyCode.D))){
   		right = true;
   		moveRight ();
  		}
		if((Input.GetKeyDown(KeyCode.RightArrow))||(Input.GetKeyDown(KeyCode.D))){
		transform.forward = new Vector3(-1f, 0f, 0f);
		}
		if((Input.GetKeyDown(KeyCode.LeftArrow))||(Input.GetKeyDown(KeyCode.A))){
		transform.forward = new Vector3(1f, 0f, 0f);
		}
		if((Input.GetKey(KeyCode.LeftArrow))||(Input.GetKey(KeyCode.A))){
		right = false;
   		moveLeft ();
		animation.CrossFade ("Running");
  		}
		if((Input.GetKey(KeyCode.RightArrow))||(Input.GetKey(KeyCode.D))){
		right = true;
   		moveLeft ();
		animation.CrossFade ("Running");
  		}
		if((Input.GetKey(KeyCode.UpArrow))||(Input.GetKey(KeyCode.W))){
			animation.CrossFade ("Jumping");
		}
		if((Input.GetKeyDown(KeyCode.UpArrow))||(Input.GetKeyDown(KeyCode.W))){
		if (count < 2){
			jump ();
			count++;
		}
			/*jump ();
			while (grounded = false){
				if (count < 1){
					jump ();
					count++;
				}
				else count--;*/
  		}
 	}
	/*void jump(){
		//height.y = transform.position.y+5;
		while(transform.position.y < height.y){
        	transform.Translate (Vector3.up * jumpSpeed * Time.deltaTime);
		}
		if(transform.position.y >= height.y){
			transform.Translate(Vector3.down * jumpSpeed * Time.deltaTime);
		}
	}*/
	void jump(){
		rigidbody.AddForce(Vector3.up * jumpForce);
	}
	void moveLeft(){
  		if (right == false)
   		transform.Translate(Vector3.forward* speed * Time.deltaTime);
		animation.CrossFade("Running");

  		//right = false;
 	}
	void moveRight(){
  		if (right == true)
   		transform.Translate(Vector3.forward * speed * Time.deltaTime);
		animation.CrossFade("Running");
  		//right = true;
 	}
	
	void OnCollisionEnter(Collision other){
		count = 0;
	}
}
