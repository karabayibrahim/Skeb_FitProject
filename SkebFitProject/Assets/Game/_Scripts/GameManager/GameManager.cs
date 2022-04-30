using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoSingleton<GameManager>
{
    public ObjectSpawner ObjectSpawner;
    public ObjectUIData ObjectUIData;
    public UIManager UIManager;
    public Border Border;
    //public ObjectEatableData ObjectEatableData;
    public Transform SpawnPoint;
    public Level CurrentLevel;
    public GameObject DestroyPar;
    public GameObject WinPar;
    public static Action WinEvent;
    public static Action FailEvent;
    public List<ObjectEattable> ObjectEattables = new List<ObjectEattable>();
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
                    var par = Instantiate(DestroyPar, hit.collider.gameObject.transform.position,Quaternion.identity);
                    Destroy(hit.transform.gameObject);
                    Destroy(par, 0.5f);
                }
            }
        }
    }

    public void WinControl()
    {
        if (CurrentLevel.ObjectUIs[0].MyCount<=0&& CurrentLevel.ObjectUIs[1].MyCount <=0&& CurrentLevel.ObjectUIs[2].MyCount <=0)
        {
            //foreach (var item in ObjectEattables)
            //{
            //    var newPar = Instantiate(WinPar, item.transform.position, Quaternion.identity);
            //    Destroy(newPar, 0.5f);
            //    Destroy(item.gameObject);
            //}
            WinEvent?.Invoke();
        }
    }

    public void FailControl()
    {
        if (CurrentLevel.ObjectUIs[0].MyCount <= 0 && CurrentLevel.ObjectUIs[1].MyCount <= 0 && CurrentLevel.ObjectUIs[2].MyCount <= 0)
        {
            if (Border.WinControl)
            {
                FailEvent?.Invoke();
            }
        }

    }
}
