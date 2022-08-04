using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedWeapon : MonoBehaviour
{
    [SerializeField]private Weapon _weapon;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.GetComponent<Player>())
        {
            other.gameObject.GetComponent<Player>().UpdateWeapon(_weapon);
            Destroy(this.gameObject);
        }
    }
    
}
