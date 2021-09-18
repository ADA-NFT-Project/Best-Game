using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Units
{
    public class IdAttribute : PropertyAttribute {}

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(IdAttribute))]
    public class ScriptableObjectIdDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            GUI.enabled = false;
            if (string.IsNullOrEmpty(property.stringValue)) {
                property.stringValue = Guid.NewGuid().ToString();
            }
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }
#endif

    public abstract class IdScobject : ScriptableObject
    {
        [Id] [SerializeField] protected string id;

        public string ID
        {
            get => id;
        }
        
        private void OnValidate()
        {
#if UNITY_EDITOR
            if (id == "")
            {
                id = GUID.Generate().ToString();
                EditorUtility.SetDirty(this);
            }
#endif
        }
    }
}

