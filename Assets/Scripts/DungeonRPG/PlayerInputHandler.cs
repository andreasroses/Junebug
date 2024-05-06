using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] PlayerCharacter player;
    private float mvtSpeed;
    void Start(){
        mvtSpeed = player.speed;
        //player.animator.speed = mvtSpeed;
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
        if(Input.GetMouseButtonDown(0)){
            player.Attack();
            player.animator.SetTrigger("Attack");
        }
        if(input.y != 0 || input.x != 0){
            player.animator.SetFloat("LastDirX",input.x);
            player.animator.SetFloat("LastDirY",input.y);
        }
        player.animator.SetFloat("Horizontal",input.x);
        player.animator.SetFloat("Vertical",input.y);
        player.animator.SetFloat("Speed",input.sqrMagnitude);
        player.MovePlayer(input);
    }
}
