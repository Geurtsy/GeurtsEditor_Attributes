using UnityEngine;

namespace Geurts.InspectorTools.Styling
{
    /// <summary>
    /// This class is used for styling backgrounds.
    /// </summary>
    public static class GeurtsBackgroundStyles
    {
        #region Public Classes

        /// <summary>
        /// This class returns backgrounds that have preset colours and padding.
        /// </summary>
        public static class BackgroundPreset
        {
            #region Public Methods

            public static GUIStyle BasicDark0Padding()
            {
                return GetBasicStyle(DarkBackgroundColours.GetDark0);
            }

            public static GUIStyle BasicDark1Padding()
            {
                return GetBasicStyle(DarkBackgroundColours.GetDark1);
            }

            public static GUIStyle BasicDark2Padding()
            {
                return GetBasicStyle(DarkBackgroundColours.GetDark2);
            }

            public static GUIStyle BasicDark3Padding()
            {
                return GetBasicStyle(DarkBackgroundColours.GetDark3);
            }

            public static GUIStyle BasicDark4Padding()
            {
                return GetBasicStyle(DarkBackgroundColours.GetDark4);
            }

            #endregion Public Methods
        }

        /// <summary>
        /// Dark colours for backgrounds
        /// </summary>
        public static class DarkBackgroundColours
        {
            #region Public Properties

            public static Color GetDark0 { get; private set; } = new Color(0.10f, 0.10f, 0.10f, 1);
            public static Color GetDark1 { get; private set; } = new Color(0.12f, 0.12f, 0.12f, 1);
            public static Color GetDark2 { get; private set; } = new Color(0.14f, 0.14f, 0.14f, 1);
            public static Color GetDark3 { get; private set; } = new Color(0.16f, 0.16f, 0.16f, 1);
            public static Color GetDark4 { get; private set; } = new Color(0.19f, 0.19f, 0.19f, 1);
            public static Color GetDark5 { get; private set; } = new Color(0.25f, 0.25f, 0.25f, 1);
            public static Color GetDark6 { get; private set; } = new Color(0.9f, 0.9f, 0.9f, 1);

            #endregion Public Properties
        }

        #endregion Public Classes

        #region Private Fields

        private const int _defaultPadding = 8;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Returns a GUIStyle for a background with a set Colour and preset padding.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static GUIStyle GetBasicStyle(Color color)
        {
            return GetStyle(color, _defaultPadding);
        }

        /// <summary>
        /// Returns a GUIStyle for a background with multiple settings.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="leftPadding"></param>
        /// <param name="rightPadding"></param>
        /// <param name="topPadding"></param>
        /// <param name="bottomPadding"></param>
        /// <returns></returns>
        public static GUIStyle GetSpecificStyle(Color color, int leftPadding, int rightPadding, int topPadding, int bottomPadding)
        {
            GUIStyle style = new GUIStyle();
            Texture2D texture = new Texture2D(1, 1);

            texture.SetPixel(0, 0, color);
            texture.Apply();
            style.normal.background = texture;
            style.padding = new RectOffset(leftPadding, rightPadding, topPadding, bottomPadding);
            return style;
        }

        /// <summary>
        /// Returns a GUIStyle for a background with custom Colour and Padding.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public static GUIStyle GetStyle(Color color, int padding)
        {
            GUIStyle style = new GUIStyle();
            Texture2D texture = new Texture2D(1, 1);

            texture.SetPixel(0, 0, color);
            texture.Apply();
            style.normal.background = texture;
            style.padding = new RectOffset(padding, padding, padding, padding);
            return style;
        }

        #endregion Public Methods
    }
}