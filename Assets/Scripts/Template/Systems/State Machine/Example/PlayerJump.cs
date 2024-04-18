using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using StateMachineTool;

[CreateAssetMenu(menuName = "State Machine/Player/Jump")]
public class PlayerJump : State<PlayerController>
{
    public override void Enter() { }

    public override void Exit() { }

    public override void Update() { }

    public override Type GetNextState()
    {
        return typeof(PlayerJump);
    }
}
