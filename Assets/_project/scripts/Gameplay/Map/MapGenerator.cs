using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private MapGenData _mapData;
    [Space]
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _resetPoint;
    [Space]
    [SerializeField] private GameObject _partHolder;
    [Space]
    [SerializeField] private Transform _unusedPartsHolder;

    private List<GameObject> _mapParts = new List<GameObject>();
    private Queue<GameObject> _usedMapParts = new Queue<GameObject>();

    private GameObject[] partHolders;

    private void Awake()
    {
        partHolders = new GameObject[_mapData.VisiblePartsNum];

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
        for (int i = 0; i < _mapData.MapParts.Count; i++) 
        {
            _mapParts.Add(Instantiate(_mapData.MapParts[i], _unusedPartsHolder.transform));
            _mapParts[i].SetActive(false);
        }
    }
    private void CreatePartHolders() 
    {
        for (int i = 0; i < _mapData.VisiblePartsNum; i++) 
        {
            partHolders[i] = (Instantiate(_partHolder, gameObject.transform));
            partHolders[i].transform.localPosition = _spawnPoint.position + new Vector3(0, 0, 20 * i);
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
        int partIndex = Random.Range(0, _mapParts.Count);
        GameObject part = _mapParts[partIndex];
        part.transform.SetParent(partHolders[index].transform);
        part.transform.localPosition = Vector3.zero;
        part.SetActive(true);
        _usedMapParts.Enqueue(part);
        _mapParts.RemoveAt(partIndex);
    }
    private void HideMapPart() 
    {
        GameObject part = _usedMapParts.Dequeue();
        _mapParts.Add(part);
        part.SetActive(false);
        part.transform.SetParent(_unusedPartsHolder.transform);
    }
    private void MoveHolders() 
    {
        for(int i = 0; i < partHolders.Length; i++) 
        {
            partHolders[i].transform.position -= new Vector3(0, 0, _mapData.MapSpeed * Time.fixedDeltaTime);
            if (partHolders[i].transform.position.z <= _resetPoint.position.z)
            {
                partHolders[i].transform.localPosition = _spawnPoint.position + new Vector3(0, 0, 20 * (partHolders.Length - 1));
                HideMapPart();
                ShowMapPart(i);
            }
        }
    }
}
