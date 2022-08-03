using UnityEngine;
using Zenject;

public class PlayerAnimations : MonoBehaviour
{

   public void PlayerWalkAnimate(Vector2 moveDirection, Animator animator)
   {
      animator.SetFloat("Horizontal", moveDirection.x);
      animator.SetFloat("Vertical", moveDirection.y);
   }

   public void PlayerSlashAniamte(Animator animator)
   {
      animator.Play("Base Layer.player slash", 0, 0.25f);
   }

   public void PlayerShotAniamte(Animator animator)
   {
      animator.Play("Base Layer.player shot", 0, 0.25f);
   }

   public void PlayerDeadAnnimate(Animator animator)
   {
      animator.SetBool("isDead", true);
   }
   



}
