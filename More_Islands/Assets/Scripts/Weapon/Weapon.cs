using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDATA", menuName = "More_Islands/WeaponDATA", order = 0)]
public class Weapon : ScriptableObject
{
    
    public GameObject _model;
    public float _damage;
    public float _range;
    public WeaponTypes.weaponType _weaponType;

    public void Hit(Transform point)
    {
        RaycastHit hit;
        if (Physics.Raycast(point.transform.position, point.transform.TransformDirection(Vector3.forward), out hit))
        {         
            if(hit.transform.gameObject.GetComponent<Enemy>()){
                hit.transform.gameObject.GetComponent<Enemy>().GetDamage(_damage);
            }
        }
    }

    public void InitWeapon(Transform position)
    {
        foreach (Transform child in position)
        {
            Destroy(child.gameObject);
        }
        Instantiate(_model, position);
       
    }
}
