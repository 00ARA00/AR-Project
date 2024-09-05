using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnResources : MonoBehaviour
{
    [SerializeField] private GameObject planeMarkerPrefab;
    [SerializeField] private GameObject arena;
    [SerializeField] private GameObject firstCharacter;
    [SerializeField] private GameObject secondCharacter;
    [SerializeField] private List<GameObject> aRObjectPrefabs;

    public List<GameObject> ARObjectPrefabs => aRObjectPrefabs;
    public GameObject FirstCharacter => firstCharacter;
    public GameObject SecondCharacter => secondCharacter;
    public GameObject Arena => arena;
    public GameObject PlaneMarkerPrefab => planeMarkerPrefab;
}
