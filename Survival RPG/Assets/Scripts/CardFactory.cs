using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public static class CardFactory
{
    private static Dictionary<string, Card> cardsByName;
    private static bool IsInitialized => cardsByName != null;

    private static void InitializeFactory(){
        if(IsInitialized) { return; }

        // var cardTypes = Assembly.GetAssembly(typeof(Card)).GetTypes();
        var cardTypes = GetAllInstances<Card>();
        // dictionary for finding these by name later
        cardsByName = new Dictionary<string, Card>();

        // get the names and put them into the dictionary
        foreach( var card in cardTypes ){
            cardsByName.Add(card.cardName, card);
            Debug.Log(card.cardName);
        }
    }

    public static Card GetCard(string cardName){
        InitializeFactory();

        if(cardsByName.ContainsKey(cardName)){
            // Card type = cardsByName[cardName];
            var card = ScriptableObject.Instantiate(cardsByName[cardName]);
            return card;
        }

        return null;
    }

    internal static IEnumerable<string> GetCardNames2(){
        UnityEngine.Debug.Log("TEST");
        InitializeFactory();
        return cardsByName.Keys;
    }

    public static T[] GetAllInstances<T>() where T : ScriptableObject
     {
         string[] guids = AssetDatabase.FindAssets("t:"+ typeof(T).Name);  //FindAssets uses tags check documentation for more info
         T[] a = new T[guids.Length];
         for(int i =0;i<guids.Length;i++)         //probably could get optimized 
         {
             string path = AssetDatabase.GUIDToAssetPath(guids[i]);
             a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
         }
 
         return a;
 
     }
}
