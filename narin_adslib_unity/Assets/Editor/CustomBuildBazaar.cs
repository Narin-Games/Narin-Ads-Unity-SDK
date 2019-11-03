using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using efo = EFO.Unity.Editor;
using System;
using UnityEditor.Compilation;

public static class CustomBuildBazaar {
    
    [MenuItem("Custom Build/Android/Cafe Bazaar")]
    public static void Build() {
       // BuildPlayerOptions buildOption = new BuildPlayerOptions();
        
        string[] paths = StoreBuildPlayerSettings
            .AllTargetBuildData[TargerBuildKey.CafeBazaar]
            .ExcludedDirectories.ToArray();
        

        for(int i=0; i<paths.Length; ++i) {
            string windowsPath = efo.EditorTools.ConvertToWindowsPath(paths[i]);
            Debug.Log(paths[i] +"  "+ windowsPath);
            Directory.Move(windowsPath, windowsPath+'~');
        }

        EditorUtility.DisplayProgressBar("Loading", "Refreshing Asset DB and Recompiling...", 0);
        CompilationPipeline.assemblyCompilationStarted += CompilationStartedHandler;
        CompilationPipeline.assemblyCompilationFinished += CompilationFinishedHandler;
        AssetDatabase.Refresh();
    }

    private static void CompilationStartedHandler(string obj) {
        EditorUtility.DisplayProgressBar("Loading", "Refreshing Asset DB and Recompiling...", 0.5f);
        
    }

    private static void CompilationFinishedHandler (string message, CompilerMessage[] messages) {
        CompilationPipeline.assemblyCompilationFinished -= CompilationFinishedHandler;
        CompilationPipeline.assemblyCompilationStarted  -= CompilationStartedHandler;

        EditorUtility.DisplayProgressBar("Loading", "Refreshing Asset DB and Recompiling...", 1);
        EditorUtility.ClearProgressBar();

        string[] paths = StoreBuildPlayerSettings
            .AllTargetBuildData[TargerBuildKey.CafeBazaar]
            .ExcludedDirectories.ToArray();

        try {
            var sceneList = EditorBuildSettingsScene.GetActiveSceneList(EditorBuildSettings.scenes);
            string buildPath = EditorUtility.SaveFilePanel("Save CafeBazaar Build", "", "CafeBazaar", "apk");
            string windowsBuildPath = efo.EditorTools.GetWindowsDirectory(buildPath);
            Debug.Log(windowsBuildPath);
            string buildLog = BuildPipeline.BuildPlayer(sceneList, buildPath, BuildTarget.Android, BuildOptions.None);
            Debug.Log(buildLog);

            if (windowsBuildPath != "")
                System.Diagnostics.Process.Start("explorer.exe", windowsBuildPath);
        } catch (Exception e) {
            for (int i = 0; i < paths.Length; ++i) {
                string windowsPath = efo.EditorTools.GetWindowsDirectory(paths[i]);
                Directory.Move(windowsPath + '~', windowsPath.Substring(0, windowsPath.Length));
            }
            AssetDatabase.Refresh();
            throw e;
        }

        for (int i = 0; i < paths.Length; ++i) {
            string windowsPath = efo.EditorTools.ConvertToWindowsPath(paths[i]);
            Directory.Move(windowsPath + '~', windowsPath.Substring(0, windowsPath.Length));
            Debug.Log(windowsPath.Substring(0, windowsPath.Length));
        }
        AssetDatabase.Refresh();
    }
}