using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Runtime.InteropServices;
//TProger.
//Perevalov Ivan.
//ISP-1-19.
//Let the code begin.

public class Snake : MonoBehaviour
{
    
    //Переменная для игрового объекта границ
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    //пользователь врезался?
    bool isDied = false;

    //переменная для отслеживания съеден ли фрукт или нет
    bool ate = false;

    //Переменная игрового объекта "хвост"
    public GameObject tailPrefab;
    

    // Текущее направление движения
    // по умолчанию перемещается вправо
    Vector2 dir = Vector2.right;

    //Отслеживание хвоста
    List<Transform> tail = new List<Transform>();
    
    // Start is called before the first frame update
    void Start()
    {  
         
         
         //Движение змеи 
        InvokeRepeating("Move", 0.1f, 0.1f);
       
    }

    


    void Move()
    {
       

        if (!isDied)
        {
            

            //Сохранить позицию
            Vector2 v = transform.position;

            //Перемещение головы в новое направление
            transform.Translate(dir);

            //Если съели фрукт заполнить пустое пространство 
            if (ate)
            {
                 
                GameObject clonetail = Instantiate(tailPrefab,
                                                      v,
                                                      Quaternion.identity);
                // Загрузить хвост 
                GameObject g = clonetail;

                

                // Слежение за хвостом
                tail.Insert(0, g.transform);
               
                //сбросить значение
                ate = false;

             
               


            }
            else if (tail.Count > 0) // если есть хвост, то

            {
                //Перемещаем последний элемент на место, где была голова
                tail.Last().position = v;

                //Добавить в начало списка и удалить в конце
                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isDied)
        {
            //Движение в новом направлении
            if (Input.GetKey(KeyCode.RightArrow))
                dir = Vector2.right;
            else if (Input.GetKey(KeyCode.DownArrow))
                dir = -Vector2.up;    // '-up' обозначает 'down'
            else if (Input.GetKey(KeyCode.LeftArrow))
                dir = -Vector2.right; // '-right' обозначает 'left'
            else if (Input.GetKey(KeyCode.UpArrow))
                dir = Vector2.up;
        }
        else
        {
            if (Input.GetKey(KeyCode.R))

            {
               
                
                //очистить хвост               
                tail.Clear();   
                                                     
                //вернуть змейку в исходную позцию
                transform.position = new Vector3(0, 0, 0);

                //возродить змею
                isDied = false;
            }
        }
    
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        // Если это еда, то     
        if (coll.name.StartsWith("FoodPrefab"))
        {
             
            
            //то меняем значение
            ate = true;

            // Удаляем фрукт
            Destroy(coll.gameObject);
          
        }
        else
        {
            isDied = true;
            
            
           
        }

     
    }

   

}                   //game over
