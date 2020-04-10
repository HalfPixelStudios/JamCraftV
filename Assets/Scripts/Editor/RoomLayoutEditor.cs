using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomLayout))]
public class RoomLayoutEditor : Editor {

    public override void OnInspectorGUI() {
        RoomLayout rl = (RoomLayout)target;

        if (DrawDefaultInspector()) {
            rl.GenerateRoom();
        }


        if (GUILayout.Button("Generate")) {
            rl.GenerateRoom();
        }
    }
}
