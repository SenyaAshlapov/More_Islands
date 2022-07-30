using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "WeaponDATA", menuName = "More_Islands/WeaponDATA", order = 0)]
public class WeaponDATA : ScriptableObject 
{
    public GameObject Model;
    public string Name;
    public Sprite Icon;
    public float Damage;
    public float CoolDown;
}
