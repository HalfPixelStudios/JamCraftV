using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class RoomLayout : MonoBehaviour {


    //assume grid size to be one unit
    public int ROOMSIZE = 32;
    string[,] grid;
    Dictionary<Vector2, Vector2> wall_chain;

    public void GenerateRoom() {
        grid = new string[ROOMSIZE, ROOMSIZE];
        wall_chain = new Dictionary<Vector2, Vector2>();
    }

    private void OnValidate() {
        
    }

    public void FindWallVerticies() {
        Vector2[] directs = new Vector2[]{Vector2.right,Vector2.down,Vector2.left,Vector2.up};
        
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
                        //add wall verticies, the order of the verticies forces a clockwise traversal
                        if (newval == "#") {
                            
                            if (d == Vector2.right) { //left wall
                                AddWallChain(new Vector2(x,y+1),new Vector2(x,y));
                            } else if (d == Vector2.down) { //upper wall
                                AddWallChain(new Vector2(x,y),new Vector2(x+1,y));
                            } else if (d == Vector2.left) { //right wall
                                AddWallChain(new Vector2(x+1,y),new Vector2(x+1,y+1));
                            } else if (d == Vector2.up) { //bottom wall
                                AddWallChain(new Vector2(x+1,y+1),new Vector2(x,y+1));
                            }
                        }
                    }
                }
            }
        }

    }

    public void FindWalls() { //finds individual wall 'chains' and returns them in clockwise order
        Vector2 curVertex = GetFirstKey();
        HashSet<Vector2> visited = new HashSet<Vector2>();

        while (wall_chain.Count > 0) {
            if (!wall_chain.ContainsKey(curVertex)) {
                Debug.LogError("Unable to locate next vertex");
            }
            visited.Add(curVertex);
            Vector2 nextVertex = wall_chain[curVertex];
            wall_chain.Remove(curVertex);

            if (visited.Contains(nextVertex)) { //formed a close loop
                //TODO: track all verticies we have visited, and bundle them up in an array or sm
            }
            

            curVertex = nextVertex;

        }




    }

    private void AddWallChain(Vector2 start, Vector2 end) {
        if (wall_chain.ContainsKey(start)) {
            Debug.LogError("Start wall vertex already exists");
        }
        //Assert.IsTrue(start != end,"Starting vertex is the same as ending vertex");

        this.wall_chain.Add(start,end);
    }

    private Vector2 GetFirstKey() {//get any key from dict as starting point
        if (wall_chain.Count == 0) {
            Debug.LogError("wall_chain is empty");
        }
        foreach (Vector2 key in wall_chain.Keys) { 
            return wall_chain[key];
        }
        return Vector2.zero;
    }

}


