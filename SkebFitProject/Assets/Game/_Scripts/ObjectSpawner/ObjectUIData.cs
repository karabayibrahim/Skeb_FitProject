using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectUIData", menuName = "ScriptableObjects/ObjectUIData", order = 1)]
public class ObjectUIData : ScriptableObject
{
    public List<ObjectUI> ObjectsUI = new List<ObjectUI>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
