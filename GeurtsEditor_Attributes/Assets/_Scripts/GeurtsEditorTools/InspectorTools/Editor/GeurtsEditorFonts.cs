using UnityEngine;

namespace Geurts.InspectorTools.Styling
{
    /// <summary>
    /// This class Returns many Font styles that are considered essential for editing the inspector
    /// with GeurtsEditorTools.
    /// </summary>
    public static class GeurtsEditorFonts
    {
        //public static GUIStyle FontNote = new GUIStyle { fontSize = 9, fontStyle = FontStyle.Italic, wordWrap = true };
        //public static GUIStyle FontButton = new GUIStyle { fontSize = 9, fontStyle = FontStyle.Bold, wordWrap = true };

        #region Public Classes
        /// <summary>
        /// Returns Fonts that are suitable for Headers.
        /// </summary>
        public static class HeaderFonts
        {
            #region Public Fields

            public static readonly Color _defaultHeaderColour = Color.white;

            #endregion Public Fields

            #region Public Properties

            public static GUIStyle FontHeader1 { get; private set; } = GetCustomFont(15, FontStyle.Bold, _defaultHeaderColour);
            public static GUIStyle FontHeader2 { get; private set; } = GetCustomFont(13, FontStyle.Bold, _defaultHeaderColour);
            public static GUIStyle FontHeader3 { get; private set; } = GetCustomFont(12, FontStyle.Bold, _defaultHeaderColour);
            public static GUIStyle FontHeader4 { get; private set; } = GetCustomFont(11, FontStyle.Bold, _defaultHeaderColour);

            #endregion Public Properties
        }

        /// <summary>
        /// Returns Fonts that are suitable for Notes.
        /// </summary>
        public class NoteFonts
        {
            #region Public Fields

            public static readonly Color _defaultNotesColour = Color.white;

            #endregion Public Fields

            #region Public Properties

            public static GUIStyle FontNote { get; private set; } = GetCustomFont(9, FontStyle.Italic, _defaultNotesColour);
            public static GUIStyle MainFontNote { get; private set; } = GetCustomFont(11, FontStyle.Italic, _defaultNotesColour);

            #endregion Public Properties
        }

        #endregion Public Classes

        #region Public Fields

        public static GUIStyle ButtonStyle = new GUIStyle(GUI.skin.button)
        {
            wordWrap = true,
            fontStyle = FontStyle.Bold,
            fontSize = 9,
            alignment = TextAnchor.UpperLeft
        };

        #endregion Public Fields

        #region Public Methods

        public static GUIStyle ChangeFontColour(GUIStyle font, Color colour)
        {
            GUIStyle changedFont = font;
            changedFont.normal.textColor = colour;
            return changedFont;
        }

        public static GUIStyle GetCustomFont(int fontSize, FontStyle fontStyle, Color fontColour)
        {
            GUIStyle customStyle = new GUIStyle { fontSize = fontSize, fontStyle = fontStyle, wordWrap = true };
            return ChangeFontColour(customStyle, fontColour);
        }

        #endregion Public Methods
    }
}