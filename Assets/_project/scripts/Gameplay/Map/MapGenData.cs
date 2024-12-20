using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MapGenData", menuName = "Data/MapGen Data", order = 1)]
public class MapGenData : ScriptableObject
{
    [Range(1, 10)] [SerializeField] private int _mapSpeed = 1;
    [Space]
    [Range(2, 10)] [SerializeField] private int _visiblePartsNum = 1;
    [Space]
    [SerializeField] private List<GameObject> _mapParts;

    public int MapSpeed => _mapSpeed;
    public int VisiblePartsNum => _visiblePartsNum;
    public List<GameObject> MapParts => _mapParts;

    private void OnValidate()
    {
        if(_visiblePartsNum > _mapParts.Count - 1) 
        {
            _visiblePartsNum = _mapParts.Count - 1;
        }
    }
}
