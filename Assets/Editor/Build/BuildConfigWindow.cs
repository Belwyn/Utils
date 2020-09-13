using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;


namespace Belwyn.Editor.Build {

    public class BuildConfigWindow : EditorWindow {

        private string[] _guids;
        private string[] _names;
        private BuildConfiguration[] _configurations;
        private int _idx;


        // Add menu named "My Window" to the Window menu
        [MenuItem("Build/Build Setups/Configuration selector")]
        static void Init() {
            // Get existing open window or if none, make a new one:
            BuildConfigWindow window = (BuildConfigWindow)GetWindow(typeof(BuildConfigWindow));
            window.Show();
        }

        private void Awake() {
            _idx = 0;
            _guids = AssetDatabase.FindAssets("t:" + typeof(BuildConfiguration).Name);
            _names = new string[_guids.Length];
            _configurations = new BuildConfiguration[_guids.Length];
            for (int i = 0; i < _guids.Length; i++) {
                string path = AssetDatabase.GUIDToAssetPath(_guids[i]);
                _names[i] = path.Split('/').LastOrDefault();
                _configurations[i] = AssetDatabase.LoadAssetAtPath<BuildConfiguration>(path);
            }
        }

        void OnGUI() {

            EditorGUILayout.Space();

            GUILayout.Label("Defaults", EditorStyles.boldLabel);

            EditorGUILayout.Space();

            if (GUILayout.Button(new GUIContent("Apply Default Testing"))) {
                BuildSetup.DefaultTestingSetup();
            }

            if (GUILayout.Button(new GUIContent("Apply Default Shipping"))) {
                BuildSetup.DefaultShippingSetup();
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            GUILayout.Label("Select Configuration", EditorStyles.boldLabel);

            EditorGUILayout.Space();

            if (_guids.Length == 0) {
                EditorGUILayout.LabelField("Create a build configuration asset first");
            }
            else {
                _idx = EditorGUILayout.Popup(_idx, _names);
                EditorGUILayout.Space();

                if (GUILayout.Button(new GUIContent("Apply Selected Configuration"))) {
                    BuildSetup.Setup(_configurations[_idx]);                    
                }
            }
            
        }

    }


}