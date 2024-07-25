using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class EnemyController : MonoBehaviour, IDamageable{
    protected int HitsLanded = 0;
    [SerializeField] protected LevelManager lm;
    [SerializeField] protected Transform levelTransform;
    [SerializeField] private GameObject spearCollider;
    public EnemyStateMachine stateMachine;
    public Transform playerTransform;
    public EnemyStateID initialState;
    public EnemyConfig config;
    public Transform enemyTransform;
    public AnimationUpdater au;
    public GameObject scifiBall;
    protected PlayerCharacter playerCharacter;
    private Transform spearTransform;
    public bool isAttacking = false;
    protected virtual void Awake(){
        enemyTransform = GetComponent<Transform>();
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
        playerCharacter = player.GetComponent<PlayerCharacter>();
        spearTransform = spearCollider.transform;
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
            lm.numEnemiesRemaining--;
            au.EnemyDeath();
            stateMachine.GetState(stateMachine.currentState)?.Exit(this);
            Destroy(gameObject,1);
        }
    }

    public virtual void Attack(){
        float dmg;
        if(doesLand() && isAttacking){
            dmg = Random.Range(5,20);
            StartCoroutine(AttackCoroutine());
                IEnumerator AttackCoroutine(){
                yield return new WaitForSeconds(0.3f);
                playerCharacter.TakeDamage(dmg);
            }
        }
    }
    
    protected bool doesLand(){
        var check = Random.Range(0,10);
        if(check > 3){          
            return true;
        }
        return false;
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
    public void RotateSpearCollider(Direction newDir){
        switch (newDir){
            case Direction.Right:
                spearTransform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.right);
                break;
            case Direction.Left:
                spearTransform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.left);
                break;
            case Direction.Up:
                spearTransform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
                break;
            case Direction.Down:
                spearTransform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.down);
                break;
        }
    }
    public void EnableSpearCollider(){
        spearCollider.SetActive(true);
    }
    public void DisableSpearCollider(){
        spearCollider.SetActive(false);
    }

    public void IsAttacking(){
        isAttacking = true;
    }
    public void StopAttacking(){
        isAttacking = false;
    }
}
