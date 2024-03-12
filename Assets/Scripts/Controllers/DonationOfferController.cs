using System.Collections.Generic;
using StaticData.Constants;
using StaticData.ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace.Controllers
{
   public class DonationOfferController
   {
      private DonationOfferModel _donationOfferModel;
      private DonationOfferView _donationOfferView;
      private Dictionary<int, OfferData> _offerDictionary;

      public DonationOfferController(DonationOfferModel donationOfferModel, DonationOfferView donationOfferView)
      {
         _donationOfferModel = donationOfferModel;
         _donationOfferView = donationOfferView;
         OfferData[] offersData = Resources.LoadAll<OfferData>(ResourcePaths.DonationOfferDataPath);
         FillOfferDictionary();

         void FillOfferDictionary()
         {
            _offerDictionary = new Dictionary<int, OfferData>();
            foreach (var offerData in offersData)
            {
               int itemsAmount = offerData.Items.Count;
               if (_offerDictionary.ContainsKey(offerData.Items.Count))
               {
                  Debug.LogError($"There is already offer with {itemsAmount}. Extra offer name: {offerData.OfferName}");
                  continue;
               }

               _offerDictionary.Add(itemsAmount, offerData);
            }
         }
      }

      public void SetModel(int resourceAmount)
      {
         if (_offerDictionary.ContainsKey(resourceAmount) == false)
         {
            Debug.LogError($"No offer with {resourceAmount}");
            return;
         }
         
         _donationOfferModel.SetModelData(_offerDictionary[resourceAmount]);
      }

      public void ShowDonationOffer()
      {
         _donationOfferView.SetMenuState(true);
      }

      public void BuyDonationOffer()
      {
         _donationOfferView.SetMenuState(false);
         Debug.Log($"Order with {_donationOfferModel.Items.Count} was bought");
      }
   }
}