using UnityEngine;
using System.Collections;

public class MovePlayer2 : MonoBehaviour {
	float speed = 5.0f;
	public float jumpForce = 1000.0f;
	GameObject player;
	public static bool right = true;
	bool grounded = true;
	int count = 0;
	bool isJump = false;
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
		
		var myTransform = transform;
		myTransform.position = new Vector3(myTransform.position.x,myTransform.position.y,-8);
 		Physics.gravity = new Vector3(0,-12.5f,0);
		rigidbody.freezeRotation = true;	
		if((Input.GetKey(KeyCode.RightArrow))||(Input.GetKey(KeyCode.D))){
   		right = true;
   		moveRight ();
  		}
		if((Input.GetKey(KeyCode.LeftArrow))||(Input.GetKey(KeyCode.A))){
		right = false;
   		moveLeft ();
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
   		transform.Translate(Vector3.left * speed * Time.deltaTime);
  		//right = false;
 	}
	void moveRight(){
  		if (right == true)
   		transform.Translate(Vector3.right * speed * Time.deltaTime);
  		//right = true;
 	}
	
	void OnCollisionEnter(Collision other){
		
		if(isJump == true && right == true){
			rigidbody.velocity = Vector3.right * speed * Time.deltaTime;
			isJump = false;
		}
		if(isJump == true && right == false){
			rigidbody.velocity = Vector3.left * speed * Time.deltaTime;
			isJump = false;
		}
		
		count = 0;
	}
}