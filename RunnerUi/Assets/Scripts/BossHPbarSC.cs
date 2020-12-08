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


    // 보스를 마주쳣을때 보스Hp 등장
    public void BossDetected()
    {
        transform.Find("Outline").gameObject.SetActive(true);
        InvokeRepeating("BossHPFillUp", 0.0f, 0.01f);
        Invoke("FinishDetected", 1f);
    }

    void BossHPFillUp()
    {
        BossHp.value += 0.01f;
    }


    private void FinishDetected()
    {
        CancelInvoke("BossHPFillUp");
    }

}
