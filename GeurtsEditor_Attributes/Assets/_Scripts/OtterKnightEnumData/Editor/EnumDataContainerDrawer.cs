using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(EnumDataContainer<,>))]
public class EnumDataContainerDrawer : PropertyDrawer
{
    private const float FOLDOUT_HEIGHT = 16f;
    private bool _isCollapsed;

    private SerializedProperty _content;
    private SerializedProperty _enumType;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if(_content == null)
        {
            _content = property.FindPropertyRelative("_content");
        }

        if(_enumType == null)
        {
            _enumType = property.FindPropertyRelative("_enumType");
        }

        float height = FOLDOUT_HEIGHT;
        if(property.isExpanded)
        {
            if(_content.arraySize != _enumType.enumNames.Length)
                _content.arraySize = _enumType.enumNames.Length;

            for(int index = 0; index < _content.arraySize; index++)
            {
                height += EditorGUI.GetPropertyHeight(_content.GetArrayElementAtIndex(index));
            }
        }

        return height;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        Rect foldoutRect = new Rect(position.x, position.y, position.width, FOLDOUT_HEIGHT);
        property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, label);
        
        if(property.isExpanded)
        {
            EditorGUI.indentLevel++;

            float heightPosition = FOLDOUT_HEIGHT;
            for(int index = 0; index < _content.arraySize; index++)
            {
                Rect currentPropertyRect = new Rect(position.x, position.y + heightPosition, position.width, EditorGUI.GetPropertyHeight(_content.GetArrayElementAtIndex(index)));
                heightPosition += currentPropertyRect.height;
                EditorGUI.PropertyField(currentPropertyRect, _content.GetArrayElementAtIndex(index), new GUIContent(_enumType.enumNames[index]), true);
            }

            EditorGUI.indentLevel--;
        }
        EditorGUI.EndProperty();
    }
}