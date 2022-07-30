using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleWeapon : MonoBehaviour, IWeapon
{
    public WeaponDATA Weapon{get;set;}
    public void Hit(){
        Debug.Log("meleWeapon");
    }


}
