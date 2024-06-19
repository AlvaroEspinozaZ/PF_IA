using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeUnit { Dog, Wolf, Sheep, Resource }
public class Health : MonoBehaviour
{

    public int health = 0;
    public int armature = 0;
    public int healthMax = 100;
    private float tiempoUltimoAtaque;

    public TypeUnit _TypeUnit;
    public TypeUnit[] typeAgentAllies;

    public Transform AimOffset;

    public bool IfCanView = true;
    public bool IsDead { get => health+ armature <= 0; }
    public virtual void LoadComponent()
    {
        health = healthMax;
    }
    public virtual void Death()
    {
        if (IsDead)
        {
            //animacion muerte;
            Debug.Log("Creka " +health + armature);
            Destroy(gameObject, 1.2f);
        }
    }
    public virtual void RaiseHealth(int amount)
    {
        if (health < healthMax)
        {
            health += amount;
            if (health > healthMax)
            {
                health = healthMax;
            }
        }
    }
    public virtual void Atacar(float timeToAttack,Health enemy)
    {       
        if ((Time.time - tiempoUltimoAtaque) % (timeToAttack + 1) >= timeToAttack)
        {
            if (enemy.armature>= 0)
            {
                enemy.armature -= 10;
            }           
            else if(enemy.armature <= 0)
            {
                enemy.armature = 0;
            }
            if (enemy.armature <= 0)
            {
                enemy.health -= 10;
            }
            Debug.Log(10 + " ---" + enemy);

            tiempoUltimoAtaque = Time.time;
        }
    }
}
