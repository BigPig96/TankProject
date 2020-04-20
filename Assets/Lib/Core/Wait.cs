using System;
using System.Collections;
using UnityEngine;

namespace Lib
{
    public sealed class Wait : IDisposable
    {
        private readonly YieldInstruction _instruction;
        private Action _action;

        private readonly MonoBehaviour _source;
        private Coroutine _current;

        public Wait(MonoBehaviour source, YieldInstruction instruction, Action action)
        {
            _source = source;
            _instruction = instruction;
            _action = action;
        }

        public void SetAction(Action action)
        {
            _action = action;
        }

        public Wait Start()
        {
            Dispose();

            if (_instruction != null && _action != null)
            {
                _current = _source.StartCoroutine(WaitAndDo(_instruction, _action));
                return this;
            }

            Debug.LogError($"Object: {_source.GetType()} doesnt have instruction or action!");
            return this;
        }
        
        public void Dispose()
        {
            if(_current != null)
                _source.StopCoroutine(_current);
            _current = null;
        }

        public static implicit operator Coroutine(Wait instance)
        {
            return instance._current;
        }

        private static IEnumerator WaitAndDo(YieldInstruction instruction, Action action)
        {
            yield return instruction;
            action();
        }
    }
}
