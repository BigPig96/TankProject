using TankProject.Shells;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TankShell))]
public sealed class TankShellEditor : Editor
{
    private void OnSceneGUI()
    {
        var shell = (TankShell) target;
        Handles.color = Color.green;
        Handles.DrawWireArc(shell.transform.position, Vector3.back, Vector3.right, 360, shell.LesionRadius);
    }
}
