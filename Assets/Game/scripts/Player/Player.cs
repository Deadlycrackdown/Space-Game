using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Player : MonoBehaviour
{

	public GameObject laser;//��� ���������� ����� ������� � ��������  laser
	public GameObject explosionplayer;//��� ���������� ����� ������� � �������� explosionplayer
	public float moveSpeed = 10;

	float x, y, z, x1, y1;
	bool trigtime = false;
	public float speedreset = 0.25f;//������ ����������� ������ � �������������
	float timer;
	Vector2 startpos;
	Vector2 startcar;
	//������� laser...sphere3x �������� ������� � ���� ������ ���������� �� ��������������� ���������� 
	public bool gun1 = true;//�� ��������� ������������ 1 ������(laser), ��� �������� ������� � ����� �������������� ��������, � ������� �� ������ �����(laser3x...) 


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


		if (Input.GetMouseButton(0))//������������ ������� �� ����� 
		{

			//������� �����������
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
			//transform.position = new Vector2(transform.position.x, transform.position.y + 1f);//������������� ��������� ������(�������������)
			//
			if (timer == speedreset)//�������� ��������� �������(����� �����������) 
			{
				if (gun1 == true)//�������� �������� ������ 
				{
					Instantiate(laser, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);//��������� ��������� �� ������� laser � ����� ������� ������� ������(� ���������� ����������)
					trigtime = true;
				}
			}
			if (trigtime == true)
			{
				timer = timer - Time.deltaTime;//������ ������� ��� �����������
			}
		}
	}
}