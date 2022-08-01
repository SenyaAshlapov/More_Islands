using UnityEngine;
public interface IWeapon 
{     
    GameObject Model{get;}

    Damager Damager{get;}
    string Name{get;}
    Sprite Icon{get;}
    float Damage{get;}
    float CoolDown{get;}
    WeaponTypes.weaponType Type{get;}

    void Hit(Transform shotPoint);
    void InitWeapon(Transform position);

}
