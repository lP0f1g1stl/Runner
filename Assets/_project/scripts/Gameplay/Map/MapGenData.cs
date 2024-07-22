using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MapGenData", menuName = "Data/MapGen Data", order = 1)]
public class MapGenData : ScriptableObject
{
    [Range(1, 10)] [SerializeField] int mapSpeed;
    [Space]
    [Range(2, 10)] [SerializeField] int visiblePartsNum;
    [Space]
    [SerializeField] List<GameObject> mapParts;

    public int MapSpeed => mapSpeed;
    public int VisiblePartsNum => visiblePartsNum;
    public List<GameObject> MapParts => mapParts;

    private void OnValidate()
    {
        if(visiblePartsNum > mapParts.Count - 1) 
        {
            visiblePartsNum = mapParts.Count - 1;
        }
    }
}
