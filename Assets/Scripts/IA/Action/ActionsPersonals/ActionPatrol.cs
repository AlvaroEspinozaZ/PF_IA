using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("IA SC/Node Move")]
public class ActionPatrol : ActionNode
{
    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        if (aICharacterVehicle.Health.IsDead)
            return TaskStatus.Failure;
        SwitchWander();
        return TaskStatus.Success;

    }
    void SwitchWander()
    {
        switch (Unit)
        {
            case TypeUnit.Dog:
                if (aICharacterVehicle is AIVehicleDog)
                {
                    ((AIVehicleDog)aICharacterVehicle).Patrol(aICharacterVehicle._VisionSensor.AlliedView.transform);
                }
                break;
            case TypeUnit.Wolf:
                if (aICharacterVehicle is AIVehicleWolf)
                {
                    ((AIVehicleWolf)aICharacterVehicle).Patrol(aICharacterVehicle._VisionSensor.AlliedView.transform);
                }
                break;
            case TypeUnit.Sheep:
                if (aICharacterVehicle is AIVehicleSheep)
                {
                    ((AIVehicleWolf)aICharacterVehicle).Patrol(aICharacterVehicle._VisionSensor.AlliedView.transform);
                }
                break;
            default:
                break;
        }

    }
}
