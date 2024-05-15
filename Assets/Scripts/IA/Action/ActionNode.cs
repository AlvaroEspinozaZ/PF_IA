using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("IA SC/Node Base")]

public class ActionNode : Action
{
    protected AICharacterVehicle aICharacterVehicle;
    protected AICharacterAction aICharacterAction;
    protected Health MyHealth;
    protected TypeUnit Unit;
    public override void OnStart()
    {
        aICharacterVehicle = GetComponent<AICharacterVehicle>();
        if (aICharacterVehicle == null)
            Debug.LogWarning("No load component AICharacterVehicle");
        aICharacterAction = GetComponent<AICharacterAction>();
        if (aICharacterAction==null)
            Debug.LogWarning("No load component AICharacterAction");
        if (aICharacterVehicle != null)
        {
            Unit = this.aICharacterVehicle.Health._TypeUnit;
        }
        else
            if (aICharacterAction != null)
            Unit = this.aICharacterAction.Health._TypeUnit;

        MyHealth = GetComponent<Health>();
        base.OnStart();
    }
}
