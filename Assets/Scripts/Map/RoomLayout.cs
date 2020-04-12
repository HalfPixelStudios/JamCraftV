using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class RoomLayout : MonoBehaviour {


    //assume grid size to be one unit
    public int ROOMSIZE = 5;
    string[,] grid;
    Dictionary<Vector2, Vector2> wall_chain;

    public void GenerateRoom() {
        grid = new string[,] {
            {"#","#","#","#","#"},
            {"#",".",".",".","#"},
            {"#",".",".",".","#"},
            {"#",".",".",".","#"},
            {"#","#","#","#","#"}

        };
        wall_chain = new Dictionary<Vector2, Vector2>();

        WallRenderer wr = GetComponent<WallRenderer>();
        wr.RenderWalls(GenerateWalls());
    }

    private void OnValidate() {

    }

    public List<Mesh> GenerateWalls() { //finds individual wall 'chains' then generates all of the meshes
        List<Mesh> meshes = new List<Mesh>();

        FindWallVerticies();

        while (wall_chain.Count > 0) {
            List<Vector3> verticies = CollectWallChain();
            meshes.Add(WallMesh.GenerateWallMesh(verticies, 2));
        }

        return meshes;
    }

    private void FindWallVerticies() {
        Vector2[] directs = new Vector2[]{Vector2.right,Vector2.up,Vector2.left,Vector2.down};
        
        for (int y = 0; y < this.grid.GetLength(1); y++) {
            for (int x = 0; x < this.grid.GetLength(0); x++) {

                string val = this.grid[y,x];
                //Debug.Log(val);
                //find walls
                if (val == ".") { //if there is an empty space
                    foreach (Vector2 d in directs) { //check in every direction
                        int nx = x + (int)d.x;
                        int ny = y + (int)d.y;

                        if (nx < 0 || nx > this.grid.GetLength(0) || ny < 0 || ny > this.grid.GetLength(1)) { //if invalid grid location
                            continue;
                        }

                        string newval = this.grid[ny, nx];
                        //TODO: make this nicer to the eyes
                        //add wall verticies, the order of the verticies forces a clockwise traversal
                        if (newval == "#") {

                            if (d == Vector2.right) { //right wall
                                AddWallChain(new Vector2(x+1,y+1), new Vector2(x+1,y));
                            } else if (d == Vector2.down) { //bottom wall
                                AddWallChain(new Vector2(x+1,y), new Vector2(x,y));
                            } else if (d == Vector2.left) { //left wall
                                AddWallChain(new Vector2(x,y),new Vector2(x,y+1));
                            } else if (d == Vector2.up) { //upper wall
                                AddWallChain(new Vector2(x,y+1), new Vector2(x+1,y+1));
                            } 
                        }
                    }
                }
            }
        }

    }



    private List<Vector3> CollectWallChain() {

        Vector3 curVertex = GetFirstKey();
        List<Vector3> visited = new List<Vector3>();
        while(true) {

            if (visited.Contains(curVertex)) {

                return visited;
            }

            if (!wall_chain.ContainsKey(curVertex)) {
                Debug.LogError("Incomplete wall chain");
                return null;
            }

            visited.Add(curVertex);
            Vector3 nextVertex = wall_chain[curVertex];
            wall_chain.Remove(curVertex);
            curVertex = nextVertex;
        }
    }

    private void AddWallChain(Vector2 start, Vector2 end) {
        if (wall_chain.ContainsKey(start)) {
            Debug.LogError($"Start wall vertex already exists: ({start.x},{start.y}) to ({end.x},{end.y})");
            return;
        }
        wall_chain.Add(start,end);
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

    private void OnDrawGizmos() {
        if (grid == null) { return; }
        for (int y = 0; y < grid.GetLength(1)+1; y++) {
            for (int x = 0; x < grid.GetLength(0)+1; x++) {
                Gizmos.color = new Color((float)x/(grid.GetLength(0)+1), (float)y/(grid.GetLength(1)+1), 0, 1);
                Gizmos.DrawSphere(new Vector3(x,0,y),0.1f);
            }
        }

        Gizmos.color = Color.white;
        foreach (Vector2 key in wall_chain.Keys) {
            Vector3 start = new Vector3(key.x, 0, key.y);
            Vector3 end = new Vector3(wall_chain[key].x, 0, wall_chain[key].y);
            DrawArrow.ForGizmo(start,end-start);

            
        }
    }

}


