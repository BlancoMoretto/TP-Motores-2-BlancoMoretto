using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class DecalPainter : MonoBehaviour
{
    public Vector3 position;
    public GameObject sprite;
    public Quaternion hitQ = new Quaternion();
    public bool random;
    public int angle;
    public float alpha;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
     //cargamos el onjeto que se encuentra en la carpeta decal(que esta dentro de la carpeta resourses) con el nombre eee
        sprite = (GameObject)Resources.Load("Decal/brush");

       
    }
    public void GetRandomValue()
    {
        angle = Random.Range(0, 360);
    }

    
  
}
