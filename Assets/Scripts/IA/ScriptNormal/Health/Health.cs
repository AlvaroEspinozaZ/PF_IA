using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeUnit { Dog, Wolf, Sheep, Resource }
public class Health : MonoBehaviour
{

    public int health = 0;
    public int healthMax = 100;


    public TypeUnit _TypeUnit;
    public TypeUnit[] typeAgentAllies;

    public Transform AimOffset;

    public bool IfCanView = true;
    public bool IsDead { get => health <= 0; }
    public virtual void LoadComponent()
    {
        health = healthMax;
    }
}
