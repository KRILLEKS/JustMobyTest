using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using StaticData.Enums;
using UnityEngine;

namespace StaticData.ScriptableObjects
{
   [CreateAssetMenu(fileName = "EnumTextureMatchingData", menuName = "ScriptableObject/EnumTextureMatchingData")]
   public class EnumTextureMatchingData : SerializedScriptableObject
   {
      [SerializeField] public Dictionary<ResourceTypes, Texture2D> ResourcesTextures =
         Enum.GetValues(typeof (ResourceTypes))
             .Cast<ResourceTypes>()
             .ToDictionary(x => x, x => (Texture2D) null);
      [SerializeField] public Dictionary<Icons, Texture2D> IconsTextures =
         Enum.GetValues(typeof (Icons))
             .Cast<Icons>()
             .ToDictionary(x => x, x => (Texture2D) null);
   }
}