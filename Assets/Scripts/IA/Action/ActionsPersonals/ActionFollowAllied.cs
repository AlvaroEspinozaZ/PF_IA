using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("IA SC/Node Move")]
public class ActionFollowAllied : ActionNodeVehicle
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (aICharacterVehicle.Health.IsDead)
            return TaskStatus.Failure;
        SwitchMoveToAllied();
        return TaskStatus.Success;

    }
    void SwitchMoveToAllied()
    {
        switch (Unit)
        {
            case TypeUnit.Dog:
                if (aICharacterVehicle is AIVehicleDog)
                {
                    ((AIVehicleDog)aICharacterVehicle).MoveToAllied();
                }
                break;
            case TypeUnit.Wolf:
                if (aICharacterVehicle is AIVehicleWolf)
                {
                    //((AIVehicleWolf)aICharacterVehicle).MoveToEnemy();
                }
                break;
            default:
                break;
        }

    }
}
