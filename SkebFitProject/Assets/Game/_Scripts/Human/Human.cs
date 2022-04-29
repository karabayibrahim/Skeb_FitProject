using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Human : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer karınMeshRender;
    [SerializeField] private SkinnedMeshRenderer gobekMeshRenderer;
    [SerializeField] private SkinnedMeshRenderer gozMeshRenderer;
    [SerializeField] private SkinnedMeshRenderer kasMeshRenderer;
    //private Mesh karınMesh;
    //private Mesh gobekMesh;
    //private Mesh gozMesh;
    //private Mesh kasMesh;
    //[SerializeField] private GameObject ObstackleLeft;
    //[SerializeField] private GameObject ObstackleRight;
    [SerializeField] private GameObject MouthObject;
    [SerializeField] private GameObject IcObj;
    private bool swellingControl = false;
    private Animator anim;
    private float bok;
    private float kas;
    private float tempCount = 20f;
    [SerializeField] private HumanAnimType HumanAnimType;
    //public float karınBlend;
    //public float gobekBlend;
    //public float gozBlen;
    //public float kasBlend;


    void Start()
    {
        AdjustMeshes();
        GameManager.Instance.CurrentLevel.TargetHuman = this;
        anim = GetComponent<Animator>();
        AdjustAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AdjustMeshes() 
    {
        //karınMesh = karınMeshRender.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        //gobekMesh = gobekMeshRenderer.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        //gozMesh = gobekMeshRenderer.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        //kasMesh = kasMeshRenderer.GetComponent<SkinnedMeshRenderer>().sharedMesh;

    }

    public void ChangeBlendCount(MeshType meshType,float blendShapeCount)
    {
        switch (meshType)
        {
            case MeshType.KARIN:
                var currentshape = karınMeshRender.GetBlendShapeWeight(0);
                var currentshape5 = gobekMeshRenderer.GetBlendShapeWeight(0);

                if (currentshape>=100)
                {
                    swellingControl = true;
                }
                float value = currentshape += blendShapeCount + tempCount;
                float value2 = currentshape5 += blendShapeCount + tempCount;
                DOTween.To(() => currentshape, x => currentshape = x,value , 0.2f).SetEase(Ease.OutElastic).OnUpdate(() => karınMeshRender.SetBlendShapeWeight(0, value)).OnComplete(() =>
                  {
                      TempCountComplete(karınMeshRender);
                  });
                DOTween.To(() => currentshape5, x => currentshape5= x, value2, 0.2f).SetEase(Ease.OutElastic).OnUpdate(() => gobekMeshRenderer.SetBlendShapeWeight(0, value2)).OnComplete(() =>
                {
                    TempCountComplete(gobekMeshRenderer);
                });
                //karınMeshRender.SetBlendShapeWeight(0, currentshape);
                break;
            case MeshType.GOBEK:
                var currentshape2 = karınMeshRender.GetBlendShapeWeight(0);
                currentshape2 += blendShapeCount;
                gobekMeshRenderer.SetBlendShapeWeight(0, currentshape2);
                break;
            case MeshType.GOZ:
                var currentshape3 = karınMeshRender.GetBlendShapeWeight(0);
                currentshape3 += blendShapeCount;
                gozMeshRenderer.SetBlendShapeWeight(1, currentshape3);
                break;
            case MeshType.KAS:
                var currentshape4 = karınMeshRender.GetBlendShapeWeight(0);
                currentshape4 += blendShapeCount;
                kasMeshRenderer.SetBlendShapeWeight(0, currentshape4);
                break;
            default:
                break;
        }
    }

    public void Swelling()
    {
        if (!swellingControl)
        {
            ChangeBlendCount(MeshType.KARIN, 10);
            //StartCoroutine(BlendTry());
            bok = gozMeshRenderer.GetBlendShapeWeight(1);
            kas = kasMeshRenderer.GetBlendShapeWeight(1);
            RndAnimation();
            DOTween.To(() => bok, x => bok = x, 100f, 0.2f).OnUpdate(() => gozMeshRenderer.SetBlendShapeWeight(1, bok)).OnComplete(BlendComplete);
            DOTween.To(() => kas, x => kas = x, 100f, 0.2f).OnUpdate(() => gozMeshRenderer.SetBlendShapeWeight(1, kas)).OnComplete(BlendCompleteKas);
            //ObstackleRight.transform.position += new Vector3(0.01f, 0, 0);
            //ObstackleLeft.transform.position -= new Vector3(0.01f, 0, 0);
        }
    }

    //public void MouthStatusOpen()
    //{
    //    IcObj.GetComponent<MeshCollider>().enabled = true;
    //}

    //public void MouthStatusClose()
    //{
    //    IcObj.GetComponent<MeshCollider>().enabled = false;
    //}

    public void MouthOpen()
    {
        Debug.Log("Açtım");
        //var rotX = MouthObject.transform.rotation.eulerAngles.x;
        //DOTween.To(() => rotX, x => rotX = x, 120f, 0.2f).OnUpdate(() =>
        //{
        //    MouthObject.transform.rotation = Quaternion.Euler(rotX, 0, 0);
        //});
        //MouthObject.transform.DOLocalRotate(new Vector3(120f, 0, 0), 0.2f);
        MouthObject.transform.DOLocalMoveY(-0.3f, 0.2f);
    }

    public void MouthClose()
    {
        //var rotX = MouthObject.transform.rotation.eulerAngles.x;
        //DOTween.To(() => rotX, x => rotX = x, 60f, 0.2f).OnUpdate(() =>
        //{
        //    MouthObject.transform.rotation = Quaternion.Euler(rotX, 0, 0);
        //});
        //MouthObject.transform.DOLocalRotate(new Vector3(60f, 0, 0), 0.2f);
        Debug.Log("Kapattım");
        MouthObject.transform.DOLocalMoveY(0.8f, 0.2f);
    }


    private void AdjustAnimation()
    {
        switch (HumanAnimType)
        {
            case HumanAnimType.SITIDLE:
                anim.CrossFade("Sitting Idle",0.01f);
                break;
            case HumanAnimType.KUVET:
                anim.CrossFade("Kuvet", 0.01f);
                break;
            case HumanAnimType.TUTMA:
                anim.CrossFade("Tutunma", 0.01f);
                break;
            default:
                break;
        }
    }

    
    private void BlendComplete()
    {
        float bok = gozMeshRenderer.GetBlendShapeWeight(1);
        DOTween.To(() => bok, x => bok = x, 0, 0.2f).OnUpdate(() => gozMeshRenderer.SetBlendShapeWeight(1, bok));
    }

    private void BlendCompleteKas()
    {
        float bok = gozMeshRenderer.GetBlendShapeWeight(1);
        DOTween.To(() => bok, x => bok = x, 0, 0.2f).OnUpdate(() => gozMeshRenderer.SetBlendShapeWeight(1, bok));
    }

    private void TempCountComplete(SkinnedMeshRenderer skinnedMesh)
    {
        float bok = skinnedMesh.GetBlendShapeWeight(0);
        float value = bok - tempCount;
        DOTween.To(() => bok, x => bok = x, 0, 0.2f).SetEase(Ease.OutElastic).OnUpdate(() => skinnedMesh.SetBlendShapeWeight(0,value));
    }

    private void RndAnimation()
    {
        if (HumanAnimType!=HumanAnimType.TUTMA)
        {
            var rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                anim.CrossFade("Arm", 0.01f);
            }
            else
            {
                anim.CrossFade("ArmJump", 0.01f);
            }
        }
        

    }
}
