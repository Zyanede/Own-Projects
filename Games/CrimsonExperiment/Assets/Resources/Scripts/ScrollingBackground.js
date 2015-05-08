#pragma strict
//scrolls the background
/*var scrollSpeed = .00;
private var offset = Vector2.zero;

function Update () {
	//Scrolls background L -> R when player moves "backward"
	if(Input.GetKey("left")){
		offset.x += scrollSpeed;
		renderer.material.SetTextureOffset ("_MainTex", Vector3.right);
	}
	//Scrolls backroung R -> L when player moves "forward"
	if(Input.GetKey("right")){
		offset.x -= scrollSpeed;
		renderer.material.SetTextureOffset ("_MainTex", Vector3.left);
	}
}  */
var scrollSpeed = .00;
var size = .00;

function Update () {
	if(Input.GetKey("left")){
		transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
		if(transform.position.x >= size){
			transform.position.x = 0;
		}
	}
if(Input.GetKey("right")){
		transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
		if(transform.position.x <= 0 - size){
			transform.position.x = - 0.01;
		}
	}
}