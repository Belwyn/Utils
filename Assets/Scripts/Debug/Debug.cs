using System;
using UnityEditor;
using UnityEngine;

namespace Belwyn.Utils {

    // This classes are a implementation of Unity's Debug class, however each call to unity is wrapped with a TEST_BUILD directive
    // If the TEST_BUILD is not defined the debug calls will not happen, making a non-test build cleaner, and without needing to change your code!

    // I've separated it in two classes for better comprehension. Logger is for logging, Debugger is for other debug things.

    public class Debugger {

        // Use this method with a lambda [ () => function(); ] to execute it only when testing
        public static void Invoke(Action action) {
        #if TEST_BUILD
            action?.Invoke();
        #endif
        }


        public static void Break() {
        #if TEST_BUILD
            Debug.Break();
        #endif
        }

        public static void ClearDevelopmentConsole() {
        #if TEST_BUILD
            Debug.ClearDeveloperConsole();
        #endif
        }


        public static void DrawLine(Vector3 start, Vector3 end, Color color = default, float duration = 0.0f, bool depthTest = true) {
        #if TEST_BUILD
            Debug.DrawLine(start, end, color, duration, depthTest);
        #endif
        }

        public static void DrawRay(Vector3 start, Vector3 dir, Color color = default, float duration = 0.0f, bool depthTest = true) {
        #if TEST_BUILD
            Debug.DrawRay(start, dir, color, duration, depthTest);
        #endif
        }

    }


    public class Logger {

    #region Assert
        public static void Assert(bool condition) {
        #if TEST_BUILD
            Debug.Assert(condition);
        #endif
        }

        public static void Assert(bool condition, UnityEngine.Object context) {
        #if TEST_BUILD
            Debug.Assert(condition, context);
        #endif
        }

        public static void Assert(bool condition, object message) {
        #if TEST_BUILD
            Debug.Assert(condition, message);
        #endif
        }

        public static void Assert(bool condition, object message, UnityEngine.Object context) {
        #if TEST_BUILD
            Debug.Assert(condition, message, context);
        #endif
        }
    #endregion Assert




    #region AssertFormat
        public static void AssertFormat(bool condition, string format, params object[] args) {
        #if TEST_BUILD
            Debug.AssertFormat(condition, format, args);
        #endif
        }


        public static void AssertFormat(bool condition, UnityEngine.Object context, string format, params object[] args) {
        #if TEST_BUILD
            Debug.AssertFormat(condition, context, format, args);
        #endif
        }
    #endregion AssertFormat




    #region Log
        public static void Log(object message) {
        #if TEST_BUILD
            Debug.Log(message);
        #endif
        }

        public static void Log(object message, UnityEngine.Object context) {
        #if TEST_BUILD
            Debug.Log(message, context);
        #endif
        }
    #endregion Log




    #region LogAssertion
        public static void LogAssertion(object message) {
        #if TEST_BUILD
            Debug.LogAssertion(message);
        #endif
        }

        public static void LogAssertion(object message, UnityEngine.Object context) {
        #if TEST_BUILD
            Debug.LogAssertion(message, context);
        #endif
        }
    #endregion




    #region LogAssertionFormat
        public void LogAssertionFormat(string format, params object[] args) {
        #if TEST_BUILD
            Debug.LogAssertionFormat(format, args);
        #endif
        }

        public void LogAssertionFormat(UnityEngine.Object context, string format, params object[] args) {
        #if TEST_BUILD
            Debug.LogAssertionFormat(context, format, args);
        #endif
        }
    #endregion LogAssertionFormat




    #region LogError
        public static void LogError(object message) {
        #if TEST_BUILD
            Debug.LogError(message);
        #endif
        }

        public static void LogError(object message, UnityEngine.Object context) {
        #if TEST_BUILD
            Debug.LogError(message, context);
        #endif
        }
    #endregion




    #region LogErrorFormat
        public static void LogErrorFormat(string format, params object[] args) {
        #if TEST_BUILD
            Debug.LogErrorFormat(format, args);
        #endif
        }

        public static void LogErrorFormat(UnityEngine.Object context, string format, params object[] args) {
        #if TEST_BUILD
            Debug.LogErrorFormat(context, format, args);
        #endif
        }
    #endregion LogErrorFormat





    #region LogException
        public static void LogException(Exception exception) {
        #if TEST_BUILD
            Debug.LogException(exception);
        #endif
        }

        public static void LogException(Exception exception, UnityEngine.Object context) {
        #if TEST_BUILD
            Debug.LogException(exception, context);
        #endif
        }
    #endregion LogException





    #region LogFormat
        public static void LogFormat(string format, params object[] args) {
        #if TEST_BUILD
            Debug.LogFormat(format, args);
        #endif
        }

        public static void LogFormat(UnityEngine.Object context, string format, params object[] args) {
        #if TEST_BUILD
            Debug.LogFormat(context, format, args);
        #endif
        }

        public static void LogFormat(LogType logType, LogOption logOptions, UnityEngine.Object context, string format, params object[] args) {
        #if TEST_BUILD
            Debug.LogFormat(logType, logOptions, context, format, args);
        #endif
        }
    #endregion LogFormat





    #region LogWarning
        public static void LogWarning(object message) {
        #if TEST_BUILD
            Debug.LogWarning(message);
        #endif
        }

        public static void LogWarning(object message, UnityEngine.Object context) {
        #if TEST_BUILD
            Debug.LogWarning(message, context);
        #endif
        }
    #endregion LogWarning





    #region LogWarningFormat
        public static void LogWarningFormat(string format, params object[] args) {
        #if TEST_BUILD
            Debug.LogWarningFormat(format, args);
        #endif
        }

        public static void LogWarningFormat(UnityEngine.Object context, string format, params object[] args) {
        #if TEST_BUILD
            Debug.LogWarningFormat(context, format, args);
        #endif
        }
    #endregion LogWarningFormat

    }

}