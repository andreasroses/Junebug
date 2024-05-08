using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class EnemyController : MonoBehaviour, IDamageable{
    protected int HitsLanded = 0;
    [SerializeField] protected Transform levelTransform;
    public EnemyStateMachine stateMachine;
    public Transform playerTransform;
    public EnemyStateID initialState;
    public EnemyConfig config;
    public Transform enemyTransform;
    public AnimationUpdater au;
    public GameObject scifiBall;
    protected PlayerCharacter playerCharacter;

    protected virtual void Awake(){
        enemyTransform = GetComponent<Transform>();
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
        playerCharacter = player.GetComponent<PlayerCharacter>();
    }
    protected virtual void Start(){
        stateMachine = new EnemyStateMachine(this);
        RegisterStates();
        stateMachine.ChangeState(initialState);
    }
    protected virtual void Update(){
        stateMachine.Update();
    }

    public virtual void Damage(){
        HitsLanded++;
        if(HitsLanded == 4){
            GameDataManager.singleton.numEnemiesRemaining--;
            au.EnemyDeath();
            stateMachine.GetState(stateMachine.currentState)?.Exit(this);
            Destroy(gameObject,1);
        }
    }

    public virtual void Attack(float dmg){
        playerCharacter.TakeDamage(dmg);
    }

    protected virtual void RegisterStates(){
        stateMachine.RegisterState(new WanderEnemyState());
        stateMachine.RegisterState(new AttackEnemyState());
    }

    public void LaunchBall(Vector3 targetPos){
        Vector2 spawnPos = new Vector2(transform.position.x,transform.position.y);
        GameObject newProjectile = Instantiate(scifiBall,spawnPos,Quaternion.identity);
        newProjectile.transform.SetParent(levelTransform);
        newProjectile.transform.rotation = Quaternion.LookRotation(transform.forward,targetPos-transform.position);
        Vector3 newPos = new Vector3(newProjectile.transform.position.x,newProjectile.transform.position.y,0f);
        newProjectile.transform.position = newPos;
        newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.up * config.projSpeed;
    }
}
