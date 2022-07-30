using UnityEngine;
public interface IWeapon 
{
    GameObject Model{get;set;}
    string Name{get;set;}
    Sprite Icon{get;set;}
    float Damage{get;set;}
    float CoolDown{get;set;}
    void Hit();

    void InitWeapon(Transform position);

}
