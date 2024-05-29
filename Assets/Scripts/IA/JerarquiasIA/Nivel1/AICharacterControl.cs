using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;


[RequireComponent(typeof(BehaviorTree))]
public class AICharacterControl : MonoBehaviour
{
    protected ThirdPersonCharacterAnimatorBase character;
    protected AIEyeBase _AIEye;
    protected VisionSensor visionSensor;
    protected Health health;

    public Health Health { get => health; }
    public VisionSensor _VisionSensor { get => visionSensor; }


    public SoundCharacter SoundCharacterIA;

    public virtual void LoadComponent()
    {
        character = GetComponent<ThirdPersonCharacterAnimatorBase>();
        _AIEye = GetComponent<AIEyeBase>();
        visionSensor = GetComponent<VisionSensor>();
        health = GetComponent<Health>();
        SoundCharacterIA = GetComponent<SoundCharacter>();
    }
}
