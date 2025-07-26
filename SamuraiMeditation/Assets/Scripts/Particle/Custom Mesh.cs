using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMesh : MonoBehaviour
{

    private const int MAX_QUAD_AMOUNT = 15000;
   private Mesh mesh;
    private Vector3[] Vertices;
    private Vector2[] uv;
    private int[] triangles;

    private int quadIndex;

    private void Start()
    {
        mesh = new Mesh();

        Vertices = new Vector3[4 * MAX_QUAD_AMOUNT];
        uv = new Vector2[4 * MAX_QUAD_AMOUNT];
        triangles = new int[6 * MAX_QUAD_AMOUNT];

        AddQuad(new Vector3 (0,0));
        AddQuad(new Vector3(0, 5));

        mesh.vertices = Vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;
    }

    void AddQuad(Vector3 position)
    {
        if(quadIndex >= MAX_QUAD_AMOUNT)
        {
            return;
        }
        //Relocate vertices

        int vIndex = quadIndex * 4;
        int vIndex0 =vIndex;
        int vIndex1 =vIndex +1;
        int vIndex2 =vIndex +2;
        int vIndex3 =vIndex+ 3;

        Vector3 quadsize = new Vector3(1, 1);
        float rotation = 0f;
        Vertices[vIndex0] = position +Quaternion.Euler(0,0,rotation - 180) * quadsize;
        Vertices[vIndex1] = position +Quaternion.Euler(0,0,rotation -270)* quadsize;
        Vertices[vIndex2] = position +Quaternion.Euler(0,0,rotation - 0) * quadsize;
        Vertices[vIndex3] = position +Quaternion.Euler(0,0,rotation - 90) * quadsize;

        //uv
        uv[vIndex0] = new Vector2 (0,0);
        uv[vIndex1] = new Vector2 (0,1);
        uv[vIndex2] = new Vector2 (1,1);
        uv[vIndex3] = new Vector2 (1,0);


        // create traingle 

        int tIndex = quadIndex * 6;

        triangles[tIndex + 0] = vIndex0;
        triangles[tIndex + 1] = vIndex1;
        triangles[tIndex + 2] = vIndex2;

        triangles[tIndex + 3] = vIndex0;
        triangles[tIndex + 4] = vIndex2;
        triangles[tIndex + 5] = vIndex3;

        quadIndex++;

    }
}
