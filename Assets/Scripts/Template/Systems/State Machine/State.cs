using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StateMachineTool
{
    public abstract class State<T> : ScriptableObject where T : MonoBehaviour
    {
        protected T _stateMachine;

        public virtual void Init(T stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update();

        public abstract Type GetNextState();
    }
}
