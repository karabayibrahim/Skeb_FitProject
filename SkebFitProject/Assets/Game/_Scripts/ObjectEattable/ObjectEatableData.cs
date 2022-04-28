using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectEatableData", menuName = "ScriptableObjects/ObjectEatableData", order = 1)]
public class ObjectEatableData : ScriptableObject
{
    public List<ObjectEattable> ObjectEattables = new List<ObjectEattable>();
}
