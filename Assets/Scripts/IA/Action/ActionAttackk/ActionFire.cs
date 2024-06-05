using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("IA SC/Node Attack")]
public class ActionFire : ActionNodeActions
{
    private float tiempoUltimoAtaque;
    public float intervaloAtaque = 1.5f;
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (aICharacterAction.Health.IsDead)
            return TaskStatus.Failure;

        SwitchFirePlay();

        return TaskStatus.Success;
    }
    void SwitchFirePlay()
    {
        switch (Unit)
        {
            case TypeUnit.Dog:
                if (aICharacterAction._VisionSensor.EnemyView)
                {
                    Atacar(intervaloAtaque, aICharacterAction._VisionSensor.EnemyView);
                    aICharacterAction._VisionSensor.EnemyView.Death();
                }
                break;
            case TypeUnit.Wolf:
                if (aICharacterAction._VisionSensor.EnemyView)
                {
                    Atacar(intervaloAtaque, aICharacterAction._VisionSensor.EnemyView);
                    aICharacterAction._VisionSensor.EnemyView.Death();
                }
                break;
            case TypeUnit.Sheep:
                //Cambiar por comida del la oveja
                if (aICharacterAction._VisionSensor.ResourceView)
                {
                    Atacar(intervaloAtaque, aICharacterAction._VisionSensor.ResourceView);
                    aICharacterAction._VisionSensor.ResourceView.Death();
                }
                break;
            default:
                break;
        }
    }
    void Atacar(float timeToAttack,Health enemy)
    {
        if ((Time.time - tiempoUltimoAtaque)% (timeToAttack+1) >= timeToAttack) 
        { 
            enemy.health -= 10;
            tiempoUltimoAtaque = Time.time;
        }
    }
   

}
