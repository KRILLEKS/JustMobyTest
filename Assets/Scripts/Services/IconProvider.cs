using System;
using StaticData.Constants;
using StaticData.Enums;
using StaticData.ScriptableObjects;
using UnityEngine;

namespace Services
{
   public class IconProvider : MonoBehaviour
   {
      private EnumTextureMatchingData _enumTextureMatchingData;

      public IconProvider()
      {
         _enumTextureMatchingData = Resources.Load<EnumTextureMatchingData>(ResourcePaths.EnumTextureMatchingDataPath);
      }
      
      public Texture2D GetResourceTexture(ResourceTypes resourceType)
      {
         return _enumTextureMatchingData.ResourcesTextures[resourceType];
      }
      
      public Texture2D GetIconTexture(Icons icon)
      {
         return _enumTextureMatchingData.IconsTextures[icon];
      }
   }
}