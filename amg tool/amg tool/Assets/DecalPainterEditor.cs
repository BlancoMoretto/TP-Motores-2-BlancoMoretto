using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(DecalPainter))]
public class DecalPainterEditor : Editor {

    private DecalPainter _target;
    public Color color;

    private void OnEnable()
    {
        _target = (DecalPainter)target;
        color = new Color();
        
    }
    public override void OnInspectorGUI()
    {
        ShowValues();
        
       
    }

    private void ShowValues()
    {
        EditorGUILayout.LabelField("Mi inspector de Pintar Decals ", EditorStyles.boldLabel);

        _target.random = EditorGUILayout.Toggle("Rotacion aleatoria?", _target.random);

        SetAlpha(_target.sprite);

    }
    void RotateBrush(GameObject target)
    {
        
        target.transform.Rotate(Vector3.forward, _target.angle);
    }
    void SetAlpha(GameObject target)
    {
        
        Renderer rd = target.GetComponent<Renderer>();
        EditorGUILayout.LabelField("Intensidad del Alpha", EditorStyles.boldLabel);
        _target.alpha = EditorGUILayout.Slider(_target.alpha, 0, 1);
        color = rd.sharedMaterial.color;

        color.a = _target.alpha;
        Debug.Log(color.a);
        rd.sharedMaterial.color = color;
    }

    void OnSceneGUI()
    {
        //si se clikea el mouse 
        if(Event.current.type == EventType.MouseDown)
        {
            
            Debug.Log("sas");
            if (SceneView.lastActiveSceneView.camera != null)
            {
                RaycastHit hit;
                Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                if(Physics.Raycast(ray,out hit, 1000))
                {
                    //sacamos la pocicion del raycast contra que choco 
                    _target.hitQ = Quaternion.FromToRotation(Vector3.forward, hit.normal);
                    _target.position = new Vector3(hit.point.x + 0.1f, hit.point.y + 0.1f, hit.point.z + 0.1f);
                    Debug.Log(_target.position);
                    
                    //instanciamos el objeto en la posicion que qeremos mirando para las normales del obj
                    // contra el que choco el rayvast
                   
                    


                    if (_target.random == true)
                    {
                        _target.GetRandomValue();
                        RotateBrush(Instantiate(_target.sprite, hit.point + (hit.normal * 0.001f), Quaternion.LookRotation(hit.normal)));
                    }else
                    {
                        Instantiate(_target.sprite, hit.point + (hit.normal * 0.001f), Quaternion.LookRotation(hit.normal));
                    }
                }
            }
        }
    }
}
