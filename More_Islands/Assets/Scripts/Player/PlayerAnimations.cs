using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerAnimations : MonoBehaviour
{
   public void PlayerWalkAnimate(Vector2 moveDirection, Animator animator){
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
   }
}
