using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TapticPlugin;
public class ObjectEattable : MonoBehaviour
{
    [SerializeField] private ObjectType objectType;
    public bool collisionBool = false;
    void Start()
    {
        StartCoroutine(CollisionTry());
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
                if (PlayerPrefs.GetInt("onOrOffVibration") == 1)
                    TapticManager.Impact(ImpactFeedback.Light);
                gameObject.transform.DOScale(new Vector3(gameObject.transform.localScale.x + 0.2f, gameObject.transform.localScale.y + 0.2f, gameObject.transform.localScale.z + 0.2f), 0.1f).SetLoops(2, LoopType.Yoyo);
                GameManager.Instance.CurrentLevel.TargetHuman.Swelling();
            }
            collisionBool = true;
        }
        
    }

    private IEnumerator CollisionTry()
    {
        gameObject.GetComponentInChildren<Collider>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponentInChildren<Collider>().enabled = true;
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
