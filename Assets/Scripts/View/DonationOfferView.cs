using System;
using System.Collections;
using System.Collections.Generic;
using RelatedClasses.DTO.UI;
using Services;
using StaticData.Constants;
using StaticData.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// It not necessary to inherit view from mono behaviour and serialize fields
// Alternative would be ui factory that would initialize view
public class DonationOfferView : MonoBehaviour
{
   [SerializeField] private GameObject donationOfferGO;
   [SerializeField] private TextMeshProUGUI nameTMP;
   [SerializeField] private TextMeshProUGUI descriptionTMP;
   [SerializeField] private RawImage iconRawImage;
   [SerializeField] private List<OfferResourceUI> resourceUIData;
   // It was possible to use rich text instead of 2 TMPs for regular and discounted price
   [SerializeField] private TextMeshProUGUI priceTMP;
   [SerializeField] private TextMeshProUGUI priceWithoutDiscountTMP;
   [SerializeField] private GameObject discountGO;
   [SerializeField] private TextMeshProUGUI discountAmountTMP;

   private IconProvider _iconProvider;

   public void Initialize(IconProvider iconProvider)
   {
      _iconProvider = iconProvider;
   }

   // Why we pass there parameters instead of DonationOfferModel?
   // 1) Because DonationOfferModel can have more data than we need
   // 2) It's unsafe (I shouldn't be able to change model from view)
   public void SetUI(string offerName,
                     string description,
                     Icons icons,
                     List<ValueTuple<ResourceTypes, int>> items,
                     float price,
                     bool isDiscounted,
                     float discountPercentage = -1)
   {
      nameTMP.text = offerName;
      descriptionTMP.text = description;
      iconRawImage.texture = _iconProvider.GetIconTexture(icons);
      SetResources();
      priceTMP.text = Math.Round(isDiscounted ? price * (1 - discountPercentage) : price, UIConstants.PriceRoundDecimalPlaces).ToString() 
                      + UIConstants.CurrencySymbol;
      SetPriceWithoutDiscount();
      SetDiscountInfo();

      void SetResources()
      {
         for (int i = 0; i < resourceUIData.Count; i++)
         {
            if (items.Count > i)
            {
               resourceUIData[i].ResourceIconRawImage.texture = _iconProvider.GetResourceTexture(items[i].Item1);
               resourceUIData[i].ResourceAmountTMP.text = items[i].Item2.ToString();
            }

            resourceUIData[i].ResourceGO.SetActive(items.Count > i);
         }
      }
      void SetPriceWithoutDiscount()
      {
         priceWithoutDiscountTMP.gameObject.SetActive(isDiscounted);
         if (isDiscounted)
            priceWithoutDiscountTMP.text = Math.Round(price, UIConstants.PriceRoundDecimalPlaces).ToString() + UIConstants.CurrencySymbol;
      }
      void SetDiscountInfo()
      {
         discountGO.SetActive(isDiscounted);
         if (isDiscounted)
            discountAmountTMP.text = Mathf.RoundToInt(discountPercentage * 100).ToString();
      }
   }

   public void SetMenuState(bool state)
   {
      donationOfferGO.SetActive(state);
   }
}