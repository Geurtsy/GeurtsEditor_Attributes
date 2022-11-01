using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Geurts.InspectorTools.Styling;

namespace Geurts.InspectorTools
{
    [CustomPropertyDrawer(typeof(GeurtsLabelAttribute))]
    public class GeurtsLabelDrawer : DecoratorDrawer
    {
        private float _lineHeight;

        private GeurtsLabelAttribute MyGeurtsHeaderAttribute
        {
            get { return (GeurtsLabelAttribute)attribute; }
        }

        public override float GetHeight()
        {
            float height = 0;

            height += _lineHeight;
            height += MyGeurtsHeaderAttribute._prefixSpacing;
            height += MyGeurtsHeaderAttribute._suffixSpacing;

            return height;
        }

        public override void OnGUI(Rect position)
        {
            GUIStyle style = new GUIStyle();

            switch (MyGeurtsHeaderAttribute._headingType)
            {
                case GeurtsLabelAttribute.GeurtsStyleType.HEADING_1:
                    style = GeurtsEditorFonts.HeaderFonts.FontHeader1;
                    break;

                case GeurtsLabelAttribute.GeurtsStyleType.HEADING_2:
                    style = GeurtsEditorFonts.HeaderFonts.FontHeader2;
                    break;

                case GeurtsLabelAttribute.GeurtsStyleType.HEADING_3:
                    style = GeurtsEditorFonts.HeaderFonts.FontHeader3;
                    break;

                case GeurtsLabelAttribute.GeurtsStyleType.HEADING_4:
                    style = GeurtsEditorFonts.HeaderFonts.FontHeader4;
                    break;

                case GeurtsLabelAttribute.GeurtsStyleType.NORMAL_NOTE:
                    style = GeurtsEditorFonts.NoteFonts.FontNote;
                    break;

                case GeurtsLabelAttribute.GeurtsStyleType.MAIN_NOTE:
                    style = GeurtsEditorFonts.NoteFonts.MainFontNote;
                    break;
            }

            Rect labelPosition = new Rect(position.x, position.y + MyGeurtsHeaderAttribute._prefixSpacing, position.width, style.lineHeight);
            EditorGUI.LabelField(labelPosition, MyGeurtsHeaderAttribute._headerString, style);

            _lineHeight = style.lineHeight;
        }
    }
}
