using System;
using UnityEngine;

[Serializable]
public class SpawnObject
{
    //public class SpawnObject : MonoBehaviour
    //{
    public GameObject bullet;

    public float startTimeBtwSpawns;
    public float timeBtwSpawns;
    public float minTimeBtwSpawn;
    public float decrease;
}