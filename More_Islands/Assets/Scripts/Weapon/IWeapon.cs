using UnityEngine;
public interface IWeapon 
{
    GameObject Model{get;}
    string Name{get;}
    Sprite Icon{get;}
    float Damage{get;}
    float CoolDown{get;}
    void Hit();

    void InitWeapon(Transform position);

}
