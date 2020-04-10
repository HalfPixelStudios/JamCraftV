using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMesh {

    public Vector3[] verticies;
    public int[] triangles;
    public Vector2[] uvs;

    //min height of 1
    public WallMesh(Vector3[] wall_pos,int height) {
        verticies = new Vector3[wall_pos.Length*(height+1)];
        triangles = new int[wall_pos.Length*height*6];
        uvs = new Vector2[verticies.Length];
    }

    public void GenerateWallMesh() {

    }

 
}
