using Geurts.InspectorTools.Styling;
using UnityEditor;
using UnityEngine;

namespace Geurts.InspectorTools
{
    /// <summary>
    /// This class is used to create formatted areas for content.
    /// </summary>
    public static class GeurtsEditorAreaCreator
    {
        #region Private Fields

        private static readonly int _defaultSpacing;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Begins an Area.
        /// </summary>
        /// <param name="areaColor">The background colour of the Area.</param>
        /// <param name="doesIndentContents">If True the contents of the Area will be Indented.</param>
        /// <param name="padding">
        /// The space between the edges of the area and the content in the middle of the area.
        /// </param>
        /// <param name="headerFont"></param>
        /// <param name="header"></param>
        /// <param name="headerSpacing">The spacing after both Heading and Note has been displayed.</param>
        /// <param name="noteFont"></param>
        /// <param name="note"></param>
        public static void BeginArea(Color areaColor, bool doesIndentContents, int padding, GUIStyle headerFont, string header, int headerSpacing, GUIStyle noteFont, string note)
        {
            EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(areaColor, padding));
            GUILayout.Label(header, headerFont);
            GUILayout.Label(note, noteFont);
            GUILayout.Space(headerSpacing);

            if (doesIndentContents)
            {
                EditorGUI.indentLevel++;
            }
        }

        /// <summary>
        /// Begins an Area.
        /// </summary>
        /// <param name="areaColor">The background colour of the Area.</param>
        /// <param name="doesIndentContents">If True the contents of the Area will be Indented.</param>
        /// <param name="padding">
        /// The space between the edges of the area and the content in the middle of the area.
        /// </param>
        /// <param name="headerFont"></param>
        /// <param name="header"></param>
        /// <param name="headerSpacing"></param>
        public static void BeginArea(Color areaColor, bool doesIndentContents, int padding, GUIStyle headerFont, string header, int headerSpacing)
        {
            EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(areaColor, padding));
            GUILayout.Label(header, headerFont);
            GUILayout.Space(headerSpacing);

            if (doesIndentContents)
            {
                EditorGUI.indentLevel++;
            }
        }

        /// <summary>
        /// Begins an Area with no Heading or Note.
        /// </summary>
        /// <param name="areaColor">The background colour of the Area.</param>
        /// <param name="doesIndentContents">If True the contents of the Area will be Indented.</param>
        /// <param name="padding">
        /// The space between the edges of the area and the content in the middle of the area.
        /// </param>
        public static void BeginArea(Color areaColor, bool doesIndentContents, int padding)
        {
            EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(areaColor, padding));

            if (doesIndentContents)
            {
                EditorGUI.indentLevel++;
            }
        }

        /// <summary>
        /// Begins an Area with No Heading or Note. Padding is Set to Default.
        /// </summary>
        /// <param name="areaColor">The background colour of the Area.</param>
        /// <param name="doesIndentContents">If True the contents of the Area will be Indented.</param>
        public static void BeginArea(Color areaColor, bool doesIndentContents)
        {
            EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetBasicStyle(areaColor));

            if (doesIndentContents)
            {
                EditorGUI.indentLevel++;
            }
        }

        /// <summary>
        /// Begins an Area with No Heading or Note.
        /// </summary>
        /// <param name="areaColor">The background colour of the Area.</param>
        /// <param name="padding">
        /// The space between the edges of the area and the content in the middle of the area.
        /// </param>
        public static void BeginBlankArea(Color areaColor, int padding)
        {
            EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(areaColor, padding));
        }

        /// <summary>
        /// Begins an Area that helpful for Display an Error. It consists of a Border and a HelpBox.
        /// </summary>
        /// <param name="errorType">The ErrorType determines the BorderColour and the HelpBox type.</param>
        /// <param name="messageString"></param>
        public static void BeginProblematicArea(GeurtsEditorRequirementTools.ErrorType errorType, string messageString)
        {
            if (errorType == GeurtsEditorRequirementTools.ErrorType.WARNING)
            {
                EditorGUILayout.Space(8);
                EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(Color.yellow, 2));
                EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(GeurtsEditorColours._dark3, 0));
                EditorGUILayout.HelpBox(messageString, MessageType.Warning);
            }
            else if (errorType == GeurtsEditorRequirementTools.ErrorType.ERROR)
            {
                EditorGUILayout.Space(8);
                EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(Color.red, 2));
                EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(GeurtsEditorColours._dark3, 0));
                EditorGUILayout.HelpBox(messageString, MessageType.Error);
            }
            else if (errorType == GeurtsEditorRequirementTools.ErrorType.RECOMMENDATION)
            {
                EditorGUILayout.Space(8);
                EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(Color.white, 2));
                EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(GeurtsEditorColours._dark3, 0));
                EditorGUILayout.HelpBox(messageString, MessageType.Info);
            }
        }

        /// <summary>
        /// Creates a line of a set size.
        /// </summary>
        /// <param name="size"></param>
        public static void CreateDivider(int size)
        {
            EditorGUILayout.BeginVertical(GeurtsBackgroundStyles.GetStyle(Color.black, size));
            EditorGUILayout.EndVertical();
        }

        /// <summary>
        /// Ends an Area.
        /// </summary>
        /// <param name="isProblematicArea"></param>
        /// <param name="doesUndentContents"></param>
        /// <param name="spacing">The spacing after the Area has Ended.</param>
        public static void EndArea(bool isProblematicArea, bool doesUndentContents, int spacing)
        {
            if (doesUndentContents)
                EditorGUI.indentLevel--;

            if (isProblematicArea)
                EditorGUILayout.EndVertical();

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(spacing);
        }

        /// <summary>
        /// Ends an Area.
        /// </summary>
        /// <param name="isProblematicArea"></param>
        /// <param name="doesUndentContents"></param>
        public static void EndArea(bool isProblematicArea, bool doesUndentContents)
        {
            if (doesUndentContents)
                EditorGUI.indentLevel--;

            if (isProblematicArea)
                EditorGUILayout.EndVertical();

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(_defaultSpacing);
        }

        /// <summary>
        /// Ends an Area.
        /// </summary>
        /// <param name="isProblematicArea"></param>
        /// <param name="doesUndentContent"></param>
        /// <param name="hasDivider">Creates a divider after the Area has Ended.</param>
        public static void EndArea(bool isProblematicArea, bool doesUndentContent, bool hasDivider)
        {
            EndArea(isProblematicArea, doesUndentContent);

            GeurtsEditorMiscTools.CreateDivider(1, 5, 10);
        }

        /// <summary>
        /// Ends a Problematic Area.
        /// </summary>
        public static void EndProblematicArea()
        {
            EndArea(true, false);
        }

        #endregion Public Methods
    }
}