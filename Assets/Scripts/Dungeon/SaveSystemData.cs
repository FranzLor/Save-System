using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveSystemData
{
    public int strength, defence;

    public int level, currentXP, xpToLevel;

    public int currentHealth, maxHP;

    public DungeonWeaponController.weaponType currentWeapon;

    public string currentLevel;
}
