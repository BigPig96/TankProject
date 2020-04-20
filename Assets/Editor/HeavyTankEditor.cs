using TankProject.Units;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HeavyTank))]
public sealed class HeavyTankEditor : Editor
{
    private void OnSceneGUI()
    {
        var heavyTank = (HeavyTank) target;
        Handles.color = Color.green;
        Handles.DrawWireArc(heavyTank.transform.position, Vector3.back, Vector3.right, 360, heavyTank.LesionRadius);
    }
}
