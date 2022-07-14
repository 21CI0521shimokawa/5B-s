using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI_HP : MonoBehaviour
{
    [SerializeField]
    List<Image> HeartImageList;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var hp in HeartImageList)
        {
            hp.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //後でソースコード書き直す
        int HP = 3;// r.Instance.GetHP();
        for(int i = 0; i < HP; i++)
        {
            HeartImageList[i].color = Color.white;
        }
        for (int i = HP; i < 7; i++)
        {
            HeartImageList[i].color = new Color(1,1,1,0);
        }
    }
}
