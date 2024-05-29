using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("IA SC/Node Move")]
public class ActionGetToy : ActionNodeVehicle
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (aICharacterVehicle.Health.IsDead)
            return TaskStatus.Failure;
        SwitchMoveToToy();
        return TaskStatus.Success;

    }

    void SwitchMoveToToy()
    {
        switch (Unit)
        {
            case TypeUnit.Dog:
                if (aICharacterVehicle is AIVehicleDog)
                {
                    ((AIVehicleDog)aICharacterVehicle).MoveToObject();
                }
                break;
            case TypeUnit.Wolf:
                break;
            default:
                break;
        }

    }
}