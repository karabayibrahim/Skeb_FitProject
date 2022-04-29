using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObjectEattable : MonoBehaviour
{
    [SerializeField] private ObjectType objectType;
    public bool collisionBool = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Obstackle"|| collision.gameObject.tag == "Eatable")
        {
            if (!collisionBool)
            {
                gameObject.transform.DOScale(new Vector3(gameObject.transform.localScale.x + 0.2f, gameObject.transform.localScale.y + 0.2f, gameObject.transform.localScale.z + 0.2f), 0.1f).SetLoops(2, LoopType.Yoyo);
                GameManager.Instance.CurrentLevel.TargetHuman.Swelling();
            }
            collisionBool = true;
        }
        
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag=="Mouth")
    //    {
    //        GameManager.Instance.CurrentLevel.TargetHuman.MouthStatusOpen();
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Mouth")
    //    {
    //        GameManager.Instance.CurrentLevel.TargetHuman.MouthStatusClose();
    //    }
    //}
}
