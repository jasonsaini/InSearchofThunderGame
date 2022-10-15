using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class meshGenerator : MonoBehaviour
{
    Mesh mesh;
    public GameObject snowBreaker;
    Vector3[] vertices;
    int[] triangles;
    public int xSize = 20;
    public int zSize = 20;
    public float amplitude = .9f;
    public float randomness = .7f;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        createShape();
        updateShape();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r")){
            createShape();
            updateShape();
        }

        if (Input.GetKeyDown("space")) {

            updateShape();
        }
    }

    void createShape(){
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
 
        for (int i = 0, z = 0; z <= zSize; z++){
            for (int x = 0; x <= xSize; x++) {
                float y = Mathf.PerlinNoise(x * randomness, z * randomness) * amplitude + .02f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }
    }

    void updateShape() {
        mesh.Clear();

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++) {
            for (int x = 0; x < xSize; x++) {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;
                vert++;
                tris += 6;
            }
            vert++;
        }
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    //private void OnDrawGizmos() {
    //    if (vertices == null)
    //        return;
    //    vertice1 = snowBreaker.transform.position.x
    //}
}
