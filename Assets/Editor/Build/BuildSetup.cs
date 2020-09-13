using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Belwyn.Editor.Build {

	public static class BuildSetup {

		public const string testSymbols = "TEST_BUILD";

		public const string shippingSymbols = "SHIPPING_BUILD";
		
		[MenuItem("Build/Build Setups/Default Shipping", priority = 101)]
		public static void DefaultShippingSetup() {
			string symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);

			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, shippingSymbols);
			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, shippingSymbols);
			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, shippingSymbols);

			Debug.Log("------ Applied defualt shipping configuration ------");
		}

		[MenuItem("Build/Build Setups/Default Testing", priority = 102)]
		public static void DefaultTestingSetup() {
			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, testSymbols);
			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, testSymbols);
			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, testSymbols);

			Debug.Log("------ Applied defualt testing configuration ------");
		}


		public static void Setup(BuildConfiguration config) {

			string symbols = string.Join(";", config.standaloneConfig.defineSymbols);

			symbols += config.standaloneConfig.isTestingBuild ? $";{testSymbols}" : "";
			symbols += config.standaloneConfig.isShippingBuild ? $";{shippingSymbols}" : "";


			// Standalone

			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, symbols);


			// Android

			if (config.overrideAndroid) {
				string androidSymbols = string.Join(";", config.androidConfig.defineSymbols);
				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, androidSymbols);
			} 
			else {
				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, symbols);
			}


			// iOS

			if (config.overrideIOS) {
				string iosSymbols = string.Join(";", config.iosConfig.defineSymbols);
				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, iosSymbols);
			} 
			else {
				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, symbols);
			}

			Debug.Log($"------ Applied configuration from {config.name} ------");
		}

	}

}