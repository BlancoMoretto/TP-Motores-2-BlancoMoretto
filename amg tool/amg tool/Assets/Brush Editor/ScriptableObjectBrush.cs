using UnityEngine;
using UnityEditor;
using System.IO;

public static class ScriptableObjectBrush  {

    public static void CreateAsset<T>(string name2) where T : ScriptableObject
    {
        //Creamos la instancia del asset
        T asset = ScriptableObject.CreateInstance<T>();

        //Creamos la ubicación donde vamos a guardar el asset
        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath("Assets/Brush Editor/Brushes/" + name2 +"."+ typeof(T).ToString() + ".asset");

        //Creamos el asset
        AssetDatabase.CreateAsset(asset, assetPathAndName);

        //Guardamos los assets en disco
        AssetDatabase.SaveAssets();

        //Importa los assets que fueron modificados
        AssetDatabase.Refresh();
       
        //Marcamos como seleccionado el asset que acabamos de crear
        Selection.activeObject = asset;
    }
}
