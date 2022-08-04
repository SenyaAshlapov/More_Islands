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

    [SerializeField] Transform _rayPoint;

    [SerializeField] private AudioSource _shotSound;


    public void Attack(Weapon weapon, Animator animator)
    {
        StartCoroutine(playerAttack(weapon,animator));
    }

    private void Update() {
        Debug.DrawRay(_rayPoint.transform.position, _rayPoint.transform.TransformDirection(Vector3.forward), Color.blue);
    }

    private IEnumerator playerAttack(Weapon weapon, Animator animator)
    {
        canMove?.Invoke(false);
        weaponVisible?.Invoke(true);

        if(weapon._weaponType == WeaponTypes.weaponType.meele)
        {
             _playerAnimations.PlayerSlashAniamte(animator);
        }    
        else
        {
            _playerAnimations.PlayerShotAniamte(animator);
            yield return new WaitForSeconds(0.3f);
            _shotSound.Play();
            
        }
        
        weapon.Hit(_rayPoint);
        yield return new WaitForSeconds(0.8f);

        canMove?.Invoke(true);
        weaponVisible?.Invoke(false);

        yield return null;   
    }   

}




