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
            // Save the original GUI color
            var originalColor = GUI.color;

            // Define the background color based on the tag with cool and readable colors
            Color backgroundColor = Color.clear; // Default to no background
            switch (obj.tag)
            {
                case "HighLighted":
                    backgroundColor = new Color(0.7f, 0f, 0.7f, 0.4f); // Light Magenta with 20% opacity
                    break;

                case "Systems":
                    backgroundColor = new Color(0.2f, 0.7f, 0.2f, 0.4f); // Light Green with 20% opacity
                    break;

                case "Content":
                    backgroundColor = new Color(0.5f, 0.7f, 1f, 0.4f); // Light Cornflower Blue with 20% opacity
                    break;

                case "UI":
                    backgroundColor = new Color(0.4f, 1f, 1f, 0.4f); // Light Cyan with 20% opacity
                    break;

                case "Environment":
                    backgroundColor = new Color(1f, 0.5f, 0.5f, 0.4f); // Light Red with 20% opacity
                    break;

                case "Actors":
                    backgroundColor = new Color(0.4f, 1f, 1f, 0.4f); // Light Cyan with 20% opacity
                    break;

                case "Audio":
                    backgroundColor = new Color(1f, 1f, 1f, 0.4f); // Light White with 20% opacity
                    break;

                case "Lighting":
                    backgroundColor = new Color(1f, 1f, 0.5f, 0.4f); // Light Yellow with 20% opacity
                    break;

                default:
                    // No background color for default items
                    backgroundColor = Color.clear;
                    break;
            }

            // Draw the background color only if it's not transparent
            if (backgroundColor.a > 0)
            {
                DrawBackground(selectionRect, backgroundColor);
            }

            // Restore the original GUI color
            GUI.color = originalColor;
        }
    }

    private static void DrawBackground(Rect rect, Color color)
    {
        // Save the original GUI color
        var originalColor = GUI.color;

        // Set the background color
        GUI.color = color;

        // Draw the background rectangle
        Rect backgroundRect = new Rect(rect.x, rect.y, rect.width, rect.height + 2); // Extend slightly to cover entire row
        GUI.DrawTexture(backgroundRect, Texture2D.whiteTexture);

        // Restore the original GUI color
        GUI.color = originalColor;
    }
}
