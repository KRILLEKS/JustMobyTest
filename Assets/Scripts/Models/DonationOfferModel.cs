using System;
using System.Collections;
using System.Collections.Generic;
using StaticData.Enums;
using StaticData.ScriptableObjects;
using UnityEngine;

public class DonationOfferModel
{
   public DonationOfferView DonationOfferView;
   
   public string OfferName;
   public string Description;
   public Icons Icon;
   public List<ValueTuple<ResourceTypes, int>> Items = new List<(ResourceTypes, int)>();
   public float Price;
   public bool IsDiscounted;
   public float DiscountPercentage;

   public DonationOfferModel(DonationOfferView donationOfferView)
   {
      DonationOfferView = donationOfferView;
   }

   // Why we pass there offerData? Because with my approach the only ways how we can get model data:
   // 1) From scriptable object that contains model data
   // 2) From save object (we don't have saves and we always can add second ctor if needed)
   public void SetModelData(OfferData offerData)
   {
      OfferName = offerData.OfferName;
      Description = offerData.Description;
      Icon = offerData.Icon;
      Items = offerData.Items;
      Price = offerData.Price;
      IsDiscounted = offerData.IsDiscounted;
      DiscountPercentage = offerData.DiscountPercentage;
      
      DonationOfferView.SetUI(OfferName, Description, Icon, Items, Price, IsDiscounted, DiscountPercentage);
   }
}
