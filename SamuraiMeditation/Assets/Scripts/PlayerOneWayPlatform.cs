using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWayPlatform : MonoBehaviour
{
    public float waitForSeconds = 1f;
    [SerializeField] private CapsuleCollider2D playerCollider;

    private CompositeCollider2D oneWayPlatformComposite;

    void Start()
    {
        GameObject platformTilemap = GameObject.FindWithTag("OneWayPlatform");
        if (platformTilemap != null)
        {
            oneWayPlatformComposite = platformTilemap.GetComponent<CompositeCollider2D>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (oneWayPlatformComposite != null)
            {
                StartCoroutine(DisableCollisionTemporarily());
            }
        }
    }

    private IEnumerator DisableCollisionTemporarily()
    {
        Physics2D.IgnoreCollision(playerCollider, oneWayPlatformComposite, true);
        yield return new WaitForSeconds(waitForSeconds);
        Physics2D.IgnoreCollision(playerCollider, oneWayPlatformComposite, false);
    }
}
