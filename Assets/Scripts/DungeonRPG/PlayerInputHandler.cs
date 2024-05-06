using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] PlayerCharacter player;
    [SerializeField] private Animator animator;
    private float mvtSpeed;
    void Start(){
        mvtSpeed = player.speed;
        //animator.speed = mvtSpeed;
    }
    void Update()
    {
        Vector3 input = Vector3.zero;

        if(Input.GetKey(KeyCode.W)){
            input.y += 1;
        }
        if(Input.GetKey(KeyCode.S)){
            input.y += -1;
        }
        
        if(Input.GetKey(KeyCode.A)){
            input.x += -1;
        }
        if(Input.GetKey(KeyCode.D)){
            input.x += 1;
        }
        if(Input.GetKeyDown(KeyCode.E)){
            player.CheckInteract();
        }
        animator.SetFloat("Horizontal",input.x);
        animator.SetFloat("Vertical",input.y);
        animator.SetFloat("Speed",input.sqrMagnitude);
        player.MovePlayer(input);
    }
}
