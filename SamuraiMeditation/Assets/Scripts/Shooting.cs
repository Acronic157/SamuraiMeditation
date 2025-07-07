using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject  player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Force;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
      
        Vector2 Direction = player.transform.position - transform.position;
        rb.velocity =new Vector2(Direction.x,Direction.y).normalized * Force;
        Destroy(gameObject,5);
    }

   
}
