using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField]private GameObject Bullet;
    [SerializeField]private Transform BulletPosition;
    private float Timer = 2;

    private void Update()
    {
        Timer -= Time.deltaTime;

        if(Timer < 0)
        {
            Timer = 2;
            Instantiate(Bullet, BulletPosition.position,Quaternion.identity); 
        }
    }

    
}
