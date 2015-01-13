using UnityEngine;
using System.Collections;

public class BigMonsters : Monster {

	private Location startlocation;
	
	public void setStart(Location start)
	{
		startlocation = start;
	}
	public Location getStart()
	{
		return startlocation;
	}
	
	void start(){
		SetMonster (MonsterConstants.BigMonsterHealth, MonsterConstants.BigMonsterAttack, MonsterConstants.BigMonsterSpeed,
		            startlocation, MonsterConstants.BigMonsterAttackRadius, MonsterConstants.BigMonsterDelay);
	}
}
