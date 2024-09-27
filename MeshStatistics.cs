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

    // Option to include skinned meshes
    private bool includeSkinnedMeshes = false;

    // Create a menu item in the Unity editor for the Mesh Statistics
    [MenuItem("Tools/Mesh Statistics")]
    private static void ShowWindow()
    {
        var window = GetWindow<MeshStatistics>();
        window.titleContent = new GUIContent("Mesh Statistics");
        window.Show();
    }

    // Analyze all meshes in the scene
    private void OnGUI()
    {
        GUILayout.Label("Mesh Statistics", EditorStyles.boldLabel);

        includeSkinnedMeshes = EditorGUILayout.Toggle("Include Skinned Meshes", includeSkinnedMeshes);

        if (GUILayout.Button("Analyze Meshes"))
        {
            AnalyzeMeshes();
        }

        if (meshInfoList.Count > 0)
        {
            GUILayout.Space(10);
            GUILayout.Label("Meshes by poly count (highest to lowest):", EditorStyles.boldLabel);

            // Start the scroll view
            Vector2 scrollPosition = Vector2.zero;
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, false, true, GUILayout.Height(300)); // Set height as needed

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

            // End the scroll view
            EditorGUILayout.EndScrollView();
        }
    }


    // Function to analyze meshes in the scene
    private void AnalyzeMeshes()
    {
        meshInfoList.Clear();

        // Find all mesh filters in the scene
        MeshFilter[] meshFilters = FindObjectsOfType<MeshFilter>();

        // Analyze MeshFilters
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

        // If including skinned meshes
        if (includeSkinnedMeshes)
        {
            // Find all skinned mesh renderers in the scene
            SkinnedMeshRenderer[] skinnedMeshRenderers = FindObjectsOfType<SkinnedMeshRenderer>();

            // Analyze SkinnedMeshRenderers
            foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers)
            {
                if (skinnedMeshRenderer.sharedMesh != null)
                {
                    int polyCount = skinnedMeshRenderer.sharedMesh.triangles.Length / 3;
                    string meshName = skinnedMeshRenderer.sharedMesh.name;
                    GameObject obj = skinnedMeshRenderer.gameObject;

                    meshInfoList.Add(new MeshInfo(meshName, polyCount, obj));
                }
            }
        }

        // Sort the list by poly count in descending order
        meshInfoList.Sort((a, b) => b.polyCount.CompareTo(a.polyCount));
    }
}
