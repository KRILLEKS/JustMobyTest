using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RelatedClasses.DTO.UI
{
   [Serializable]
   public class OfferResourceUI
   {
      [SerializeField] public GameObject ResourceGO;
      [SerializeField] public RawImage ResourceIconRawImage;
      [SerializeField] public TextMeshProUGUI ResourceAmountTMP;
   }
}