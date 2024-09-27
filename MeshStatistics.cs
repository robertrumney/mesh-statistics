using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class MeshStatistics : EditorWindow
{
    // Holds information about each mesh
    private class MeshInfo
    {
        public string name;
        public int polyCount;
        public GameObject gameObject;

        public MeshInfo(string name, int polyCount, GameObject gameObject)
        {
            this.name = name;
            this.polyCount = polyCount;
            this.gameObject = gameObject;
        }
    }

    // List to store the mesh info
    private List<MeshInfo> meshInfoList = new List<MeshInfo>();

    // Create a menu item in the Unity editor for the Mesh Analyzer
    [MenuItem("Tools/Mesh Analyzer")]
    private static void ShowWindow()
    {
        var window = GetWindow<MeshStatistics>();
        window.titleContent = new GUIContent("Mesh Analyzer");
        window.Show();
    }

    // Analyze all meshes in the scene
    private void OnGUI()
    {
        if (GUILayout.Button("Analyze Meshes"))
        {
            AnalyzeMeshes();
        }

        if (meshInfoList.Count > 0)
        {
            GUILayout.Label("Meshes by poly count (highest to lowest):", EditorStyles.boldLabel);

            // Display the list of meshes
            foreach (MeshInfo info in meshInfoList)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(info.name + " - " + info.polyCount + " polys");
                if (GUILayout.Button("Select"))
                {
                    Selection.activeGameObject = info.gameObject;
                }
                GUILayout.EndHorizontal();
            }
        }
    }

    // Function to analyze meshes in the scene
    private void AnalyzeMeshes()
    {
        meshInfoList.Clear();

        // Find all mesh filters in the scene
        MeshFilter[] meshFilters = FindObjectsOfType<MeshFilter>();

        // Loop through each mesh filter
        foreach (MeshFilter meshFilter in meshFilters)
        {
            if (meshFilter.sharedMesh != null)
            {
                int polyCount = meshFilter.sharedMesh.triangles.Length / 3;
                string meshName = meshFilter.sharedMesh.name;
                GameObject obj = meshFilter.gameObject;

                meshInfoList.Add(new MeshInfo(meshName, polyCount, obj));
            }
        }

        // Sort the list by poly count in descending order
        meshInfoList.Sort((a, b) => b.polyCount.CompareTo(a.polyCount));
    }
}
