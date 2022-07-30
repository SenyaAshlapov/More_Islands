using UnityEngine;
using System.Collections;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    public void Attack(IWeapon weapon)
    {
        weapon.Hit();
    }
}
