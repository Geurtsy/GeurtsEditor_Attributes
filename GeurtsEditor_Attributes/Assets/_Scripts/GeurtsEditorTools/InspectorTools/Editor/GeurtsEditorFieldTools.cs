using Geurts.InspectorTools.Styling;
using UnityEditor;
using UnityEngine;

namespace Geurts.InspectorTools
{
    /// <summary>
    /// This class is used for Creating common Fields that are useful in the Inspector.
    /// </summary>
    public static class GeurtsEditorFieldTools
    {
        #region Public Enums

        public enum HeadingType { H1, H2, H3, H4 };

        #endregion Public Enums

        #region Public Methods

        /// <summary>
        /// Creates a Heading using GeurtsHeaderFonts.
        /// </summary>
        /// <param name="heading"></param>
        /// <param name="headingType"></param>
        public static void CreateHeading(string heading, HeadingType headingType)
        {
            switch (headingType)
            {
                case HeadingType.H1:
                    GUILayout.Label(heading, GeurtsEditorFonts.HeaderFonts.FontHeader1);
                    break;

                case HeadingType.H2:
                    GUILayout.Label(heading, GeurtsEditorFonts.HeaderFonts.FontHeader2);
                    break;

                case HeadingType.H3:
                    GUILayout.Label(heading, GeurtsEditorFonts.HeaderFonts.FontHeader3);
                    break;

                case HeadingType.H4:
                    GUILayout.Label(heading, GeurtsEditorFonts.HeaderFonts.FontHeader4);
                    break;
            }
        }

        /// <summary>
        /// Creates a LabelField that utilises GeurtsEditorTools for a Heading.
        /// </summary>
        /// <param name="heading"></param>
        /// <param name="headingType"></param>
        /// <param name="spacing">The spacing after the heading.</param>
        public static void CreateHeading(string heading, HeadingType headingType, int spacing)
        {
            CreateHeading(heading, headingType);

            EditorGUILayout.Space(spacing);
        }

        /// <summary>
        /// Creates a LabelField that utilises GeurtsEditorTools for a Heading.
        /// </summary>
        /// <param name="heading"></param>
        /// <param name="headingType"></param>
        /// <param name="spacing">The spacing after the heading.</param>
        /// <param name="colour">The Colour of the Heading.</param>
        public static void CreateHeading(string heading, HeadingType headingType, int spacing, Color colour)
        {
            GUIStyle font = GeurtsEditorFonts.HeaderFonts.FontHeader1;

            switch (headingType)
            {
                case HeadingType.H1:
                    font = GeurtsEditorFonts.HeaderFonts.FontHeader1;
                    break;

                case HeadingType.H2:
                    font = GeurtsEditorFonts.HeaderFonts.FontHeader2;
                    break;

                case HeadingType.H3:
                    font = GeurtsEditorFonts.HeaderFonts.FontHeader3;
                    break;

                case HeadingType.H4:
                    font = GeurtsEditorFonts.HeaderFonts.FontHeader4;
                    break;
            }

            font = GeurtsEditorFonts.ChangeFontColour(font, colour);
            GUILayout.Label(heading, font);

            EditorGUILayout.Space(spacing);
        }

        /// <summary>
        /// Creates a ProblematicArea that notifies the user of an InteralError.
        /// </summary>
        /// <param name="message"></param>
        public static void CreateInternalErrorMessage(string message)
        {
            GeurtsEditorAreaCreator.BeginProblematicArea(GeurtsEditorRequirementTools.ErrorType.ERROR, "Internal Error: " + message);
            GeurtsEditorAreaCreator.EndArea(true, false);
        }

        /// <summary>
        /// Creates a LabelField that utilises GeurtsEditorFonts to create a Note.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isMainNote"></param>
        public static void CreateNote(string message, bool isMainNote)
        {
            if (isMainNote)
                GUILayout.Label(message, GeurtsEditorFonts.NoteFonts.MainFontNote);
            else
                GUILayout.Label(message, GeurtsEditorFonts.NoteFonts.FontNote);
        }

        /// <summary>
        /// Creates a quick PropertyField and applies the changes to that field.
        /// </summary>
        /// <param name="targetSerializedObject"></param>
        /// <param name="propertyName"></param>
        public static SerializedProperty CreatePropertyField(SerializedObject targetSerializedObject, string propertyName)
        {
            SerializedProperty serializedProperty = targetSerializedObject.FindProperty(propertyName);
            EditorGUILayout.PropertyField(serializedProperty, true);
            targetSerializedObject.ApplyModifiedProperties();

            return serializedProperty;
        }

        /// <summary>
        /// Creates a PropertyField with a custom FieldName and ToolTip. It also applies any changes
        /// to the property.
        /// </summary>
        /// <param name="targetSerializedObject"></param>
        /// <param name="propertyName"></param>
        /// <param name="fieldName"></param>
        /// <param name="toolTip"></param>
        public static void CreatePropertyField(SerializedObject targetSerializedObject, string propertyName, string fieldName, string toolTip)
        {
            SerializedProperty serializedProperty = targetSerializedObject.FindProperty(propertyName);
            EditorGUILayout.PropertyField(serializedProperty, new GUIContent(fieldName, toolTip), true);
            targetSerializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Creates a PropertyField with a custom FieldName, ToolTip and LabelColour. It also
        /// applies any changes to the property.
        /// </summary>
        /// <param name="targetSerializedObject"></param>
        /// <param name="propertyName"></param>
        /// <param name="fieldName"></param>
        /// <param name="toolTip"></param>
        /// <param name="labelColour"></param>
        public static void CreatePropertyField(SerializedObject targetSerializedObject, string propertyName, string fieldName, string toolTip, Color labelColour)
        {
            SerializedProperty serializedProperty = targetSerializedObject.FindProperty(propertyName);
            GUIStyle previousGlobalSkin = GUI.skin.label;
            GUIStyle colouredGlobalSkin = GUI.skin.label;

            colouredGlobalSkin.normal.textColor = labelColour;
            GUI.skin.label = colouredGlobalSkin;

            EditorGUILayout.PropertyField(serializedProperty, new GUIContent(fieldName, toolTip), true);
            serializedProperty.serializedObject.ApplyModifiedProperties();

            // Restores global skin to avoid confusion.
            GUI.skin.label = previousGlobalSkin;
        }

        /// <summary>
        /// Creates a PropertyField with a custom FieldName, ToolTip and GUIStyle. It also applies
        /// any changes to the property.
        /// </summary>
        /// <param name="targetSerializedObject"></param>
        /// <param name="propertyName"></param>
        /// <param name="fieldName"></param>
        /// <param name="toolTip"></param>
        /// <param name="propertyLabelStyle"></param>
        public static void CreatePropertyField(SerializedObject targetSerializedObject, string propertyName, string fieldName, string toolTip, GUIStyle propertyLabelStyle)
        {
            SerializedProperty serializedProperty = targetSerializedObject.FindProperty(propertyName);
            GUIStyle previousGlobalSkin = GUI.skin.label;

            GUI.skin.label = propertyLabelStyle;

            EditorGUILayout.PropertyField(serializedProperty, new GUIContent(fieldName, toolTip), true);
            serializedProperty.serializedObject.ApplyModifiedProperties();

            // Restores global skin to avoid confusion.
            GUI.skin.label = previousGlobalSkin;
        }

        /// <summary>
        /// Creates a PropertyField. It also applies any changes to the property.
        /// </summary>
        /// <param name="targetProperty"></param>
        public static void CreatePropertyField(SerializedProperty targetProperty)
        {
            SerializedProperty serializedProperty = targetProperty;
            EditorGUILayout.PropertyField(serializedProperty, true);
            serializedProperty.serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Creates a PropertyField with a custom FieldName and ToolTip. It also applies any changes
        /// to the property.
        /// </summary>
        /// <param name="targetProperty"></param>
        /// <param name="fieldName"></param>
        /// <param name="toolTip"></param>
        public static void CreatePropertyField(SerializedProperty targetProperty, string fieldName, string toolTip)
        {
            SerializedProperty serializedProperty = targetProperty;
            EditorGUILayout.PropertyField(serializedProperty, new GUIContent(fieldName, toolTip), true);
            serializedProperty.serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Creates a PropertyField with a custom FieldName, ToolTip and GUIStyle. It also applies
        /// any changes to the property.
        /// </summary>
        /// <param name="targetProperty"></param>
        /// <param name="fieldName"></param>
        /// <param name="toolTip"></param>
        /// <param name="propertyLabelStyle"></param>
        public static void CreatePropertyField(SerializedProperty targetProperty, string fieldName, string toolTip, GUIStyle propertyLabelStyle)
        {
            SerializedProperty serializedProperty = targetProperty;
            GUIStyle previousGlobalSkin = GUI.skin.label;

            GUI.skin.label = propertyLabelStyle;

            EditorGUILayout.PropertyField(serializedProperty, new GUIContent(fieldName, toolTip), true);
            serializedProperty.serializedObject.ApplyModifiedProperties();

            // Restores global skin to avoid confusion.
            GUI.skin.label = previousGlobalSkin;
        }

        /// <summary>
        /// Creates a PropertyField with a custom FieldName, ToolTip and Colour. It also applies any
        /// changes to the property.
        /// </summary>
        /// <param name="targetProperty"></param>
        /// <param name="fieldName"></param>
        /// <param name="toolTip"></param>
        /// <param name="labelColour"></param>
        public static void CreatePropertyField(SerializedProperty targetProperty, string fieldName, string toolTip, Color labelColour)
        {
            SerializedProperty serializedProperty = targetProperty;
            GUIStyle previousGlobalSkin = GUI.skin.label;
            GUIStyle colouredGlobalSkin = GUI.skin.label;

            GUI.skin.label.normal.textColor = Color.white;
            GUI.skin.box.normal.textColor = Color.white;
            serializedProperty.serializedObject.ApplyModifiedProperties();

            serializedProperty.serializedObject.ApplyModifiedProperties();

            GUILayout.Label(fieldName);
            EditorGUILayout.PropertyField(serializedProperty, new GUIContent("", toolTip), true);
            serializedProperty.serializedObject.ApplyModifiedProperties();

            // Restores global skin to avoid confusion.
        }

        #endregion Public Methods
    }
}