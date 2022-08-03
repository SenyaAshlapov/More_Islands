using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimate : MonoBehaviour
{
    private Animator _animator;

    public string IDLE_KEY = "idle";
    public string RUN_KEY = "run";
    public string NINJA_RUN_KEY = "ninja_run";
    public string SLASH_KEY = "slash";
    public string SHOT_KEY = "shot";
    public string DEAD_KEY = "dead";
    private string _currentAnimation = "Idle";

    public EnemyAnimate(Animator animator)=> _animator = animator;

    public void ChangeAnimation(string key)
    {
        _animator.SetBool(_currentAnimation, false);  
             
        _animator.SetBool(key, true);
        _currentAnimation = key;    
    }


}
