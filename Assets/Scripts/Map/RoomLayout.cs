using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLayout : MonoBehaviour {


    //assume grid size to be one unit
    public int ROOMSIZE = 32;
    string[,] grid;

    public void GenerateRoom() {
        grid = new string[ROOMSIZE, ROOMSIZE];
    }

    private void OnValidate() {
        
    }

    static List<Vector3> FindWalls(string[,] grid) {
        Vector2[] directs = new Vector2[]{Vector2.up,Vector2.right,Vector2.down,Vector2.left};

        List<Vector3> wall_verticies = new List<Vector3>();
        for (int y = 0; y < grid.GetLength(1); y++) {
            for (int x = 0; x < grid.GetLength(0); x++) {

            }
        }

        return wall_verticies;
    }
}
