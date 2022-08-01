using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    public delegate void attackEvent(bool isCanMove);
    public static attackEvent canMove;
    public static attackEvent weaponVisible;

    [SerializeField]private Transform _shotPoint;

    public void Attack(IWeapon weapon, Animator animator)
    {
        StartCoroutine(playerAttack(weapon,animator));
    }

    private IEnumerator playerAttack(IWeapon weapon, Animator animator)
    {
        canMove?.Invoke(false);
        weaponVisible?.Invoke(true);

        if(weapon.Type == WeaponTypes.weaponType.meele)
        {
            animator.Play("Base Layer.player slash", 0, 0.25f);
        }    
        else
        {
            animator.Play("Base Layer.player shot", 0, 0.25f);
        }
        weapon.Hit(_shotPoint);
        yield return new WaitForSeconds(0.8f);

        canMove?.Invoke(true);
        weaponVisible?.Invoke(false);

        yield return null;   
    }   

}




