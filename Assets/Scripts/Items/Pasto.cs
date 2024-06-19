using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasto : Item
{
    public int healthAmount = 50; // Cantidad de salud que restaura el ítem

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Choque con algo");
        if (other.CompareTag("Sheep")) // Verificar si el objeto que ha colisionado es el jugador
        {
            //Debug.Log("Choque con la oveja");
            HealthSheep sheepHealth = other.GetComponent<HealthSheep>(); // Obtener el componente de salud del jugador
            if (sheepHealth != null)
            {
                sheepHealth.RaiseHealth(healthAmount); // Llamar a la función para aumentar la salud del jugador
                Destroy(gameObject); // Destruir el objeto de ítem después de ser recogido
            }
        }
    }
}
