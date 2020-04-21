using UnityEngine;

public sealed class StandloneStartInput : MonoBehaviour, IStartInput
{
    public bool IsGameStart() => Input.GetKeyDown(KeyCode.Space);
}
