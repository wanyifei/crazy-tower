using UnityEngine;
using System.Collections;
using System.Timers;

public class Monster : MonoBehaviour {

	private int blood;
	private int attack;
	private double speed;
	private Location currentlocation;
	private Location desitination;
	private bool alive;
	private int id;
	private double delay;
	private double attackRadius;
	public int target;
	GameObject thisobject;

	public void beattacked (int enemyAttack) {
		if (this.blood >= enemyAttack) {
				this.blood -= enemyAttack;
			} 
		else {
				this.blood = 0;
				alive = false;
		}
	}
	// targetnumber set and get
	public void setTargets(int aim)
	{
				target = aim;
		}
	public int getTargets()
	{
				return target;
		}
	// attackRadius set and get
	public void setAttackradius(double radius)
	{
				attackRadius = radius;
		}
	public double getAttackradius()
	{
				return attackRadius;
		}
	// Attack set and get
	public void setAttack(int attackvalue)
	{
		attack = attackvalue;
	}

	public int getAttack()
	{
			return attack;
	}
	//Blood set and get
	public void setBlood(int bloodvalue)
	{
				blood = bloodvalue;
		}

	public int getBlood()
	{
				return blood;
		}
	//Speed set and get
	public void setSpeed(double speedvalue)
	{
				speed = speedvalue;
		}

	public double getSpeed()
	{
				return speed;
		}
	//Current Location set and get
	public void setCurrentlocation(Location start)
	{
				currentlocation = start;
		}
	public Location getCurrentlocation()
	{
				return currentlocation;
		}
	//Destination set and get
	public void setDesitination(Location end)
	{
				desitination = end;
		}
	public Location getDesitination()
	{
				return desitination;
		}
	//alive set and get
	public void setAlive(bool life)
	{
				alive = life;
		}
	public bool getAlive()
	{
				return alive;
		}
	//delay set and get
	public void setDelay(double time)
	{
				delay = time;
		}
	public double getDelay()
	{
				return delay;
		}
	//ctor in children
	public void SetMonster(int bloodvalue, int attackvalue, double speedvalue, Location start, double Radius, double delayvalue)
	{
		blood=bloodvalue;
		attack=attackvalue;
		speed=speedvalue;
		currentlocation=start;
		attackRadius=Radius;
		delay = delayvalue;
		gameObject.tag = "Monster #" + id;
		id++;
	}

	public Location getDes(Tower[] towers)
	{
		for (int i=0; i<towers.Length; i++) {
						if (towers [i].getAlive ()) {
								double distance = Location.getDistanceBetween (currentlocation, towers [i].getLocation ());
								if (distance <= towers [i].getTauntRadius ()) {
										//set target
										target=i;
										return towers [i].getLocation();
								}
						}
				}
		return towers[0].getLocation(); //base tower!
	}
	

	bool ifmeet(){
		double distance = Location.getDistanceBetween (currentlocation, desitination);
		if (distance <= attackRadius) 
		{
				return true;
			}
		return false;
	}
	

	public void updatemonster(Tower[] towers){
				if (!alive) {
						//delete (invisible)
						return;
				}
				if (ifmeet ()) {
					towers [target].beAttacked (attack);
				} 
			    else {
					transform.Translate (new Vector3 ((float)currentlocation.getX (), (float)currentlocation.getY (), 0.0f));
					desitination = getDes (towers);
					currentlocation = Location.calculateNextLocation (currentlocation, desitination, speed);
				}
		}
		
		//pause for a while
		/*Timer attackPause=new Timer(1000);
	attackPause.Tick += new System.Timer.ElapsedEventHandler(pause);
	attackPause.AutoReset = false;
	attackPause.Enabled = true;

	public void pause(object source, System.Timers.ElapsedEventArgs e){
		Debug.Log("Pause Success");
	}*/

	// Update is called once per frame
	void Update () {
		if(!alive){
			Destroy(this);
			return;
		}
		if (!IsInvoking ("updatemonster")){
			InvokeRepeating ("updatemonster", 1.0f, delay);
		}
}
