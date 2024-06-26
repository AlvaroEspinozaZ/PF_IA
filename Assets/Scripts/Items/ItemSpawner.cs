using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints; 
    [SerializeField] List<GameObject> items;
    public int quantity;
    public float times=6f;
    private void Start()
    {
        StartCoroutine(SpawnTime());
    }
    private void Update()
    {
        
    }
    private void SpawnItems()
    {
        // Verificar si la cantidad de ítems a instanciar es mayor que la cantidad de puntos de spawn disponibles
        int itemsToSpawn = Mathf.Min(quantity, spawnPoints.Count);

        for (int i = 0; i < itemsToSpawn; i++)
        {
            // Seleccionar un ítem aleatorio de la lista de ítems
            GameObject item = items[Random.Range(0, items.Count)];

            // Seleccionar un punto de spawn aleatorio que no esté ocupado por otro ítem
            Transform spawnPoint = GetRandomSpawnPoint();

            if (spawnPoint != null)
            {
                // Instanciar el ítem en el punto de spawn seleccionado
                Instantiate(item, spawnPoint.position, Quaternion.identity);
            }
            else
            {
                // Si no hay puntos de spawn disponibles, salir del bucle
                break;
            }
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        // Lista para almacenar los puntos de spawn disponibles
        List<Transform> availableSpawnPoints = new List<Transform>();

        // Iterar sobre todos los puntos de spawn
        foreach (Transform spawnPoint in spawnPoints)
        {
            // Verificar si hay algún ítem en este punto de spawn
            Collider[] colliders = Physics.OverlapSphere(spawnPoint.position, 0.1f);
            if (colliders.Length == 0)
            {
                // Si no hay ningún ítem en este punto de spawn, agregarlo a la lista de puntos de spawn disponibles
                availableSpawnPoints.Add(spawnPoint);
            }
        }

        // Si hay puntos de spawn disponibles, seleccionar uno aleatoriamente; de lo contrario, devolver null
        if (availableSpawnPoints.Count > 0)
        {
            Transform chosenSpawnPoint = availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];
            spawnPoints.Remove(chosenSpawnPoint); // Remove chosen spawn point to prevent reuse
            return chosenSpawnPoint;
        }
        else
        {
            return null;
        }
    }

    IEnumerator SpawnTime()
    {
        SpawnItems();
        yield return new WaitForSecondsRealtime(times);
        StartCoroutine(SpawnTime());
    }
}
