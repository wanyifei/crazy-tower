using UnityEngine;
using System.Collections;

public class SmallMonsters : Monster {

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
		SetMonster (MonsterConstants.SmallMonsterHealth, MonsterConstants.SmallMonsterAttack, MonsterConstants.SmallMonsterSpeed,
		      startlocation, MonsterConstants.SmallMonsterAttackRadius, MonsterConstants.SmallMonsterDelay);
	}

}