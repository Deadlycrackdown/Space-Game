using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Player : MonoBehaviour
{

	public GameObject laser;//Эта переменная будет связана с префабом  laser
	public GameObject explosionplayer;//Эта переменная будет связана с префабом explosionplayer
	public float moveSpeed = 10;

	float x, y, z, x1, y1;
	bool trigtime = false;
	public float speedreset = 0.25f;//период перезарядки орудия в миллисекундах
	float timer;
	Vector2 startpos;
	Vector2 startcar;
	//объекты laser...sphere3x являются оружием а ниже булевы переменные их соответствующие активаторы 
	public bool gun1 = true;//По умолчанию активировано 1 оружие(laser), оно является базовым и имеет неограниченный боезапас, в отличие от других видов(laser3x...) 


	void Start()
	{
		timer = speedreset;
		y = laser.transform.position.y;
		z = laser.transform.position.z;
	}

	public void Update()
	{
		if (timer < 0)
		{
			timer = speedreset;
			trigtime = false;
		}


		if (Input.GetMouseButton(0))//Отслеживание нажатия на экран 
		{

			//гладкое перемещение
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
			//transform.position = new Vector2(transform.position.x, transform.position.y + 1f);//корректировка координат игрока(необязательно)
			//
			if (timer == speedreset)//проверка истечения времени(время перезарядки) 
			{
				if (gun1 == true)//проверка базового орудия 
				{
					Instantiate(laser, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);//Генерация выстрелов из префаба laser в месте текущей позиции игрока(с некоторыми поправками)
					trigtime = true;
				}
			}
			if (trigtime == true)
			{
				timer = timer - Time.deltaTime;//Отсчет времени для перезарядки
			}
		}
	}
}