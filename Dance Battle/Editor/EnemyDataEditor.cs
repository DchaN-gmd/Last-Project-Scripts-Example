using DanceBattle;
using General.Editor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyData))]
[CanEditMultipleObjects()]
public class EnemyDataEditor : Editor
{
    private EnemyData _currentEnemyData;

    private void OnEnable()
    {
        _currentEnemyData = (EnemyData)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var files = Resources.LoadAll<EnemyData>("");

        foreach (var file in files)
        {
            if (file.GetInstanceID() == _currentEnemyData.GetInstanceID()) continue;

            if (file.RoundIndex == _currentEnemyData.RoundIndex)
            {
                EditorGUILayout.HelpBox($"Index has been assigned, {file.name}", MessageType.Error);
                break;
            }
        }
    }
}

