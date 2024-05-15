using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeUnit { Zombie, Soldier, None }
public class Health : MonoBehaviour
{

<<<<<<< Updated upstream
    public TypeUnit _Unit;
    public int _life;
    public int _maxLife;
    public bool IsDead { get => _life == 0; }
=======
    public int health = 0;
    public int healthMax = 100;


    public TypeUnit _TypeUnit;
    public TypeUnit[] typeAgentAllies;

    public Transform AimOffset;

    public bool IfCanView = true;
>>>>>>> Stashed changes

    public bool IsDead { get => health <= 0; }
    public virtual void LoadComponent()
    {
        health = healthMax;
    }
}
