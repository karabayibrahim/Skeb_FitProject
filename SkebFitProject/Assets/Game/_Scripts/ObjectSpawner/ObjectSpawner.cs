using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObjectUISpawn(ObjectEattable _objectEatable)
    {
        var rndX = Random.Range(-0.01f, 0.01f);
        var spawnPos = new Vector3(GameManager.Instance.SpawnPoint.position.x + rndX, GameManager.Instance.SpawnPoint.position.y, GameManager.Instance.SpawnPoint.position.z);
        var newObj=Instantiate(_objectEatable,spawnPos,Quaternion.Euler(90f,0,0));
        GameManager.Instance.ObjectEattables.Add(newObj);
    }
}
