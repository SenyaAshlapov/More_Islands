using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    public delegate void attackEvent(bool isCanMove);
    public static attackEvent canMove;
    public void Attack(IWeapon weapon, Animator animator)
    {
        StartCoroutine(playerAttack(weapon,animator));
    }

    private IEnumerator playerAttack(IWeapon weapon, Animator animator){
        canMove?.Invoke(false);
        if(weapon.Type == WeaponTypes.weaponType.meele)
        {
            animator.Play("Base Layer.player slash", 0, 0.25f);
        }
        else
        {
            animator.Play("Base Layer.player shot", 0, 0.25f);
        }
        weapon.Hit();
        yield return new WaitForSeconds(0.8f);
        canMove?.Invoke(true);

        yield return null;
    }

}




