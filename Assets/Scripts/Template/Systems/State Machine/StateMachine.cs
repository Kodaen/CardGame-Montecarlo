using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

namespace StateMachineTool
{
    public class StateMachine<T> : MonoBehaviour where T : MonoBehaviour
    {
        [BoxGroup("State Machine")]
        [SerializeField, HideInPlayMode]
        private InstanceType _instanceType;

        [BoxGroup("State Machine")]
        [SerializeField, InlineEditor]
        [ListDrawerSettings(ShowFoldout = false)]
        private List<State<T>> _states;

        private State<T> _activeState;

        private Dictionary<Type, State<T>> _statesDico = new();

        protected virtual void Awake()
        {
            T stateMachine = GetComponent<T>();

            for (int i = 0; i < _states.Count; i++)
            {
                State<T> stateInstance = (_instanceType == InstanceType.CopiedData) ? Instantiate(_states[i]) : _states[i];

                _states[i] = stateInstance;
                _statesDico.Add(stateInstance.GetType(), stateInstance);
                stateInstance.Init(stateMachine);
            }
        }

        protected virtual void Start()
        {
            _activeState = _states[0];
            _activeState.Enter();
        }

        protected virtual void Update()
        {
            State<T> nextState = _statesDico[_activeState.GetNextState()];

            if (nextState != _activeState)
            {
                _activeState.Exit();
                _activeState = nextState;
                _activeState.Enter();
            }

            _activeState.Update();
        }

        private enum InstanceType
        {
            CopiedData,
            OriginalData
        }
    }
}
