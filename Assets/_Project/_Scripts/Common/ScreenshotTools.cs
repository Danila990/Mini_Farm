#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

namespace MiniFarm
{
    public static class ScreenshotTools
    {
        private const string PATH_FOLDER = "GameScreenshots";

        [MenuItem("Tools/Screenshot")]
        public static void TakeScreenshot()
        {
            Directory.CreateDirectory(PATH_FOLDER);

            int i = 0;

            while (File.Exists( $"{PATH_FOLDER}/Screenshot {i}.png"))
                i++;
            
            ScreenCapture.CaptureScreenshot($"{PATH_FOLDER}/Screenshot {i}.png");
        }
    }
}
#endif