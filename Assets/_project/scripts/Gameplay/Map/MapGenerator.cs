using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] MapGenData mapData;
    [Space]
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform resetPoint;
    [Space]
    [SerializeField] GameObject partHolder;
    [Space]
    [SerializeField] Transform unusedPartsHolder;

    private List<GameObject> mapParts = new List<GameObject>();
    private Queue<GameObject> usedMapParts = new Queue<GameObject>();

    private GameObject[] partHolders;

    private void Awake()
    {
        partHolders = new GameObject[mapData.VisiblePartsNum];

        SpawnMapParts();
        CreatePartHolders();
        ShowMapParts();
    }
    private void FixedUpdate()
    {
        MoveHolders(); //////////// to Tick
    }

    private void SpawnMapParts() 
    {
        for (int i = 0; i < mapData.MapParts.Count; i++) 
        {
            mapParts.Add(Instantiate(mapData.MapParts[i], unusedPartsHolder.transform));
            mapParts[i].SetActive(false);
        }
    }
    private void CreatePartHolders() 
    {
        for (int i = 0; i < mapData.VisiblePartsNum; i++) 
        {
            partHolders[i] = (Instantiate(partHolder, gameObject.transform));
            partHolders[i].transform.localPosition = spawnPoint.position + new Vector3(0, 0, 20 * i);
        }
    }
    private void ShowMapParts()
    {
        for(int i = 0; i < partHolders.Length; i++) 
        {
            ShowMapPart(i);
        }
    }
    private void ShowMapPart(int index) 
    {
        int partIndex = Random.Range(0, mapParts.Count);
        GameObject part = mapParts[partIndex];
        part.transform.SetParent(partHolders[index].transform);
        part.transform.localPosition = Vector3.zero;
        part.SetActive(true);
        usedMapParts.Enqueue(part);
        mapParts.RemoveAt(partIndex);
    }
    private void HideMapPart() 
    {
        GameObject part = usedMapParts.Dequeue();
        mapParts.Add(part);
        part.SetActive(false);
        part.transform.SetParent(unusedPartsHolder.transform);
    }
    private void MoveHolders() 
    {
        for(int i = 0; i < partHolders.Length; i++) 
        {
            partHolders[i].transform.position -= new Vector3(0, 0, mapData.MapSpeed * Time.fixedDeltaTime);
            if (partHolders[i].transform.position.z <= resetPoint.position.z)
            {
                partHolders[i].transform.localPosition = spawnPoint.position + new Vector3(0, 0, 20 * (partHolders.Length - 1));
                HideMapPart();
                ShowMapPart(i);
            }
        }
    }
}
