using System;
using System.Reflection;
using UnityEngine;

namespace CrynanoLib
{
    internal static class Logger
    {
        static string LogPrefix => Assembly.GetExecutingAssembly().GetName().Name;

        internal static void Log(string message)
        {
            Debug.Log($"[{LogPrefix}] {message}");
        }

        internal static void LogDebug(string message)
        {
#if DEBUG
            Debug.Log($"[{LogPrefix}] {message}");
#endif
        }

        internal static void LogWarning(string message)
        {
            Debug.LogWarning($"[{LogPrefix}] {message}");
        }

        internal static void LogError(string message)
        {
            Debug.LogError($"[{LogPrefix}] {message}");
        }

        internal static void LogException(Exception ex)
        {
            Debug.LogError($"[{LogPrefix}] Exception Logged:");
            Debug.LogException(ex);
        }
    }
}
