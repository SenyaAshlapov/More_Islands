using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedRangeWeapon : MonoBehaviour
{
    [SerializeField]private RangeWeaponDATA _weapon;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>())
        {
            other.gameObject.GetComponent<Player>().UpdateWeapon(_weapon);
            Destroy(this.gameObject);
        }
    }
}
