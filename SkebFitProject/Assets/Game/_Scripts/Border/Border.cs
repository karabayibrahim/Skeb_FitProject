using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public bool WinControl = false;
    void Start()
    {
        GameManager.Instance.Border = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ObjectEattable>().collisionBool&&other.GetComponent<ObjectEattable>()!=null)
        {
            WinControl = true;
        }
    }
}
