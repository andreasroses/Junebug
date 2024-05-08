using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationUpdater : MonoBehaviour{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool isFlipped = false;
    private bool isWalking = false;
    private bool isAttacking = false;
    public void SwitchArmored(){
        animator.SetBool("isModern",false);
        animator.SetBool("isArmored",true);
    }

    public void SwitchModern(){
        animator.SetBool("isModern",true);
        animator.SetBool("isArmored",false);
        SceneChanged();
    }
    public void SceneChanged(){
        animator.SetTrigger("SceneChange");
    }
    public void UpdateDirFloats(float x, float y){
        animator.SetFloat("LastDirX",x);
        animator.SetFloat("LastDirY",y);
    }
    public void UpdateSpeed(Vector2 input){
        animator.SetFloat("Speed",input.sqrMagnitude);
    }
    public void PlayerAttack(){
        animator.SetTrigger("Attack");
    }
    public void SwitchWalk(){
        isWalking = !isWalking;
        animator.SetBool("isWalking",isWalking);
    }
    public void EnemyWander(){
        animator.SetBool("isPlayerClose",false);
    }
    public void EnemyDeath(){
        animator.SetBool("isDead",true);
    }
    public void SwitchAttacking(){
        isAttacking = !isAttacking;
        animator.SetBool("isPlayerClose",isAttacking);
    }
    public void EnemyAttack(){
        animator.SetTrigger("Attack");
        SwitchAttacking();
    }
    public void MirrorChar(){
        isFlipped = !isFlipped;
        spriteRenderer.flipX = isFlipped;
    }

    public void DroneUpdateDirs(float x){
        if(x < 0){
            MirrorChar();
        }
        else if(isFlipped){
            MirrorChar();
        }
    }
}
