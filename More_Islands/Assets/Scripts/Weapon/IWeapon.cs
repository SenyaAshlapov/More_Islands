using UnityEngine;
public interface IWeapon 
{     
    GameObject Model{get;}

    Damager Damager{get;}
    string Name{get;}
    float Damage{get;}
    WeaponTypes.weaponType Type{get;}

    void Hit(Transform shotPoint);
    void InitWeapon(Transform position);

}
