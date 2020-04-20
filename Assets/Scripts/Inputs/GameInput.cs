using UnityEngine;

public sealed class GameInput : MonoBehaviour, IGameInput
{
    public bool IsGameStart() => Input.GetKeyDown(KeyCode.Space);
}
