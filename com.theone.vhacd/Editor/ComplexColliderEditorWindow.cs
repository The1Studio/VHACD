namespace VHACD.Unity
{
    using UnityEditor;
    using UnityEngine;

    public class ComplexColliderEditorWindow : EditorWindow
    {
        [MenuItem("TheOne/Complex Collider Editor")]
        public static void Open()
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
                var allObj = FindObjectsByType<ComplexCollider>(FindObjectsSortMode.None);
                foreach (var obj in allObj)
                {
                    var inspector = (ComplexColliderEditor)Editor.CreateEditor(obj);
                    if (inspector != null)
                    {
                        inspector.OnInspectorGUI();
                        inspector.CalculateColliderFromCurrentMeshFilter();
                    }
                }
            }
            if (GUILayout.Button("Calculate Colliders From Child Mesh Filter"))
            {
                var allObj = FindObjectsByType<ComplexCollider>(FindObjectsSortMode.None);
                foreach (var obj in allObj)
                {
                    var inspector = (ComplexColliderEditor)Editor.CreateEditor(obj);
                    if (inspector != null)
                    {
                        inspector.OnInspectorGUI();
                        inspector.CalculateColliderFromChildMeshFilter();
                    }
                }
            }
        }
    }
}
