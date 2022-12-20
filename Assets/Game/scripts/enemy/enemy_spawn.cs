using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
    public GameObject enemyShip;
    float x, y, timer;
    public float timerSpawn = 1f;
    bool trigtime = false;
    public int score;
    public float data;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timer = timerSpawn;
        //StreamReader scoredata = new StreamReader(Application.persistentDataPath + "/score1.gd");
        //data = float.Parse(scoredata.ReadLine());
        //scoredata.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer == timerSpawn)//���� ����������� ����� ��� ������� ��������� ��������� ��:
        {
            x = Random.Range(-3f, 3f);//1)�������� ��������� ���������� � ������� �������� �� ������������� ���������.
            Instantiate(enemyShip, new Vector3(x, 5.5f, -2.17f), transform.rotation);//2)���������  �� �������. x ���������� �������� �� ���������� ���� ���������.
            trigtime = true;//3)���������� ������������� ��� ������� �������. ����� ��� ��������� � ������� ������� ���������� � timerrespawn ��������� �� ����� ����������.
        }
        if (trigtime == true)//�������� ������������� 
        {
            timer = timer - Time.deltaTime;//������ ������� ��� ��������� ���������� ���������.
        }
        if (timer < 0)//���� ����� ������� �������� �� �����:
        {
            timer = timerSpawn;//1)����� ������� �� ����� ���������� � timerespawn
            trigtime = false;//2)������������ ������� �������
                             //����� ���������� ������� �������� �� "�� ���������". ��� �� ������ ����� ����� ����������� ��������� ���������� � ������ �������. � ��� �� �����
        }
    }
}