using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPbarSC : MonoBehaviour
{
    public Slider BossHp;
    float DamageVariable;

    // Start is called before the first frame update
    void Start()
    {
        BossHp = GetComponent<Slider>();
        BossHp.value = 0;
        BossDetected();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BossHp.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
            transform.Find("Fill Area").gameObject.SetActive(true);
        //보스 hp가 0이 되면 완전히 게이지 삭제
    }

    void BossDetected()
    {
        while (BossHp.value < 1)
        {
            Invoke("BossHp.value + 0.1", 10f);
        }
    }



}
