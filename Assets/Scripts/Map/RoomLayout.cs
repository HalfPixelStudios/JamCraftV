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

    public HashSet<Vector3> FindWallVerticies() {
        Vector2[] directs = new Vector2[]{Vector2.right,Vector2.down,Vector2.left,Vector2.up};

        HashSet<Vector3> wall_verticies = new HashSet<Vector3>();
        for (int y = 0; y < this.grid.GetLength(1); y++) {
            for (int x = 0; x < this.grid.GetLength(0); x++) {

                string val = this.grid[x,y];
                //find walls
                if (val == ".") { //if there is an empty space
                    foreach (Vector2 d in directs) { //check in every direction
                        int nx = x + (int)d.x;
                        int ny = y + (int)d.y;

                        if (nx < 0 || nx > this.grid.GetLength(0) || ny < 0 || ny > this.grid.GetLength(1)) { //if invalid grid location
                            continue;
                        }

                        string newval = this.grid[nx, ny];
                        //TODO: make this nicer to the eyes
                        //add wall verticies
                        if (newval == "#") {
                            
                            if (d == Vector2.right) {
                                wall_verticies.Add(new Vector3(x+1,y));
                                wall_verticies.Add(new Vector3(x+1,y+1));
                            } else if (d == Vector2.down) {
                                wall_verticies.Add(new Vector3(x+1,y+1));
                                wall_verticies.Add(new Vector3(x,y+1));
                            } else if (d == Vector2.left) {
                                wall_verticies.Add(new Vector3(x,y+1));
                                wall_verticies.Add(new Vector3(x,y));
                            } else if (d == Vector2.up) {
                                wall_verticies.Add(new Vector3(x,y));
                                wall_verticies.Add(new Vector3(x+1,y));
                            }
                        }
                    }
                }
            }
        }

        return wall_verticies;
    }

    public void FindWalls() { //finds individual wall 'chains' and returns them in clockwise order

    }

}
