using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarSC : MonoBehaviour
{
    public Slider Hp;
    float DamageVariable;

    // Start is called before the first frame update
    void Start()
    {
        Hp = GetComponent<Slider>();
        Hp.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
            transform.Find("Fill Area").gameObject.SetActive(true);
        //hp가 0 이 되면 완전히 게이지 삭제
    }
}
