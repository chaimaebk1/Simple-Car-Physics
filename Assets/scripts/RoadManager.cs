using UnityEngine;
using System.Collections.Generic;

public class RoadManager : MonoBehaviour
{
    public GameObject roadPrefab; // Prefab de la route
    public GameObject sideRoadPrefab; // Prefab de la "side road"
    public GameObject player; // GameObject représentant le joueur
    public GameObject enemy; // GameObject représentant l'ennemi

    private List<RoadData> roads = new List<RoadData>(); // Liste pour stocker les routes créées
    private float lastRoadEndX = 0f; // Dernière position en X où une route a été créée
    private float roadLength = 19.1f; // Longueur de chaque route
    private float sideRoadPositionY = 1.1f; // Position Y des "side roads"
    private float sideRoadPositionZ = -6.008063f; // Position Z des "side roads"
    private Vector3 sideRoadScale = new Vector3(1f, 2f, 1f); // Scale des "side roads"
    private int numberOfSideRoads = 2; // Nombre de "side roads" à instancier le long de chaque route

    void Start()
    {
        // Créer les deux premières routes manuellement
        CreateRoad();
       
    }

    void Update()
    {
        // Vérifier si le joueur a dépassé la dernière route ou si l'ennemi a dépassé la dernière route
        if (player.transform.position.x > lastRoadEndX - roadLength ||
            enemy.transform.position.x > lastRoadEndX - roadLength)
        {
            CreateRoad();
        }

        // Vérifier si une route est dépassée par une voiture, puis la détruire
        foreach (var roadData in roads.ToArray())
        {
            if (roadData.road.transform.position.x + roadLength < player.transform.position.x &&
                roadData.road.transform.position.x + roadLength < enemy.transform.position.x)
            {
                Destroy(roadData.road);
                Destroy(roadData.sideRoad);
                roads.Remove(roadData);
                break; // Sortir de la boucle foreach après la suppression d'une route
            }
        }
    }

    void CreateRoad()
{
    // Instancier une nouvelle route devant la dernière route
    GameObject newRoad = Instantiate(roadPrefab, new Vector3(lastRoadEndX + roadLength, 0f, 0f), Quaternion.identity);
    lastRoadEndX += roadLength; // Mettre à jour la position X de la dernière route

    float sideRoadSpacing = 6f; // Espacement entre les "side roads"
    float totalSideRoadWidth = (numberOfSideRoads - 1) * sideRoadSpacing; // Largeur totale des "side roads" avec espacement

    // Créer les "side roads" à côté de la nouvelle route
    for (int i = 0; i < numberOfSideRoads; i++)
    {
        float sideRoadPositionX = newRoad.transform.position.x;
        float offset = -totalSideRoadWidth / 1f + i * sideRoadSpacing; // Calculer l'offset en fonction de l'espacement et du nombre de "side roads"
        sideRoadPositionX += offset;
        GameObject newSideRoad = Instantiate(sideRoadPrefab, new Vector3(sideRoadPositionX, sideRoadPositionY, newRoad.transform.position.z + sideRoadPositionZ), Quaternion.identity);
        newSideRoad.transform.localScale = sideRoadScale;

        // Stocker les références de la route et de sa "side road"
        roads.Add(new RoadData(newRoad, newSideRoad));
    }
}


    // Structure de données pour stocker les références d'une route et de sa "side road"
    private struct RoadData
    {
        public GameObject road;
        public GameObject sideRoad;

        public RoadData(GameObject road, GameObject sideRoad)
        {
            this.road = road;
            this.sideRoad = sideRoad;
        }
    }
}
