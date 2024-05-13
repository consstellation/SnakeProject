using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Globalization;
using System.Runtime.InteropServices;
//TProger.
//Perevalov Ivan.
//ISP-1-19.
//Let the code begin.

public class Destroy : MonoBehaviour
{
 
  
     
   //переменная для игрового объекта 
    public GameObject clonedestroy;
    
     
    // Update is called once per frame
    void Update()
    {
            
       //если нажали клавишу R удалить игровые объекты
       if (Input.GetKey(KeyCode.R))
       {
           Destroy(clonedestroy);                     
       }
 

        
    }
}                     //game over
