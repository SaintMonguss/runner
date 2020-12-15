﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseSC : MonoBehaviour
{
    private bool isPause = false;
    private bool lastcheck = false;
    public Button OptionButton;
    public GameObject background; //회색 백그라운드 전체
    public GameObject return_image;
    public GameObject exit_image;
    public GameObject first_arrow1; // 돌아가기 화살표
    public GameObject first_arrow2; // 종료 화살표
    public GameObject second_arrow1; // 종료확인 화살표
    public GameObject second_arrow2;
    public GameObject Exit_Check;
    public GameObject yes_no;
    private int isSelected1 = 0;
    private int isSelected2 = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//일시정지
        {
            Time.timeScale = 0;
            isPause = true;
            background.SetActive(true);
        }

        if (isPause == true && lastcheck == false)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && isSelected1 < 1) // 일시정지 메뉴
            {
                isSelected1 += 1;
                first_arrow1.SetActive(false);
                first_arrow2.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && isSelected1 > 0)
            {
                isSelected1 -= 1;
                first_arrow1.SetActive(true);
                first_arrow2.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Return)) // 엔터 입력시 실행
            {
                if (isSelected1 == 0) // 돌아가기 선택시
                {
                    Time.timeScale = 1;
                    isPause = false;
                    background.SetActive(false);
                }
                else if (isSelected1 == 1) // 마지막 종료 확인 선택시
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
    }
}
