using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    public delegate void attackEvent(bool isCanMove);
    public static attackEvent canMove;
    public static attackEvent weaponVisible;

    [Inject]
    private PlayerAnimations _playerAnimations;

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
             _playerAnimations.PlayerSlashAniamte(animator);
        }    
        else
        {
            _playerAnimations.PlayerShotAniamte(animator);
            
        }
        
        weapon.Hit(_shotPoint);
        yield return new WaitForSeconds(0.8f);

        canMove?.Invoke(true);
        weaponVisible?.Invoke(false);

        yield return null;   
    }   

}




