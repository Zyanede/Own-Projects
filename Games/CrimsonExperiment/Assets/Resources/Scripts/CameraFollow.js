#pragma strict
var Player : GameObject;
 
function Update(){
    transform.position.x= Player.transform.position.x;
    transform.position.y= Player.transform.position.y+1.5;
    
}