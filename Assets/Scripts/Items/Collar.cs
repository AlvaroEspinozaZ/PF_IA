using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collar : Item
{
    public int armatureAmount = 50; // Cantidad de salud que restaura el ítem

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dog")) // Verificar si el objeto que ha colisionado es el jugador
        {
            HealthDog dogHealth = other.GetComponent<HealthDog>(); // Obtener el componente de salud del jugador
            if (dogHealth != null)
            {
                dogHealth.armature = armatureAmount; // Llamar a la función para aumentar la salud del jugador
                Destroy(gameObject); // Destruir el objeto de ítem después de ser recogido
            }
        }
    }
}
