using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayToMesh : MonoBehaviour
{
    public raycast Caster;
    public MeshFilter LightMesh;
    // Start is called before the first frame update
    void Start()
    {
        LightMesh = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Caster.LightContour.Count);
        int numRays = Caster.LightContour.Count - 1;
        LightMesh.mesh.vertices = Caster.LightContour.ToArray();
        int[] triangles = new int[numRays * 3];
        //int[] triangles = new int[3];
        //triangles[0] = 1;
        //triangles[1] = 0;
        //triangles[2] = 2;

        for (int i = 0; i < numRays * 3; i += 3)
        {
            triangles[i] = (i / 3 + 1) % numRays;
            triangles[i + 1] = numRays;
            triangles[i + 2] = (i / 3 + 2) % numRays;
        }
        LightMesh.mesh.triangles = triangles;
    }
}
