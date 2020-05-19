using TankProject.Interfaces;
using UnityEngine;

namespace TankProject.Inputs
{
    public sealed class StandloneStartInput : IStartInput
    {
        public bool IsGameStart() => Input.GetKeyDown(KeyCode.Space);
    }
}
