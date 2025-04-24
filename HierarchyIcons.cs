using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class HierarchyIcons
{
    static HierarchyIcons()
    {
        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
    }

    private static void OnHierarchyGUI(int instanceID, Rect selectionRect)
    {
        GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (obj != null)
        {
            if (obj.CompareTag("HighLighted"))
            {
                EditorGUI.DrawRect(selectionRect, Color.black);  // Background color
                EditorGUI.LabelField(selectionRect, obj.name, new GUIStyle() { normal = new GUIStyleState() { textColor = Color.magenta } });
            }
        }
    }
}
