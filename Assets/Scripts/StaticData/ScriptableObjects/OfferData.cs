using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using StaticData.Enums;
using UnityEngine;

namespace StaticData.ScriptableObjects
{
   [CreateAssetMenu(fileName = "OfferData", menuName = "ScriptableObject/OfferData")]
   public class OfferData : SerializedScriptableObject
   {
      [SerializeField] public string OfferName;
      [SerializeField] public string Description;
      [SerializeField] public List<ValueTuple<ResourceTypes, int>> Items = new List<(ResourceTypes, int)>();
   }
}
