using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ObjectUI : MonoBehaviour
{
    [SerializeField] private Image myImage;
    [SerializeField] private int myCount;
    [SerializeField] private GameObject myObject;
    [SerializeField] private Button myButton;
    [SerializeField] private ObjectEattable objectEattable;
    [SerializeField] private TMP_Text myCountText;
    public Human Human;

    private bool firstStatus = false;
    private bool spawnControl = false;
    private float spawnRate = 0.1f;
    private float nextSpawn = 0;

    public int MyCount
    {
        get
        {
            return myCount;
        }
        set 
        {
            if (MyCount==value)
            {
                return;
            }
            myCount = value;
        }
    }
    public ObjectType myType;
    void Start()
    {
        AdjustComponenets();
        //myButton.onClick.AddListener(SpawnSelf);
        
        AdjustCount();
        Human = GameManager.Instance.CurrentLevel.TargetHuman;
    }

    private void OnDisable()
    {
        //myButton.onClick.RemoveListener(SpawnSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnSelf()
    {
        if ((MyCount>0||firstStatus==false) && Time.time > nextSpawn&&spawnControl==false)
        {
            nextSpawn = Time.time + spawnRate;
            GameManager.Instance.ObjectSpawner.ObjectUISpawn(objectEattable);
            MyCount--;
            TextUpdate();
            firstStatus = true;
            Debug.Log("Bastım");
        }

    }

    private void AdjustComponenets() 
    {
        myButton = GetComponent<Button>();
    }

    private void AdjustCount()
    {
        var currentLevel = GameManager.Instance.CurrentLevel;
        if (myType == currentLevel.ObjectUIs[0].myType)
        {
            myCountText.text = currentLevel.Object1Count.ToString();
            myCount = currentLevel.Object1Count;
        }
        else if (myType == currentLevel.ObjectUIs[1].myType)
        {
            myCountText.text = currentLevel.Object2Count.ToString();
            myCount = currentLevel.Object2Count;
        }
        else
        {
            myCountText.text = currentLevel.Object3Count.ToString();
            myCount = currentLevel.Object3Count;
        }

    }

    public void SpawnBoolTrue()
    {
        spawnControl = true;
    }
    public void SpawnBoolFalse()
    {
        spawnControl = false;
        GameManager.Instance.WinControl();
        GameManager.Instance.FailControl();
    }

    public void TextUpdate()
    {
        myCountText.text = MyCount.ToString();
    }

    public void DenemeButton()
    {
        Debug.Log("Tutuyorum");
    }

    public void HumanMouthOpen()
    {
        Human.MouthOpen();
    }

    public void HumanMouthClose()
    {
        Human.MouthClose();
    }
}
