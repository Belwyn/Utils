using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Belwyn.Editor.Build {

    [CreateAssetMenu(fileName = "NewConfiguration", menuName = "Build/Configuration")]
    public class BuildConfiguration : ScriptableObject {

        [Serializable]
        public struct BuildConfig {
            [SerializeField]
            private List<string> _defineSymbols;
            public List<string> defineSymbols => _defineSymbols;

            [SerializeField]
            private bool _isTestingBuild;
            public bool isTestingBuild => _isTestingBuild;

            [SerializeField]
            private bool _isShippingBuild;
            public bool isShippingBuild => _isShippingBuild;
        }


        [Header("Standalone config")]
        [SerializeField]
        private BuildConfig _standaloneConfig;
        public BuildConfig standaloneConfig => _standaloneConfig;

        [Space()]

        [Header("Overrides")]

        [SerializeField]
        private bool _overrideAndroid;
        public bool overrideAndroid => _overrideAndroid;

        [SerializeField]
        private BuildConfig _androidConfig;
        public BuildConfig androidConfig => _androidConfig;

        [Space()]

        [SerializeField]
        private bool _overrideIOS;
        public bool overrideIOS => _overrideIOS;

        [SerializeField]
        private BuildConfig _iOSConfig;
        public BuildConfig iosConfig => _iOSConfig;

    }

}