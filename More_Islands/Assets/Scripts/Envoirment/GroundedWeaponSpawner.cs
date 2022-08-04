using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedWeaponSpawner : MonoBehaviour
{
    [SerializeField]private List<GameObject> _groundedWeapon = new List<GameObject>();
    void Start()
    {
        spawnWeapon();
    }

    private void spawnWeapon(){
        int count = _groundedWeapon.Count;

        int randomWeapon = Random.Range(0, count);
        Instantiate(_groundedWeapon[randomWeapon], transform.position, Quaternion.identity);
    }
}
