using UnityEngine;
using System.Collections;

public class MediumMonsters : Monster {

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
		SetMonster (MonsterConstants.MediumMonsterHealth, MonsterConstants.MediumMonsterAttack, MonsterConstants.MediumMonsterSpeed,
		            startlocation, MonsterConstants.MediumMonsterAttackRadius, MonsterConstants.MediumMonsterDelay);
	}
}
