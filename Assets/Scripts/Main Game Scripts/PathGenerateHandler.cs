using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class PathGenerateHandler : MonoBehaviour
{
    public static PathGenerateHandler Instance;
    public List<GameObject> myListOfPath = new List<GameObject>();
    public GameObject LinePathPrefab;
    public Transform Spawnpoint;
    public int theCurrentNumber;

    private void Awake() {
        Instance = this;
    }

    #region Editor
    #if UNITY_EDITOR

    [CustomEditor(typeof(PathGenerateHandler))]
    public class LineEditor : Editor {
        string thisField;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            PathGenerateHandler thisItem = (PathGenerateHandler)target;

            if(GUILayout.Button("Create Line")) {
                thisItem.GenerateLine();
            } 
            GUILayout.Space(15);
            if(GUILayout.Button("Remove All Path")) {
                for(int i = 0; i < thisItem.myListOfPath.Count; i++) {
                    DestroyImmediate(thisItem.myListOfPath[i]);
                } thisItem.myListOfPath.Clear();
            }
            GUILayout.Space(15);
            thisField = GUILayout.TextField(thisField);
            if(GUILayout.Button("Remove Specific Path")) {
                thisItem.RemovePath(int.Parse(thisField) -1);
            }
            if(EditorGUI.EndChangeCheck()) {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
    #endif
    #endregion

    public void GenerateLine() {
        GameObject thisGO = Instantiate(LinePathPrefab, Spawnpoint);
        theCurrentNumber = myListOfPath.Count;
        myListOfPath.Add(thisGO);
        theCurrentNumber += 1;
        thisGO.GetComponent<PathDrawer>().MyCurrentNumber = theCurrentNumber;
    }

    public void RemovePath(int itemNun) {
        DestroyImmediate(myListOfPath[itemNun]);
        myListOfPath.RemoveAt(itemNun);
        theCurrentNumber = myListOfPath.Count;
        for(int i = 1; i <= myListOfPath.Count; i++) {
            myListOfPath[i - 1].GetComponent<PathDrawer>().MyCurrentNumber = 1;
        }
    }
}
