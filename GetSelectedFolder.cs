using UnityEngine;
using UnityEditor;

using System;
using System.Reflection;

public class EditorExt{

    private static EditorWindow GetWindowByName(string pName) {
        UnityEngine.Object[] winList = Resources.FindObjectsOfTypeAll(typeof(EditorWindow));
        foreach (UnityEngine.Object win in winList) {
            if (win.GetType().ToString() == pName)
                return ((EditorWindow)win);
        }
        return null;
    }
    public static string GetSelectedFolder() {
        string selectedFolder = "";
        EditorWindow projectWindow = GetWindowByName("UnityEditor.ProjectBrowser");
        if(projectWindow != null) {
            //Since this was an internal type of UnityEditor assembly, I need to pass the class and the assembly that the class belongs to Type.GetType.
            Type t = Type.GetType("UnityEditor.ProjectBrowser,UnityEditor");
            selectedFolder = (t.GetField("m_LastFolders", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(projectWindow) as string[])[0];
            //selectedFolder = t.GetField("m_SelectedPath", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(projectWindow) as string;
            //selectedFolder = AssetDatabase.GetAssetPath(Selection.activeObject);
        }
        return selectedFolder;
    }

    public static string GetSelectedFolder2()
    {
        string clickedAssetGuid = Selection.assetGUIDs[0];
        string clickedPath = AssetDatabase.GUIDToAssetPath(clickedAssetGuid);
        if (System.IO.Directory.Exists(clickedPath))
        {
            //Folder
        }
        else
        {
            //File
        }
    }
}