using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameCharacterManagement;

public class Feed_n : MonoBehaviour
{
    private ControlUI controlUI;
    private Plataberu myChara = CharacterData._Plataberu;
    private int upLevel;

    [SerializeField]
    private Button feedBotton;
    [SerializeField]
    private Button[] feedBottons;

    [SerializeField]
    private GameObject lvUpUI;
    [SerializeField]
    private GameObject charImg;

    private GameObject lvUpUIobj;
    private int count = 0;
    public int cost = 10;

    private void Start()
    {
        controlUI = FindObjectOfType<ControlUI>();
    }

    private void Update()
    {
        if (upLevel == 0)
        {
            if (CharacterData._PlasticNum < cost)
            {
                Debug.Log(myChara.DebugString());
                feedBotton.interactable = false;
                foreach (var feed in feedBottons)
                {
                    feed.interactable = false;
                }
            }
            else
            {
                feedBotton.interactable = true;
                foreach (var feed in feedBottons)
                {
                    feed.interactable = true;
                }
            }
        }
        else if(count < 80)
        {
            if (count == 0)
            {
                lvUpUIobj = controlUI.SetUI(lvUpUI);
                feedBotton.interactable = false;
                foreach (var feed in feedBottons)
                {
                    feed.interactable = false;
                }
                Debug.Log(myChara.DebugString());
            }
            count++;
        }
        else
        {
            Destroy(lvUpUIobj);
            count = 0;
            upLevel = 0;
        }
    }

    public void Feed()
    {

        charImg.GetComponent<CharacterManager_n>().CharacterAnimation = 3;
        CharacterData._PlasticNum -= cost;
        myChara.AddGrp(cost);
        upLevel = myChara.LevelUp();
    }

    public void Feed(int num)
    {
        charImg.GetComponent<CharacterManager_n>().CharacterAnimation = 3;
        CharacterData._PlasticNum -= cost;

        Status pla = Status.Zero;
        if (num == 0)
        {
            CharacterData._RedPlastic -= cost;
            pla.ATK += cost;
        }
        else if (num == 1)
        {
            CharacterData._GreenPlastic -= cost;
            pla.HP += cost;
        }
        else
        {
            CharacterData._BluePlastic -= cost;
            pla.DEF += cost;
        }

        myChara.GetPlastic(pla);
        upLevel = myChara.LevelUp();
    }
}
