using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TProger.
//Perevalov Ivan.
//ISP-1-19.
//Let the code begin.


public class SpawnFood : MonoBehaviour
{


    //Переменная игрового объекта фрукта
    public GameObject foodPrefab;

    //Переменная для игрового объекта границ
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    // Start is called before the first frame update
    void Start()
    {
        //Генерация еды каждые 4 секунды начиная с третьей
        InvokeRepeating("Spawn", 3, 4);
    }


    //Генерация фрукта
    void Spawn()
    {
        // x позиция относительно левой и правой границы
        int x = (int)Random.Range(borderLeft.position.x,
                                  borderRight.position.x);

        // y позиция относительно верхней и правой границы
        int y = (int)Random.Range(borderBottom.position.y,
                                  borderTop.position.y);

        //Создание фрукта
        Instantiate(foodPrefab,
                    new Vector2(x, y),
                    Quaternion.identity); 
    }


}                      //game over
