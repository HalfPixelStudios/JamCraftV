using UnityEngine;
using UnityEditor;

public class MapEditor : EditorWindow {

    [MenuItem("Window/MapEditor")]
    public static void ShowWindow() {
        GetWindow<MapEditor>();
    }

    void OnGUI() {
        

        if (GUILayout.Button("Generate")) {

        }
    }
}
