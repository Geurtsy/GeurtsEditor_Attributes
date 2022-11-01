using Geurts.InspectorTools.Styling;
using UnityEditor;
using UnityEngine;

namespace Geurts.InspectorTools
{
    public static class GeurtsEditorMiscTools
    {
        #region Private Fields

        private static readonly Color _defaultDividerColour = Color.white;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Creates a Border with custom Padding (size) and Colour.
        /// </summary>
        /// <param name="padding"></param>
        /// <param name="colour"></param>
        public static void BeginBorder(int padding, Color colour)
        {
            GeurtsEditorAreaCreator.BeginArea(colour, false, padding);
        }

        /// <summary>
        /// Creates a Border with custom Padding (size) and the DefaultColour.
        /// </summary>
        /// <param name="padding"></param>
        public static void BeginBorder(int padding)
        {
            GeurtsEditorAreaCreator.BeginArea(Color.black, false, padding);
        }

        /// <summary>
        /// Creates a Default Border.
        /// </summary>
        public static void BeginBorder()
        {
            GeurtsEditorAreaCreator.BeginArea(Color.black, false, 2);
        }

        /// <summary>
        /// Creates a Default Divider.
        /// </summary>
        public static void CreateDivider()
        {
            EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(_defaultDividerColour, 1));
            EditorGUILayout.EndVertical();
        }

        /// <summary>
        /// Creates a Divider with a specified Colour and a size of 1.
        /// </summary>
        /// <param name="dividerColour"></param>
        public static void CreateDivider(Color dividerColour)
        {
            EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(dividerColour, 1));
            EditorGUILayout.EndVertical();
        }

        /// <summary>
        /// Creates a Divider with the DefaultColour and the specified Size.
        /// </summary>
        /// <param name="size"></param>
        public static void CreateDivider(int size)
        {
            EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(_defaultDividerColour, size));
            EditorGUILayout.EndVertical();
        }

        /// <summary>
        /// Creates a Divider with the DefaultColour, specified Size and custom Spacing.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="spacingTop">The spacing before the divider.</param>
        /// <param name="spacingBottom">The spacing after the divider.</param>
        public static void CreateDivider(int size, int spacingTop, int spacingBottom)
        {
            EditorGUILayout.Space(spacingTop);
            EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(_defaultDividerColour, size));
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(spacingBottom);
        }

        /// <summary>
        /// Creates a Divider with Specified Colour, Size and Spacing.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="spacingTop"></param>
        /// <param name="spacingBottom"></param>
        /// <param name="dividerColour"></param>
        public static void CreateDivider(int size, int spacingTop, int spacingBottom, Color dividerColour)
        {
            EditorGUILayout.Space(spacingTop);
            EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(dividerColour, size));
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(spacingBottom);
        }

        /// <summary>
        /// Ends a Border.
        /// </summary>
        public static void EndBorder()
        {
            GeurtsEditorAreaCreator.EndArea(false, false);
        }

        #endregion Public Methods
    }
}