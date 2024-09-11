using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnResources : MonoBehaviour
{
    [SerializeField] private GameObject planeMarker;
    [SerializeField] private GameObject arena;
    [SerializeField] private GameObject firstCharacter;
    [SerializeField] private GameObject secondCharacter;
    [SerializeField] private Transform camera;
    [SerializeField] private List<GameObject> heroList = new List<GameObject>();
    [SerializeField] private List<GameObject> enemyList = new List<GameObject>();

    public Transform Camera => camera;
    public List<GameObject> HeroList => heroList;
    public List<GameObject> EnemyList => enemyList;
    public GameObject FirstCharacter => firstCharacter;
    public GameObject SecondCharacter => secondCharacter;
    public GameObject Arena => arena;
    public GameObject PlaneMarker => planeMarker;
}
