using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BrushCreator : EditorWindow {


    private Texture2D _focusObject;
    public GameObject brush;
    private Material material;
    public string nameB;
    

    private List<Texture2D> _assets = new List<Texture2D>();
    [MenuItem("Creator / Brushes")] 

    
    static void CreateWindow() // Crea la ventana a mostrar
    {
        ((BrushCreator)GetWindow(typeof(BrushCreator))).Show(); //Esta línea va a obtener la ventana o a crearla. Una vez que haga esto, va a mostrarla.
        
    }
    // Update is called once per frame
    void OnGUI()
    {
        maxSize = new Vector2(300, 500);
        minSize = new Vector2(300, 500);


      
        
    EditorGUILayout.LabelField("Seleccionar un Sprite", EditorStyles.boldLabel);
        if(_focusObject!=null)
        {
            EditorGUILayout.HelpBox("Seleciona una imagen", MessageType.Info);
        }
        _focusObject = (Texture2D)EditorGUILayout.ObjectField("Imagen: ", _focusObject, typeof(Texture2D), false);

        EditorGUILayout.HelpBox("Escribe el nombre de tu pincel", MessageType.Info);
        nameB = EditorGUILayout.TextField("Nombre: ", nameB);



        EditorGUILayout.HelpBox("Seleciona una tamaño de pincel", MessageType.Info);
        
        brush = (GameObject)EditorGUILayout.ObjectField("Tamaño: ", brush, typeof(GameObject), true);

        if(GUILayout.Button("Generar Brush", GUILayout.Height(40)))
        {
            /*material = new Material(sh);
            string name = _focusObject.name;
            material.SetTexture(Shader.PropertyToID("Sprites / Default"),_focusObject);
           Renderer rd = brush.GetComponent<Renderer>();
            if(rd!=null)
            {
                rd.material = material;
                Instantiate(brush);
            }
          */

         
             Renderer rd = brush.GetComponent<Renderer>();
             rd.sharedMaterial.mainTexture = _focusObject;
            
             Instantiate(brush);
            ScriptableObjectBrush.CreateAsset<Brush>(nameB);
         }
     }






 }
