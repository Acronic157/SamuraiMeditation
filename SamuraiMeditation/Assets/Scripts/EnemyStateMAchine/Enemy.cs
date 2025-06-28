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

    [Header("Components")]
    public Animator animator;
    public Rigidbody2D rb;
    [Header("RayCast")]
    //RayCast
    public GameObject Ground;
    public GameObject wall;
    public LayerMask LayerMask;

    [Header("Flipinfo")]
    public int Flipdir = 1;
    public bool Facingright;

    public float StateTimer;


    private void Awake()
    {
        StateMachine = new EnemyStateMachine();
        StateIdle = new EnemyIdleState(this, StateMachine, "Idle");
        WalkState = new EnemyWalkState(this, StateMachine, "Walk");
        StateMachine.Initialized(StateIdle);
        
    }

    public void Start()
    {
        StateTimer -= Time.deltaTime;
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
    public bool WallCheck => Physics2D.Raycast(wall.transform.position,Vector2.left, 1f, LayerMask);


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Ground.transform.position, Ground.transform.position + Vector3.down * 0.3f);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Ground.transform.position,Ground.transform.position + Vector3.left * 1f);
    }

}
