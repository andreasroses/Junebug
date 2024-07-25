using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }
public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] PlayerCharacter player;
    private Transform playerTransform;
    void Start(){
        playerTransform = player.transform;
    }
    [SerializeField] AnimationUpdater au;
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
            au.PlayerAttack();
            player.Attack();
        }
        if(input.x != 0){
            au.UpdateDirFloats(input.x,0);
            if(input.x < 0){
                player.RotateBladeCollider(Direction.Left);
            }
            else{
                player.RotateBladeCollider(Direction.Right);
            }
        }
        else if(input.y != 0){
            au.UpdateDirFloats(0,input.y);
            if(input.y < 0){
                player.RotateBladeCollider(Direction.Down);
            }
            else{
                player.RotateBladeCollider(Direction.Up);
            }
        }
        au.UpdateSpeed(input);
        player.MovePlayer(input);
    }
}