using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmAnimals : MonoBehaviour
{
    [SerializeField] List<GameObject> animals;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnItems()
    {
        //// Verificar si la cantidad de ítems a instanciar es mayor que la cantidad de puntos de spawn disponibles
        //int itemsToSpawn = Mathf.Min(quantity, spawnPoints.Count);

        //for (int i = 0; i < itemsToSpawn; i++)
        //{
        //    // Seleccionar un ítem aleatorio de la lista de ítems
        //    Item item = items[Random.Range(0, items.Count)];

        //    // Seleccionar un punto de spawn aleatorio que no esté ocupado por otro ítem
        //    Transform spawnPoint = GetRandomSpawnPoint();

        //    if (spawnPoint != null)
        //    {
        //        // Instanciar el ítem en el punto de spawn seleccionado
        //        Instantiate(item, spawnPoint.position, Quaternion.identity);
        //    }
        //    else
        //    {
        //        // Si no hay puntos de spawn disponibles, salir del bucle
        //        break;
        //    }
        //}
    }

}
