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
        if (timer == timerSpawn)//≈сли установлено врем€ дл€ отсчета генерации метеорита то:
        {
            x = Random.Range(-3f, 3f);//1)¬ыбираем рандомную координату в которой по€витс€ из динамического диапазона.
            Instantiate(enemyShip, new Vector3(x, 5.5f, -2.17f), transform.rotation);//2)√енераци€  из префаба. x выбираетс€ рандомно из указанного выше диапазона.
            trigtime = true;//3)јктивируем переключатель дл€ отсчета времени. ѕосле его активации в течение времени указанного в timerrespawn метеориты не будут по€вл€тьс€.
        }
        if (trigtime == true)//ѕроверка переключател€ 
        {
            timer = timer - Time.deltaTime;//ќтсчет времени дл€ генерации слудующего метеорита.
        }
        if (timer < 0)//≈сли врем€ периода истекает то тогда:
        {
            timer = timerSpawn;//1)—брос времени на число записанное в timerespawn
            trigtime = false;//2)Ѕлокирование отсчета времени
                             //«десь происходит возврат значений на "по умолчанию". ѕри их сбросе снова будет происходить генераци€ метеоритов и отсчет времени. » так по кругу
        }
    }
}