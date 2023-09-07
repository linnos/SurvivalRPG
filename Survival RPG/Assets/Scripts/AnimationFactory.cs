using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public static class AnimationFactory
{
    private static Dictionary<string, Transform> effects;
    public static string[] effectNames;

    private static bool IsInitialized => effects != null;

    private static void InitializeFactory(){
        if(IsInitialized) { return; }
        Debug.Log(IsInitialized);

        // var cardTypes = Assembly.GetAssembly(typeof(Card)).GetTypes();
        var animations = GetAllInstances<Transform>();
        // dictionary for finding these by name later
        effects = new Dictionary<string, Transform>();
        // get the names and put them into the dictionary
        foreach( var effect in animations ){
            // 
            if(effect != null){
                Debug.Log(effect.name);
                effects.Add(effect.name, effect);
            }
            
        };
    }

    public static void GetAnimation(string animationName, Vector3 target){
        InitializeFactory();

        if(effects.ContainsKey(animationName)){
            UnityEngine.Object.Instantiate(effects[animationName], target, Quaternion.identity);
        }
    }

    public static T[] GetAllInstances<T>() where T : Transform
     {
         string[] guids = AssetDatabase.FindAssets("t:Object", new[] {"Assets/100BestEffectPack/Effects"});  //FindAssets uses tags check documentation for more info
         T[] a = new T[guids.Length];
         for(int i =0;i<guids.Length;i++)         //probably could get optimized 
         {
             string path = AssetDatabase.GUIDToAssetPath(guids[i]);
             a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
         }
 
         return a;
 
     }
}
