using TankProject.Units;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BomberMonster))]
public class BomberMonsterEditor : Editor
{
    private void OnSceneGUI()
    {
        var monster = (BomberMonster) target;
        Handles.color = Color.green;
        Handles.DrawWireArc(monster.transform.position, Vector3.back, Vector3.right, 360, monster.LesionRadius);
    }
}
