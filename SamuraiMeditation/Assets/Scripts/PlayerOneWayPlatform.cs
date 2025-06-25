using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWayPlatform : MonoBehaviour
{
    public float waitForSeconds = 1f;
    [SerializeField] private CapsuleCollider2D playerCollider;

    private CompositeCollider2D oneWayPlatformComposite; // NEU

    void Start()
    {
        // Finde die Tilemap mit dem CompositeCollider2D
        GameObject platformTilemap = GameObject.FindWithTag("OneWayPlatform"); // oder by Name: "DeinTilemapObjekt"
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
