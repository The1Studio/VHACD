namespace VHACD.Unity
{
    using System;
    using UnityEditor;
    using UnityEngine;

    public class ComplexColliderEditorWindow : EditorWindow
    {
        [MenuItem("TheOne/Complex Collider Editor")] public static void Open()
        {
            var window = GetWindow<ComplexColliderEditorWindow>();
            window.minSize = new Vector2(400, 120);
            window.maxSize = new Vector2(400, 120);
            window.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Calculate Colliders From Current Mesh Filter"))
            {
                this.QueryAllComplexCollider(inspector => inspector.CalculateColliderFromCurrentMeshFilter());
            }
            if (GUILayout.Button("Calculate Colliders From Child Mesh Filter"))
            {
                this.QueryAllComplexCollider(inspector => inspector.CalculateColliderFromChildMeshFilter());
            }
            if (GUILayout.Button("Clear Collider and Data"))
            {
                this.QueryAllComplexCollider(inspector => inspector.ClearColliderData());
            }
        }

        private void QueryAllComplexCollider(Action<ComplexColliderEditor> callback)
        {
            var allObj = FindObjectsByType<ComplexCollider>(FindObjectsSortMode.None);
            foreach (var obj in allObj)
            {
                var inspector = (ComplexColliderEditor)Editor.CreateEditor(obj);
                if (inspector != null)
                {
                    inspector.OnInspectorGUI();
                    callback?.Invoke(inspector);
                }
            }
        }
    }
}
