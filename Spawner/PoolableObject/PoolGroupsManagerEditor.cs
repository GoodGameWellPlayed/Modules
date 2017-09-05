using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//TODO uncomment this
//[CustomEditor(typeof(PoolGroupsManager))]
public class PoolGroupsManagerEditor : Editor
{
    private string _newGroupName = string.Empty;
    [SerializeField] private PoolableObject _poolableObjectArray;
    
    private void OnEnable()
    {
    }

    public override void OnInspectorGUI()
    {
        PoolGroupsManager manager = (PoolGroupsManager)target;

        PaintTopButtons(manager);

        PaintSeparator();

        PaintPoolGroups(manager);

        PaintSeparator();

        PaintNewGroupCreation(manager);
    }

    private void PaintSeparator()
    {
        GUILayout.Space(20);
    }

    private void PaintTopButtons(PoolGroupsManager manager)
    {
        if (GUILayout.Button("Clear manager"))
        {
            manager.Dispose();
        }
    }

    private void PaintPoolGroups(PoolGroupsManager manager)
    {
        var _poolGroupArray = manager.GetPoolGroupArray();
        /*
        for (int i = 0; i < _poolGroupArray.Length; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(_poolGroupArray[i].Name);

            SerializedObject poolableObjectSerialized = _poolableObjectArray.;
            SerializedProperty poolableObjectProperty = _poolableObjectArray.;

            poolableObjectProperty.objectReferenceValue = 
            EditorGUILayout.PropertyField(poolableObjectProperty);
            //TODO do this!!!!!!!!!

            if (GUILayout.Button("X"))
            {
                manager.RemovePoolGroup(_poolGroupArray[i].Name);
            }
            GUILayout.EndHorizontal();
        }
        */
    }

    private void PaintNewGroupCreation(PoolGroupsManager manager)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("New group name: ");
        _newGroupName = GUILayout.TextField(_newGroupName);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Create a new group"))
        {
            if (_newGroupName != string.Empty)
            {
                manager.AddPoolGroup(new PoolableObjectsGroup(_newGroupName));
                _newGroupName = string.Empty;
                Repaint();
            }
        }
    }
}
