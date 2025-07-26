using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterScript : MonoBehaviour
{
    public ParticleSystem Blood;
    public GameObject Splatter;
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    private void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(Blood, other,collisionEvents);

        int count = collisionEvents.Count;

        for(int i = 0; i < count; i++)
        {
            GameObject Splat = Instantiate(Splatter, collisionEvents[i].intersection, Quaternion.identity) as GameObject;
        }
    }
}
