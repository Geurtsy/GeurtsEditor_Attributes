using Geurts.InspectorTools.Styling;
using UnityEditor;
using UnityEngine;

namespace Geurts.InspectorTools
{
    /// <summary>
    /// Creates sections with predetermined formatted unless otherwise specified. Useful for
    /// creating formatted sections quickly.
    /// </summary>
    public class GeurtsEditorSectionCreator
    {
        #region Public Classes

        /// <summary>
        /// Creates common Section with Predetermined Formatting unless otherwise specified.
        /// </summary>
        public static class CommonSectionPresets
        {
            #region Private Fields

            private const int _defaultHeaderGapping = 5;
            private const int _defaultPadding = 8;
            private const int _defaultSectionGapping = 10;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Begins a Section that uses predetermined background colour and header font with a
            /// specified header.
            /// </summary>
            /// <param name="header">Text at the beginning of the section with Header2 font.</param>
            public static void BeginSection2(string header)
            {
                GeurtsEditorAreaCreator.BeginArea(GeurtsBackgroundStyles.DarkBackgroundColours.GetDark2, false, _defaultPadding, GeurtsEditorFonts.HeaderFonts.FontHeader2, header, _defaultHeaderGapping);
            }

            /// <summary>
            /// Begins a Section that uses predetermined background colour, header and note font
            /// with a specified header and note.
            /// </summary>
            /// <param name="header">Text at the beginning of the section with Header2 font.</param>
            /// <param name="notes">Text after the header with standard note font</param>
            public static void BeginSection2(string header, string notes)
            {
                GeurtsEditorAreaCreator.BeginArea(
                    GeurtsBackgroundStyles.DarkBackgroundColours.GetDark3,
                    false,
                    _defaultPadding,
                    GeurtsEditorFonts.HeaderFonts.FontHeader2,
                    header, _defaultHeaderGapping,
                    GeurtsEditorFonts.NoteFonts.FontNote,
                    notes);
            }

            /// <summary>
            /// Begins a Section that uses predetermined background colour, header and note font
            /// </summary>
            /// <param name="header">Text at the beginning of the section with Header3 font.</param>
            public static void BeginSection3(string header)
            {
                GeurtsEditorAreaCreator.BeginArea(GeurtsBackgroundStyles.DarkBackgroundColours.GetDark3, false, _defaultPadding, GeurtsEditorFonts.HeaderFonts.FontHeader3, header, _defaultHeaderGapping);
            }

            /// <summary>
            /// Begins a Section that uses predetermined background colour, header and note font
            /// with a specified header and note.
            /// </summary>
            /// <param name="header">Text at the beginning of the section with Header3 font.</param>
            /// <param name="notes">Text after the header with standard note font</param>
            public static void BeginSection3(string header, string notes)
            {
                GeurtsEditorAreaCreator.BeginArea(
                    GeurtsBackgroundStyles.DarkBackgroundColours.GetDark3,
                    false,
                    _defaultPadding,
                    GeurtsEditorFonts.HeaderFonts.FontHeader3,
                    header, _defaultHeaderGapping,
                    GeurtsEditorFonts.NoteFonts.FontNote,
                    notes);
            }

            /// <summary>
            /// Begins a Section that uses predetermined background colour, padding, header and note font
            /// </summary>
            /// <param name="header">Text at the beginning of the section with Header4 font.</param>
            public static void BeginSection4(string header)
            {
                GeurtsEditorAreaCreator.BeginArea(GeurtsBackgroundStyles.DarkBackgroundColours.GetDark4, false, _defaultPadding, GeurtsEditorFonts.HeaderFonts.FontHeader4, header, 0);
            }

            /// <summary>
            /// Begins a Section that uses predetermined background colour, header and note font
            /// with a specified header and note.
            /// </summary>
            /// <param name="header">Text at the beginning of the section with Header4 font.</param>
            /// <param name="notes">Text after the header with standard note font</param>
            public static void BeginSection4(string header, string notes)
            {
                GeurtsEditorAreaCreator.BeginArea(
                    GeurtsBackgroundStyles.DarkBackgroundColours.GetDark4,
                    false,
                    _defaultPadding,
                    GeurtsEditorFonts.HeaderFonts.FontHeader4,
                    header, _defaultHeaderGapping,
                    GeurtsEditorFonts.NoteFonts.FontNote,
                    notes);
            }

            /// <summary>
            /// Ends a common Section with DefaultGapping.
            /// </summary>
            public static void EndCommonSection()
            {
                GeurtsEditorAreaCreator.EndArea(false, false, _defaultSectionGapping);
            }

            /// <summary>
            /// Ends a common Section with DefaultGapping and a Divider.
            /// </summary>
            /// <param name="hasDividerAfter">
            /// Determines the positioning of the divider (Before or After Spacing).
            /// </param>
            public static void EndCommonSection(bool hasDividerAfter)
            {
                if (!hasDividerAfter)
                    GeurtsEditorMiscTools.CreateDivider();

                GeurtsEditorAreaCreator.EndArea(false, false, _defaultHeaderGapping);

                if (hasDividerAfter)
                    GeurtsEditorMiscTools.CreateDivider();
            }

            /// <summary>
            /// Ends a common Section with specified Gapping.
            /// </summary>
            /// <param name="spacing">Determines the Spacing after the end of the Section.</param>
            public static void EndCommonSection(int spacing)
            {
                GeurtsEditorAreaCreator.EndArea(false, false, spacing);
            }

            /// <summary>
            /// Ends a common Section with specified Gapping and a Divider.
            /// </summary>
            /// <param name="spacing">Determines the Spacing after the end of the Section.</param>
            /// <param name="hasDividerAfter">
            /// Determines the positioning of the divider (Before or After Spacing).
            /// </param>
            public static void EndCommonSection(int spacing, bool hasDividerAfter)
            {
                if (!hasDividerAfter)
                    GeurtsEditorMiscTools.CreateDivider();

                GeurtsEditorAreaCreator.EndArea(false, false, spacing);

                if (hasDividerAfter)
                    GeurtsEditorMiscTools.CreateDivider();
            }

            #endregion Public Methods
        }

        /// <summary>
        /// Creates MainSections with Predetermined Formatting.
        /// </summary>
        public static class MainSectionPresets
        {
            #region Private Fields

            private const int _defaultHeaderGapping = 5;
            private const int _defaultPadding = 8;
            private const int _defaultSectionGapping = 15;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Begins the DebugTools Section.
            /// </summary>
            public static void BeginDebugToolsSection()
            {
                GeurtsEditorMiscTools.BeginBorder();
                GeurtsEditorAreaCreator.BeginArea(GeurtsBackgroundStyles.DarkBackgroundColours.GetDark4,
                    false,
                    _defaultPadding,
                    GeurtsEditorFonts.HeaderFonts.FontHeader1,
                    "Debug Tools",
                    2);
                GeurtsEditorMiscTools.CreateDivider(2, 0, _defaultHeaderGapping, Color.white);
            }

            /// <summary>
            /// Begins the Notes Section.
            /// </summary>
            public static void BeginNotesSection()
            {
                GeurtsEditorMiscTools.BeginBorder();
                GeurtsEditorAreaCreator.BeginArea(
                    GeurtsBackgroundStyles.DarkBackgroundColours.GetDark4,
                    false,
                    _defaultPadding,
                    GeurtsEditorFonts.HeaderFonts.FontHeader1,
                    "Notes",
                    2);
                GeurtsEditorMiscTools.CreateDivider(2, 0, _defaultHeaderGapping, Color.white);
            }

            /// <summary>
            /// Begins the Variables Section.
            /// </summary>
            public static void BeginVariablesSection()
            {
                GeurtsEditorMiscTools.BeginBorder();
                GeurtsEditorAreaCreator.BeginArea(GeurtsBackgroundStyles.DarkBackgroundColours.GetDark4,
                    false,
                    _defaultPadding,
                    GeurtsEditorFonts.HeaderFonts.FontHeader1,
                    "Settings",
                    2);
                GeurtsEditorMiscTools.CreateDivider(2, 0, _defaultHeaderGapping, Color.white);
            }

            /// <summary>
            /// Ends a Main Section.
            /// </summary>
            public static void EndMainSection()
            {
                GeurtsEditorMiscTools.EndBorder();
                GeurtsEditorAreaCreator.EndArea(false, false, _defaultSectionGapping);
            }

            #endregion Public Methods
        }

        #endregion Public Classes

        #region Public Methods

        /// <summary>
        /// Creates a Section that Notifies the user of required NamingProtocol. It allows the User
        /// to Create custom Identifiers and Fix Naming informalities.
        /// </summary>
        /// <param name="targetGameObject">The GameObject that requries specific naming protocol.</param>
        /// <param name="requiredName"></param>
        public static void CreateCustomIdentitySection(GameObject targetGameObject, string requiredName)
        {
            if (targetGameObject == null)
                GeurtsEditorFieldTools.CreateInternalErrorMessage("CreateCustomIdentitySection - targetGameObject is null.\nFunction will not run.");

            string customName = "";
            string[] splitNames = targetGameObject.name.Split(' ');

            if (splitNames.Length <= 1)
            {
                customName = "Unnamed";
                targetGameObject.name += " (" + customName + ")";
            }
            else
            {
                customName = splitNames[1];
            }

            customName = customName.TrimStart('(');
            customName = customName.TrimEnd(')');

            GeurtsEditorAreaCreator.BeginArea(GeurtsEditorColours._dark3, false, 5, GeurtsEditorFonts.HeaderFonts.FontHeader3, "Custom Identifier - " + customName, 2);
            if (splitNames[0] == requiredName)
            {
                customName = EditorGUILayout.TextField(customName);
                targetGameObject.name = requiredName + " (" + customName + ")";
            }
            else
                GeurtsEditorFieldTools.CreateNote("The target GameObject must have the correct naming format before editing the CustomIdentifier", false);

            if (GUILayout.Button("Refresh Name"))
            {
                targetGameObject.name = requiredName + " (" + customName + ")";
            }
            GeurtsEditorAreaCreator.EndArea(false, false, 20);
        }

        #endregion Public Methods
    }
}