using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawmAnimals : MonoBehaviour
{
    [SerializeField] List<GameObject> animals;
    public int quantity;
    public float  range;
    [SerializeField] List<Transform> spawnPoints;
    void Start()
    {
        SpawnItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    private void SpawnItems()
    {       

        for (int i = 0; i < animals.Count; i++)
        {
            // Seleccionar un �tem aleatorio de la lista de �tems
            GameObject item = animals[i];

            // Seleccionar un punto de spawn aleatorio que no est� ocupado por otro �tem
            int idSpam = (Random.RandomRange(0, spawnPoints.Count));
            Transform spawnPoint = GetRandomSpawnPoint();

            if (spawnPoint != null)
            {
                // Instanciar el �tem en el punto de spawn seleccionado
                 Instantiate(item, spawnPoint.position, Quaternion.identity);
                for(int j =0; j < quantity; j++)
                {
                    Vector3 aroundPrefab = spawnPoint.position + Random.insideUnitSphere * range;
                    Instantiate(item, aroundPrefab, Quaternion.identity);
                }
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
            // Verificar si hay alg�n �tem en este punto de spawn
            Collider[] colliders = Physics.OverlapSphere(spawnPoint.position, 0.1f);
            if (colliders.Length == 0)
            {
                // Si no hay ning�n �tem en este punto de spawn, agregarlo a la lista de puntos de spawn disponibles
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
}
