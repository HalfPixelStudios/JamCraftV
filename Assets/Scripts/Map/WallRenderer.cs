using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRenderer : MonoBehaviour {

    public GameObject wall_container;

    public void RenderWalls(List<Mesh> meshes) {
        foreach (Transform child in wall_container.transform) { //wipe all previous meshes
            DestroyImmediate(child.gameObject);
        }

        foreach (Mesh mesh in meshes) {
            GameObject meshObject = Instantiate(Resources.Load("MeshObject")) as GameObject;
            meshObject.GetComponent<MeshFilter>().sharedMesh = mesh;
            //meshObject.GetComponent<MeshRenderer>().sharedMaterial.mainTexture = ;r
            meshObject.transform.parent = wall_container.transform;

        }


    }
}
