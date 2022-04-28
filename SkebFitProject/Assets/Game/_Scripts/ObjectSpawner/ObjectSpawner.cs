﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObjectUISpawn(ObjectEattable _objectEatable)
    {
        var rndX = Random.Range(-0.05f, 0.05f);
        var spawnPos = new Vector3(GameManager.Instance.SpawnPoint.position.x + rndX, GameManager.Instance.SpawnPoint.position.y, GameManager.Instance.SpawnPoint.position.z);
        Instantiate(_objectEatable,spawnPos,Quaternion.Euler(90f,0,0));
    }
}