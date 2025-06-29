using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Way Points")]
   
    public float Speed;
    
    

    public EnemyStateMachine StateMachine {  get; private set; }
    public EnemyIdleState StateIdle { get; private set; }
    public EnemyWalkState WalkState { get; private set; }
    public Enemyhurt hurtState { get; private set; }

    [Header("Components")]
    public Animator animator;
    public Rigidbody2D rb;
    [Header("RayCast")]
    //RayCast
    public GameObject Ground;
    public GameObject wall;
    public LayerMask LayerMask;
    public LayerMask Slope_Wall;

    [Header("Flipinfo")]
    public int Flipdir = 1;
    public bool Facingright;

    public float StateTimer;

    [Header("Health Info")]
    public int MaxHealth = 100;
    public int CurrentHealth;

    private void Awake()
    {
        StateMachine = new EnemyStateMachine();
        StateIdle = new EnemyIdleState(this, StateMachine, "Idle");
        WalkState = new EnemyWalkState(this, StateMachine, "Walk");
        hurtState = new Enemyhurt (this, StateMachine, "Hurt");
        StateMachine.Initialized(StateIdle);
        
    }

    public void Start()
    {
        StateTimer -= Time.deltaTime;
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        StateMachine.currentstate.Update();
       
    }

    public void Flip()
    {
        Flipdir = -1;
        Facingright = !Facingright;
        transform.Rotate(0, 180, 0);

    }


    public bool GroundCheck => Physics2D.Raycast(Ground.transform.position, Vector2.down, 0.3f, LayerMask);
    public bool WallCheck => Physics2D.Raycast(wall.transform.position,Vector2.left, 0.5f, Slope_Wall);


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Ground.transform.position, Ground.transform.position + Vector3.down * 0.3f);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(wall.transform.position,wall.transform.position + Vector3.left * 0.5f);
    }

    public void TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;
        StateMachine.Changestate(hurtState);
        if (CurrentHealth <= 0)
        {
            Debug.Log("Dead");
        }
    }

   

}
