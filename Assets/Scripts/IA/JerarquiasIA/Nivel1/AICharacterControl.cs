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
    protected Health health;

    public Health Health { get => health; }


    public SoundCharacter SoundCharacterIA;

    public virtual void LoadComponent()
    {
        character = GetComponent<ThirdPersonCharacterAnimatorBase>();
        _AIEye = GetComponent<AIEyeBase>();
        health = GetComponent<Health>();
        SoundCharacterIA = GetComponent<SoundCharacter>();
    }
}
