using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedMeeleWeapon : MonoBehaviour
{
    [SerializeField]private MeleWeaponDATA _weapon;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>())
        {
            other.gameObject.GetComponent<Player>().UpdateWeapon(_weapon);
            Destroy(this.gameObject);
        }
    }
}
