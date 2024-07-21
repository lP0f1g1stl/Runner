using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapGenData", menuName = "MapGen", order = 1)]
public class MapGenData : ScriptableObject
{
    [Range(0, 2)] [SerializeField] float mapSpeed;
    [Space]
    [Range(1, 10)] [SerializeField] int visiblePartsNum;
    [Space]
    [SerializeField] List<GameObject> mapParts;

    public float MapSpeed => mapSpeed;
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
