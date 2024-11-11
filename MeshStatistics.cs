using UnityEditor;
using UnityEngine;

using System.Collections.Generic;

public class MeshStatistics : EditorWindow
{
    private class MeshInfo
    {
        public string name;
        public int polyCount;
        public Mesh mesh;
        public GameObject gameObject;

        public MeshInfo(string name, int polyCount, Mesh mesh, GameObject gameObject)
        {
            this.name = name;
            this.polyCount = polyCount;
            this.mesh = mesh;
            this.gameObject = gameObject;
        }
    }

    private readonly List<MeshInfo> meshInfoList = new List<MeshInfo>();

    private bool includeSkinnedMeshes = false;
    private Vector2 scrollPosition;

    private enum AnalysisScope
    {
        Scene,
        Project
    }

    private AnalysisScope scope = AnalysisScope.Scene;

    [MenuItem("Tools/Mesh Statistics")]
    private static void ShowWindow()
    {
        var window = GetWindow<MeshStatistics>("Mesh Statistics");
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Mesh Statistics", EditorStyles.boldLabel);

        includeSkinnedMeshes = EditorGUILayout.Toggle("Include Skinned Meshes", includeSkinnedMeshes);
        scope = (AnalysisScope)EditorGUILayout.EnumPopup("Analysis Scope", scope);

        if (GUILayout.Button("Analyze Meshes"))
        {
            AnalyzeMeshes();
        }

        if (meshInfoList.Count > 0)
        {
            GUILayout.Space(10);
            GUILayout.Label("Meshes by poly count (highest to lowest):", EditorStyles.boldLabel);
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, false, true, GUILayout.Height(300));

            foreach (MeshInfo info in meshInfoList)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(info.name + " - " + info.polyCount + " polys");
                if (scope == AnalysisScope.Scene)
                {
                    if (GUILayout.Button("Select"))
                    {
                        Selection.activeGameObject = info.gameObject;
                    }
                }
                else if (scope == AnalysisScope.Project)
                {
                    if (GUILayout.Button("Ping in Project"))
                    {
                        EditorGUIUtility.PingObject(info.mesh);
                    }
                }

                GUILayout.EndHorizontal();
            }

            EditorGUILayout.EndScrollView();
        }
    }

    private void AnalyzeMeshes()
    {
        meshInfoList.Clear();
        IEnumerable<MeshFilter> meshFilters;
        IEnumerable<SkinnedMeshRenderer> skinnedMeshRenderers;

        if (scope == AnalysisScope.Project)
        {
            meshFilters = Resources.FindObjectsOfTypeAll<MeshFilter>();
            skinnedMeshRenderers = Resources.FindObjectsOfTypeAll<SkinnedMeshRenderer>();
        }
        else
        {
            meshFilters = FindObjectsOfType<MeshFilter>();
            skinnedMeshRenderers = FindObjectsOfType<SkinnedMeshRenderer>();
        }

        AddMeshesFromFilters(meshFilters);
        if (includeSkinnedMeshes)
        {
            AddMeshesFromSkinnedRenderers(skinnedMeshRenderers);
        }

        meshInfoList.Sort((a, b) => b.polyCount.CompareTo(a.polyCount));
    }

    private void AddMeshesFromFilters(IEnumerable<MeshFilter> meshFilters)
    {
        foreach (MeshFilter meshFilter in meshFilters)
        {
            if (meshFilter.sharedMesh != null)
            {
                int polyCount = meshFilter.sharedMesh.triangles.Length / 3;
                meshInfoList.Add(new MeshInfo(meshFilter.sharedMesh.name, polyCount, meshFilter.sharedMesh, meshFilter.gameObject));
            }
        }
    }

    private void AddMeshesFromSkinnedRenderers(IEnumerable<SkinnedMeshRenderer> skinnedMeshRenderers)
    {
        foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers)
        {
            if (skinnedMeshRenderer.sharedMesh != null)
            {
                int polyCount = skinnedMeshRenderer.sharedMesh.triangles.Length / 3;
                meshInfoList.Add(new MeshInfo(skinnedMeshRenderer.sharedMesh.name, polyCount, skinnedMeshRenderer.sharedMesh, skinnedMeshRenderer.gameObject));
            }
        }
    }
}
