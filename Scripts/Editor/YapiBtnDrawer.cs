using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace YapiBtn
{
    [CustomEditor(typeof(YapiBehavior), true)]
    public class YapiBtnDrawer : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var targetType = target.GetType();
            var methods = targetType.GetMethods(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var method in methods)
            {
                if (Attribute.IsDefined(method, typeof(YapiBtnAttribute)))
                {
                    if (GUILayout.Button(method.Name))
                    {
                        try
                        {
                            if (method.IsStatic)
                            {
                                method.Invoke(null, null);
                            }
                            else
                            {
                                method.Invoke(target, null);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.LogError($"YapiBtn: [{method.Name}] Execute Error: {ex}");
                        }
                    }
                }
            }
        }
    }
}