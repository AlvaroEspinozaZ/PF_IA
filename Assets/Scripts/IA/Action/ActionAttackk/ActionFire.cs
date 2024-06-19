using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("IA SC/Node Attack")]
public class ActionFire : ActionNodeActions
{
    private float tiempoUltimoAtaque;
    public float intervaloAtaque = 1.5f;
    public int damage;
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
               
                if (((VisionSensorAttack)aICharacterAction._VisionSensor).AttackVision.InSight)
                {
                    aICharacterAction._VisionSensor.EnemyView.Atacar(intervaloAtaque, CalcularDanioDifuso(aICharacterAction._VisionSensor.listAlliedView.Count),  aICharacterAction._VisionSensor.EnemyView);
                    aICharacterAction._VisionSensor.EnemyView.Death();
                }
                break;
            case TypeUnit.Wolf:
                if (((VisionSensorAttack)aICharacterAction._VisionSensor).AttackVision.InSight)
                {
                    aICharacterAction._VisionSensor.EnemyView.Atacar(intervaloAtaque, CalcularDanioDifuso(aICharacterAction._VisionSensor.listAlliedView.Count), aICharacterAction._VisionSensor.EnemyView);
                    aICharacterAction._VisionSensor.EnemyView.Death();
                }
                break;
            //case TypeUnit.Sheep:
            //    //Cambiar por comida del la oveja
            //    if (aICharacterAction._VisionSensor.ResourceView)
            //    {
            //        Atacar(intervaloAtaque, aICharacterAction._VisionSensor.ResourceView);
            //        aICharacterAction._VisionSensor.ResourceView.Death();
            //    }
            //    break;
            default:
                break;
        }
    }
    // Funci�n para calcular el da�o difuso en funci�n de la cantidad de aliados
    float CalcularDanioDifuso(int cantidadAliados)
    {
        // Calculamos las membres�as
        float membershipPocos = CalcularMembresiaPocos(cantidadAliados);
        float membershipModerados = CalcularMembresiaModerados(cantidadAliados);
        float membershipMuchos = CalcularMembresiaMuchos(cantidadAliados);

        // Definimos los valores base de da�o
        float minDamage = 5.0f; // Da�o m�nimo cuando hay "pocos" aliados
        float maxDamage = 15.0f; // Da�o m�ximo cuando hay "muchos" aliados

        // Interpolaci�n difusa para determinar el da�o
        float damage = membershipPocos * minDamage + membershipModerados * (maxDamage - minDamage) + membershipMuchos * maxDamage;

        // Aseguramos que el da�o m�nimo sea 5 cuando no hay aliados
        damage = Mathf.Max(damage, 5.0f);

        return damage;
    }

    float CalcularMembresiaPocos(int cantidadAliados)
    {
        int thresholdPocos = 1; // Umbral para considerar "pocos" aliados
        float membership = Mathf.Clamp01(1.0f - Mathf.Abs(cantidadAliados - thresholdPocos) / thresholdPocos);
        return Mathf.Max(membership, cantidadAliados == 0 ? 1.0f : 0.0f); // Si no hay aliados, asegura que el m�nimo sea 5
    }

    float CalcularMembresiaModerados(int cantidadAliados)
    {
        int thresholdPocos = 2; // Umbral para considerar "pocos" aliados
        int thresholdModerados = 3; // Umbral para considerar "moderados" aliados
        float membership = Mathf.Clamp01(Mathf.Max(0.0f, (cantidadAliados - thresholdPocos) / (thresholdModerados - thresholdPocos)));
        return Mathf.Max(membership, cantidadAliados == 0 ? 0.0f : 0.0f); // Si no hay aliados, asegura que el m�nimo sea 5
    }

    float CalcularMembresiaMuchos(int cantidadAliados)
    {
        int thresholdModerados = 3; // Umbral para considerar "moderados" aliados
        float membership = Mathf.Clamp01(Mathf.Max(0.0f, (cantidadAliados - thresholdModerados) / thresholdModerados));
        return Mathf.Max(membership, cantidadAliados == 0 ? 0.0f : 0.0f); // Si no hay aliados, asegura que el m�nimo sea 5
    }





}
