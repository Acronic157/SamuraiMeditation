using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField]private GameObject Bullet;
    [SerializeField]private Transform BulletPosition;
    private float Timer = 1;
    [SerializeField] private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float Distance = Vector2.Distance(transform.position,player.transform.position);

        if (Distance < 6)
        {

           Timer -= Time.deltaTime;

            if(Timer < 0)
            {
              Timer = 1;
              Instantiate(Bullet, BulletPosition.position,Quaternion.identity); 
            }
            
        }

    }

    
}
