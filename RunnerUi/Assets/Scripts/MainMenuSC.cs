using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSC : MonoBehaviour
{
    float time;
    public Image Title;
    public Image GameStart;
    public Image Exit;
    public Image StartArrow;
    public Image ExitArrow;
    int SelectMenu = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 0.4f) //특정 위치에서 원점으로 이동
        {
            Title.transform.position = new Vector3(0, 2f + 180 - 450 * time, 0);
        }
        else if (time < 0.5f) // 튕기고
        {
            Title.transform.position = new Vector3(0, 2f + (time - 0.4f) * 4, 0);
        }
        else if (time < 0.6f) //다시 제자리로
        {
            Title.transform.position = new Vector3(0, 2f + (0.5f - time) * 4, 0);
        }
        else if (time < 0.7f) //튕기고
        {
            Title.transform.position = new Vector3(0, 2f + ((time - 0.6f) * 4) / 2, 0);
        }
        else if (time < 0.8f) //다시 제자리
        {
            Title.transform.position = new Vector3(0, 2f + (0.05f - (time - 0.7f) * 4) / 2, 0);
        }
        else
        {
            Title.rectTransform.position = new Vector3(0, 2, 0);// 이부분이 문제임 뭐가 문제인지 확인요망
            GameStart.gameObject.SetActive(true);
            Exit.gameObject.SetActive(true);
            ActiveOnOff(SelectMenu);
        }

        time += Time.deltaTime;

        //메뉴 선택 관련 함수
        if (Input.GetKeyDown(KeyCode.DownArrow) && SelectMenu < 1)
        {
            SelectMenu += 1;
            ActiveOnOff(SelectMenu);
            //Debug.Log(time);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && SelectMenu > 0)
        {
            SelectMenu -= 1;
            ActiveOnOff(SelectMenu);
        }
        if (Input.GetKeyDown(KeyCode.Return)) // 엔터 입력시 실행
        {
            Selection(SelectMenu);
        }

    }
    public void resetAnim()
    {
        time = 0;
    }

    void ActiveOnOff(int Select) // 메뉴 선택 이미지 가시 비가시
    {
        switch (Select)
        {
            case 0: // 게임시작
                StartArrow.gameObject.SetActive(true);
                ExitArrow.gameObject.SetActive(false);
                break;
            case 1: // 끝내기
                StartArrow.gameObject.SetActive(false);
                ExitArrow.gameObject.SetActive(true);
                break;
        }
    }
    void Selection(int SelectMenu) // 메뉴 선택시 반응
    {
        switch (SelectMenu)
        {
            case 0:
                SceneManager.LoadScene("InGameUI"); //게임씬 넣어주셈
                break;
            case 1:
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;    // 유니티 플레이어에서 끄기
#else   
                Application.Quit();
#endif
                break;

        }
    }
}
