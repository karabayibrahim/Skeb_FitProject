using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public ObjectSpawner ObjectSpawner;
    public ObjectUIData ObjectUIData;
    //public ObjectEatableData ObjectEatableData;
    public Transform SpawnPoint;
    public Level CurrentLevel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TouchObject();
    }

    private void TouchObject()
    {
        if (Input.touchCount>0)
        {
            Touch touc = Input.GetTouch(0);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(touc.position),out hit))
            {
                if (hit.collider.tag=="Eatable")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }

}
