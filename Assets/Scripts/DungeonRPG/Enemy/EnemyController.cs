using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AttackEvent : UnityEvent<float> {}
public class EnemyController : MonoBehaviour, Interactable
{
    private int HitsLanded = 0;
    public EnemyStateMachine stateMachine;
    public Transform playerTransform;
    public EnemyStateID initialState;
    public EnemyConfig config;
    public Transform enemyTransform;
    public Transform swordTransform;
    public Transform playerSword;
    public AttackEvent OnAttack;
    [SerializeField] private Animator playerAttack;
    [SerializeField] public Animator enemyAttack;
    [SerializeField] private float playerSwordPosX;
    void Awake()
    {
        enemyTransform = GetComponent<Transform>();
        stateMachine = new EnemyStateMachine(this);
        stateMachine.RegisterState(new WanderEnemyState());
        stateMachine.RegisterState(new AttackEnemyState());
        stateMachine.ChangeState(initialState);
    }

    void Update()
    {
        Debug.Log("Current state: " + stateMachine.currentState);
        stateMachine.Update();
    }

    public void Interact(){
        Vector3 sidePosition = playerTransform.InverseTransformPoint(transform.position);
        if(sidePosition.x < 0){
                playerAttack.SetTrigger("AttackLeft");
                playerSword.localPosition = new Vector3(-playerSwordPosX,playerSword.localPosition.y,playerSword.localPosition.z);
        }
        else{
                playerAttack.SetTrigger("AttackRight");
                playerSword.localPosition = new Vector3(playerSwordPosX,playerSword.localPosition.y,playerSword.localPosition.z);
        }
        HitsLanded++;
        if(HitsLanded == 4){
            Destroy(this.gameObject);
        }
        playerAttack.SetTrigger("Wait");
    }
}
