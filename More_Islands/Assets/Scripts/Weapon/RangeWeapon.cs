using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : MonoBehaviour, IWeapon
{
    public WeaponDATA Weapon{get;set;}
    public void Hit(){
        Debug.Log("rangeWeapon");
    }
}
