using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Belwyn.Editor.Build;

namespace Belwyn.Editor.Build {
 
    [CustomEditor(typeof(BuildConfiguration))]
    public class BuildConfigurationEditor : UnityEditor.Editor {

        public override void OnInspectorGUI() {

            base.OnInspectorGUI();

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();

            if (GUILayout.Button("Apply this configuration")) {
                BuildConfiguration config = target as BuildConfiguration;
                if (config != null)
                    BuildSetup.Setup(config);
            }

        }

    }

}