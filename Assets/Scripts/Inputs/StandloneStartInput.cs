using UnityEngine;

public sealed class StandloneStartInput : IStartInput
{
    public bool IsGameStart() => Input.GetKeyDown(KeyCode.Space);
}
