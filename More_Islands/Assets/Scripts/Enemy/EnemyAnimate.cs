using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimate : MonoBehaviour
{
    private Animator _animator;

    private string IDLE_KEY = "idle";
    private string RUN_KEY = "run";
    private string NINJA_RUN_KEY = "ninja_run";
    private string SLASH_KEY = "slash";
    private string SHOT_KEY = "shot";
    private string DEAD_KEY = "dead";
    private string _currentAnimation;

    public EnemyAnimate(Animator animator)=> _animator = animator;
    public void AnimateIdle()
    {
        //_animator.Play("Base Layer.enemy idle", 0, 0.25f);
        changeAnimation(IDLE_KEY);
        Debug.Log("idle animation");
    }

    public void AnimateMove()
    {
        //_animator.Play("Base Layer.enemy run", 0, 0.25f);
        changeAnimation(RUN_KEY);
        Debug.Log("move animation");
    }
    public void AnimateSlash()
    {
        //_animator.Play("Base Layer.enemy slash", 0, 0.25f);
        changeAnimation(SLASH_KEY);
        Debug.Log("slash animation");
    }

    public void AnimateShot()
    {
       // _animator.Play("Base Layer.enemy shot", 0, 0.25f);
       changeAnimation(SHOT_KEY);
        Debug.Log("shot animation");
    }

    public void AnimateDead()
    {
        //_animator.Play("Base Layer.enemy dead", 0, 0.25f);
        changeAnimation(DEAD_KEY);
        Debug.Log("dead animation");
    }

    private void changeAnimation(string key)
    {
        if(_currentAnimation != null){
            _animator.SetBool(_currentAnimation, false);
        }
        _animator.SetBool(key, true);
        _currentAnimation = key;
    }

}
