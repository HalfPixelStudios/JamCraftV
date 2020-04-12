using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMesh {

    /*
    public Vector3[] verticies;
    public int[] triangles;
    public Vector2[] uvs;

    public int height;

    //min height of 1
    public WallMesh(Vector3[] wall_pos,int height) {



    }
    */

    public static Mesh GenerateWallMesh(List<Vector3> wall_pos, int height) {
        int width = wall_pos.Count;

        Vector3[] verticies = new Vector3[width * (height + 1)];
        int[] triangles = new int[width * height * 6];
        Vector2[] uvs = new Vector2[verticies.Length];

        for (int v = 0, i = 0; v < width; v++) {
            Vector3 pos = wall_pos[v];
            for (int h = 0; h < height+1; h++, i++) {
                verticies[i] = new Vector3(pos.x, h, pos.y);
            }
        }

        for (int h = 0, vi = 0, ti = 0; h < height; h++, vi++) {
            for (int v = 0; v < width - 1; v++, vi++, ti+=6) {
                //triangle1
                triangles[ti] = vi;
                triangles[ti+1] = vi+width;
                triangles[ti+2] = vi+1;

                //triangle2
                triangles[ti+3] = vi+1;
                triangles[ti+4] = vi+width;
                triangles[ti+5] = vi+width+1;
            }
        }

        Mesh mesh = new Mesh();
        mesh.vertices = verticies;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();

        return mesh;
    }

 
}
