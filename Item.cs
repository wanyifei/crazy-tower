using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	private bool isSlow;
	private int numSlow;
	private bool isUpAttack;
	private int numAttack;
	private bool isUpHealth;
	private int numHealth;
	private int time;

	public void setNSlow(int num)
	{
		numSlow=num;
	}
	
	public int getNSlow()
	{
		return numSlow;
	}
	public void setNAttack(int num)
	{
		numAttack=num;
	}
	
	public int getNAttack()
	{
		return numAttack;
	}
	public void setNHealth(int num)
	{
		numHealth=num;
	}
	
	public int getNHealth()
	{
		return numHealth;
	}

	public void setSlow()
	{
		isSlow=true;
	}

	public bool getSlow()
	{
			return isSlow;
		}

	public void setUpAttack()
	{
		isUpAttack=true;
	}

	public bool getAttack()
	{
				return isUpAttack;
		}

	public void setUpHealth()
	{
				isUpHealth = true;
		}

	public bool getHealth()
	{
				return isUpHealth;
		}

	public int getTime()
	{
				return time;
		}
	public void setTarget(int number)
	{
				time = number;
		}


	public void Sloweffect (Monster[] monsters)
	{
		if ((isSlow) && (numSlow > 0)) {
				for (int i=0; i<monsters.Length; i++) {
						monsters [i].setDelay (5000);
				}
				numSlow--;
		}
	}

	public void UpAttackeffect (Tower[] towers, int time){
		if((isUpAttack)&&(numAttack)>0)
		{
			for (int i=0; i<towers.Length; i++) {
				towers[i].setAttack(towers[i].getAttack()+5);
			}
			numAttack--;
		}
		while (time>=0) {
			time--;
		}
		for (int i=0; i<towers.Length; i++) {
			towers[i].setAttack(towers[i].getAttack()-5);
		}
	}

	public void UpHealthEffect (Tower[] towers){
		if((isUpHealth)&&(numHealth)>0)
		{
			for (int i=0; i<towers.Length; i++) {
				towers[i].setHealth(towers[i].getHealth()+5);
			}
			numHealth--;
		}
	}

	// Use this for initialization
	void Start () {
		numSlow = 0;
		numHealth = 0;
		numAttack = 0;
		isSlow = false;
		isUpAttack = false;
		isUpHealth = false;
	}
	
	// Update is called once per frame
	/*void Update () {
		if (isSlow) {

		}
	}*/
}
