using System;
using UnityEngine;

namespace Lib
{
    public static class Extensions
    {
        public static Wait WaitForSeconds(this MonoBehaviour source, float seconds, Action action = null)
        {
            return new Wait(source, new WaitForSeconds(seconds), action);
        }

        public static Wait WaitEndOfFrame(this MonoBehaviour source, Action action = null)
        {
            return new Wait(source, new WaitForEndOfFrame(), action);
        }

        public static Wait WaitCoroutine(this MonoBehaviour source, Coroutine target, Action action = null)
        {
            return new Wait(source, target, action);
        }
    }
}
