using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Units;
using UnityEditor;
using Object = System.Object;

namespace Database
{
    [CreateAssetMenu (fileName = "New Database", menuName = "Database")]
    public class Database : ScriptableObject
    {
        [SerializeField] private string type;
        [SerializeField] private string path;

        private Dictionary<string, IdScobject> getObject = new Dictionary<string, IdScobject>();

        public Dictionary<string, IdScobject> GetObject
        {
            get => getObject;
        }

        public void Add(IdScobject o)
        {
            getObject[o.ID] = o;
        }

        public void Remove(IdScobject o)
        {
            getObject.Remove(o.ID);
        }

        private void OnValidate()
        {
            Regenerate(); //possible performance issues
        }

        public void Regenerate()
        {
#if UNITY_EDITOR
            var objects = AssetDatabase.FindAssets("t:"+type, new []{path});

            List<IdScobject> scobjects = new List<IdScobject>();

            foreach (var o in objects)
            {
                scobjects.Add(AssetDatabase.LoadAssetAtPath<IdScobject>(AssetDatabase.GUIDToAssetPath(o)));
            }
            
            getObject = new Dictionary<string, IdScobject>();
            foreach (var sco in scobjects)
            {
                Add(sco);
                Debug.Log(sco.name + " added to database.");
            }
            Debug.Log("Added " + getObject.Count + " object(s) to database.");
            EditorUtility.SetDirty(this);
#endif  
        }
    }
}
