using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Judge : MonoBehaviour
{
    //変数の宣言
    public static int score;
    private float timer;
    [SerializeField] private GameObject[] MessageObj;//プレイヤーに判定を伝えるゲームオブジェクト
    [SerializeField] NotesManager notesManager;//スクリプト「notesManager」を入れる変数

    void Start()
    {
        timer = 0;
        score = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.D))//〇キーが押されたとき
        {
            if (notesManager.LaneNum[0] == 0)//押されたボタンはレーンの番号とあっているか？
            {
                Judgement(GetABS(timer - notesManager.NotesTime[0]));
                /*
                本来ノーツをたたく場所と実際にたたいた場所がどれくらいずれているかを求め、
                その絶対値をJudgement関数に送る
                */
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (notesManager.LaneNum[0] == 1)
            {
                Judgement(GetABS(timer - notesManager.NotesTime[0]));
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (notesManager.LaneNum[0] == 2)
            {
                Judgement(GetABS(timer - notesManager.NotesTime[0]));
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (notesManager.LaneNum[0] == 3)
            {
                Judgement(GetABS(timer - notesManager.NotesTime[0]));
            }
        }

        //タイムリストの要素が無い場合は判定しない
        if (notesManager.NotesTime.Count > 0)
        {
            if (timer > notesManager.NotesTime[0] + 0.2f)//本来ノーツをたたくべき時間から0.2秒たっても入力がなかった場合
            {
                message(3);
                deleteData();
                Debug.Log("Miss");
                //ミス
            }
        }
        if (notesManager.NoteType.Count == 0)
        {
            SceneManager.LoadScene("Result");
        }
    }
    void Judgement(float timeLag)
    {
        if (timeLag <= 0.10)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.1秒以下だったら
        {
            Debug.Log("Perfect");
            message(0);
            deleteData();
            score += 10000;
        }
        else
        {
            if (timeLag <= 0.15)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.15秒以下だったら
            {
                Debug.Log("Great");
                message(1);
                deleteData();
                score += 1000;
            }
            else
            {
                if (timeLag <= 0.20)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.2秒以下だったら
                {
                    Debug.Log("Bad");
                    message(2);
                    deleteData();
                    score += 100;
                }
            }
        }
    }
    float GetABS(float num)//引数の絶対値を返す関数
    {
        if (num >= 0)
        {
            return num;
        }
        else
        {
            return -num;
        }
    }
    void deleteData()//すでにたたいたノーツを削除する関数
    {
        notesManager.NotesTime.RemoveAt(0);
        notesManager.LaneNum.RemoveAt(0);
        notesManager.NoteType.RemoveAt(0);
    }

    void message(int judge)//判定を表示する
    {
        Instantiate(MessageObj[judge], new Vector3(notesManager.LaneNum[0] - 1.5f, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
    }
}