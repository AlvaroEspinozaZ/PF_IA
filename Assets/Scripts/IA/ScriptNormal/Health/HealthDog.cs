using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDog : Health
{
    private void Start()
    {
        this.LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
    }
    public override void Death()
    {
        base.Death();
    }
    public override void Atacar(float timeToAttack, Health enemy)
    {
        base.Atacar(timeToAttack,  enemy);
    }
}

