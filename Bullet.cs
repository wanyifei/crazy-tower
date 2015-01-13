using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private Tower tower;
	private Vector3 currentlocation;
	private int monsternum;
	private float speed;

	public void setTower(Tower input){
				tower = input;
		}

	public void setcurrenlocation(Vector3 current){
				currentlocation = current;
		}

	public void setSpeed(float velocity){
				speed = velocity;
		}

	public bool ifmeet(){
		float distance = Location.getDistanceBetween (currentlocation, tower.gettargetIndex());
		if (distance <= 0.01) 
		{
			return true;
		}
		return false;
	}

	public void Attacking(){
		if (ifmeet ()) {
			tower.gettargetIndex().beAttacked (attack);
		} 
	}

	public void move(){
			Debug.Log ("Move! ");
			Vector3 direction = new Vector3 ();
			direction = Location.calculateNextLocation (currentlocation, tower.gettargetIndex ().getcurrentlocation ());
			transform.Translate (speed * direction);
			currentlocation = Location.calculateNextLocation (currentlocation, tower.gettargetIndex ().getcurrentlocation (), speed);
		}

	void Start () {
		Debug.Log("Bullet start");
	}
	
	// Update is called once per frame
	void Update () {
		if (ifmeet ()) 
		{
			Attacking ();
		}
		else{
		move (tower);
		}
	}
}
