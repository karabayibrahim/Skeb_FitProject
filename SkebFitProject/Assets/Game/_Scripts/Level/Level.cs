using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<ObjectType> SpawnUIObjects = new List<ObjectType>();
    public List<ObjectUI> ObjectUIs = new List<ObjectUI>();
    public Human TargetHuman;
    public int Object1Count;
    public int Object2Count;
    public int Object3Count;

    void Awake()
    {
        SpawnUIObjectMethod();
        GameManager.Instance.CurrentLevel = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnUIObjectMethod()
    {
        foreach (var item in SpawnUIObjects)
        {
            switch (item)
            {
                case ObjectType.BAO:
                    foreach (var item2 in GameManager.Instance.ObjectUIData.ObjectsUI)
                    {


                        if (item2.GetComponent<ObjectUI>().myType == item)
                        {
                            var newobj = Instantiate(item2, GameManager.Instance.ObjectSpawner.transform);
                            ObjectUIs.Add(newobj);
                        }
                    }
                    break;
                case ObjectType.FROZEN:
                    foreach (var item2 in GameManager.Instance.ObjectUIData.ObjectsUI)
                    {


                        if (item2.GetComponent<ObjectUI>().myType == item)
                        {
                            var newobj = Instantiate(item2, GameManager.Instance.ObjectSpawner.transform);
                            ObjectUIs.Add(newobj);
                        }
                    }
                    break;
                case ObjectType.PANCAKE:
                    foreach (var item2 in GameManager.Instance.ObjectUIData.ObjectsUI)
                    {


                        if (item2.GetComponent<ObjectUI>().myType == item)
                        {
                            var newobj = Instantiate(item2, GameManager.Instance.ObjectSpawner.transform);
                            ObjectUIs.Add(newobj);
                        }
                    }
                    break;
                case ObjectType.PIE:
                    foreach (var item2 in GameManager.Instance.ObjectUIData.ObjectsUI)
                    {


                        if (item2.GetComponent<ObjectUI>().myType == item)
                        {
                            var newobj = Instantiate(item2, GameManager.Instance.ObjectSpawner.transform);
                            ObjectUIs.Add(newobj);
                        }
                    }
                    break;
                case ObjectType.SHRIMP:
                    foreach (var item2 in GameManager.Instance.ObjectUIData.ObjectsUI)
                    {


                        if (item2.GetComponent<ObjectUI>().myType == item)
                        {
                            var newobj = Instantiate(item2, GameManager.Instance.ObjectSpawner.transform);
                            ObjectUIs.Add(newobj);
                        }
                    }
                    break;
                case ObjectType.DONUT:
                    foreach (var item2 in GameManager.Instance.ObjectUIData.ObjectsUI)
                    {


                        if (item2.GetComponent<ObjectUI>().myType == item)
                        {
                            var newobj = Instantiate(item2, GameManager.Instance.ObjectSpawner.transform);
                            ObjectUIs.Add(newobj);
                        }
                    }
                    break;
                case ObjectType.SUSHI:
                    foreach (var item2 in GameManager.Instance.ObjectUIData.ObjectsUI)
                    {


                        if (item2.GetComponent<ObjectUI>().myType == item)
                        {
                            var newobj = Instantiate(item2, GameManager.Instance.ObjectSpawner.transform);
                            ObjectUIs.Add(newobj);
                        }
                    }
                    break;
                default:
                    break;
            }
            //switch (item)
            //{
            //    case ObjectType.HAMBURGER:

            //        break;
            //    case ObjectType.PİZZA:
            //        break;
            //    case ObjectType.DONUT:
            //        break;
            //    case ObjectType.SUSHI:
            //        foreach (var item2 in GameManager.Instance.ObjectUIData.ObjectsUI)
            //        {


            //            if (item2.GetComponent<ObjectUI>().myType == item)
            //            {
            //                var newobj = Instantiate(item2, GameManager.Instance.ObjectSpawner.transform);
            //                ObjectUIs.Add(newobj);
            //            }
            //        }
            //        break;
            //    case ObjectType.COOKIE:

            //        foreach (var item2 in GameManager.Instance.ObjectUIData.ObjectsUI)
            //        {

            //            if (item2.GetComponent<ObjectUI>().myType == item)
            //            {
            //                var newobj = Instantiate(item2, GameManager.Instance.ObjectSpawner.transform);
            //                ObjectUIs.Add(newobj);
            //            }
            //        }
            //        break;
            //    default:
            //        break;
            //}
        }
    }

}
