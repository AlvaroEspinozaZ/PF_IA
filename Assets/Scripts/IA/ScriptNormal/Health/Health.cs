using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeUnit { Dog, Wolf, Sheep, Resource }
public class Health : MonoBehaviour
{

    public float health = 0;
    public float armature = 0;
    public float armatureMax = 50;
    public float healthMax = 100;
    private float tiempoUltimoAtaque;

    public TypeUnit _TypeUnit;
    public TypeUnit[] typeAgentAllies;

    public Transform AimOffset;

    public Slider healthBar;
    public Slider ArmatureBar;
    public bool IfCanView = true;
    public bool IsDead { get => health + armature <= 0; }
    public virtual void LoadComponent()
    {
        health = healthMax;
    }
    public virtual void UpdabeHEalthBar()
    {
        healthBar.value = (health / healthMax);
    }
    public virtual void UpdateArmatureBar()
    {
        ArmatureBar.value = armature / armatureMax;
        if (ArmatureBar.value <= 0)
        {
            ArmatureBar.gameObject.SetActive(false);
        }
        else
        {
            ArmatureBar.gameObject.SetActive(true);
        }
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
    public virtual void Atacar(float timeToAttack,float damage,Health enemy)
    {
        
        if ((Time.time - tiempoUltimoAtaque) % (timeToAttack + 1) >= timeToAttack)
        {
            if (enemy.armature>= 0)
            {
                enemy.armature -= damage;
                UpdateArmatureBar();
            }           
            else if(enemy.armature <= 0)
            {
                enemy.armature = 0;
            }
            if (enemy.armature <= 0)
            {
                enemy.health -= damage;
                UpdabeHEalthBar();
            }
            Debug.Log(damage + " ---" + enemy);

            tiempoUltimoAtaque = Time.time;
        }
    }
   
}
