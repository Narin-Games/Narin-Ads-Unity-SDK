using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public enum TargerBuildKey {
    CafeBazaar, Googleplay
}

[CreateAssetMenu(fileName = "StorePlayerSettings", menuName = "Custom Build Pipline/Store Player Settings")]
public class StoreBuildPlayerSettings: ScriptableObject {
    public static Dictionary<TargerBuildKey, StoreBuildPlayerSettings> AllTargetBuildData 
        = new Dictionary<TargerBuildKey, StoreBuildPlayerSettings>();

    public TargerBuildKey Target;
    public List<string> ExcludedDirectories = new List<string>();

    void OnEnable() {
        RegisterToBuildData();
    }

    [ContextMenu("Add Excluded Directory")]
    private void AddExcludedDirectory() {
        string path = EditorUtility.SaveFolderPanel("Select folder for excluding in currect build", "", "");
        ExcludedDirectories.Add(path);
        EditorUtility.SetDirty(this);
        Debug.Log(path);
    }

    [ContextMenu("Register to Build Data")]
    private void RegisterToBuildData() {
        if (!AllTargetBuildData.ContainsKey(Target))
            AllTargetBuildData.Add(Target, this);
    }
}
