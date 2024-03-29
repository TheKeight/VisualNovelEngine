﻿#if UNITY_EDITOR
using DevourDev.Unity.Utility.Attributes;
using UnityEditor;
using UnityEngine;

namespace DevourDev.Unity.Utility.Editor
{
    [CustomPropertyDrawer(typeof(RequiredAttribute))]
    public class RequiredDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label);

            if (property.objectReferenceValue == null)
            {
                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.HelpBox(position, "This field is required.", MessageType.Warning);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float baseHeight = base.GetPropertyHeight(property, label);
            if (property.objectReferenceValue == null)
            {
                baseHeight += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            }
            return baseHeight;
        }
    }
}
#endif