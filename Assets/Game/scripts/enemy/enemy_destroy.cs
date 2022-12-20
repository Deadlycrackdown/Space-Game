using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_destroy : MonoBehaviour
{


    public GameObject money;
    bool trigtime = false;
    public float speedreset = 1.5f;//Время перезарядки
    float timer;
    float speedenemy = -0.02f;//Скорость и направление

    public GameObject laserenemy;
    public GameObject boomEffect;
    float x;

    void Start()
    {
        timer = speedreset;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            timer = speedreset;
            trigtime = false;

        }
        if (timer == speedreset)//проверка истечения времени(время перезарядки) 
        {
            Instantiate(laserenemy, new Vector2(transform.position.x, transform.position.y - 0.8f), transform.rotation);//Генерация выстрелов из префаба laser в месте текущей позиции игрока(с некоторыми поправками)
            trigtime = true;
        }
        if (trigtime == true)
        {
            timer = timer - Time.deltaTime;//Отсчет времени для перезарядки
        }
        transform.Translate(new Vector3(0, speedenemy, 0f));

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {

            Destroy(this.gameObject);
            Instantiate(money, new Vector2(transform.position.x, transform.position.y), transform.rotation);

        }
        if (other.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);

        }
    }
}