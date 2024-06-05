using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("IA SC/Node Move")]

public class ActionEvadeEnemy : ActionNodeVehicle
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (aICharacterVehicle.Health.IsDead)
            return TaskStatus.Failure;
        SwitchEvade();
        return TaskStatus.Success;

    }
    void SwitchEvade()
    {
        switch (Unit)
        {
            case TypeUnit.Sheep:
                if (aICharacterVehicle is AIVehicleSheep)
                {
                    ((AIVehicleSheep)aICharacterVehicle).Evade();
                }
                break;
            default:
                break;
        }

    }
}
