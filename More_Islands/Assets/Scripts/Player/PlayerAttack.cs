using UnityEngine;
using System.Collections;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    public void Attacking(IWeapon  weapon){
        weapon.Hit();
    }
}
