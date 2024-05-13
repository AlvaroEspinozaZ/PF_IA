using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeUnit { Dog, Sheep, Wolf, None }
public class Health : MonoBehaviour
{

    public TypeUnit _Unit;
    public int _life;
    public int _maxLife;
    public bool IsDead { get => _life == 0; }
    public Transform AimOffset;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
