using System;
using DefaultNamespace.Controllers;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
   
   public class Main : MonoBehaviour
   {
      [SerializeField] private DonationOfferView donationOfferView;
      [Space]
      [SerializeField] private Button openOfferButton;
      [SerializeField] private TMP_InputField TMPInputField;
      [SerializeField] private Button buyOfferButton;

      private IconProvider _iconProvider;
      private DonationOfferModel _donationOfferModel;
      private DonationOfferController _donationOfferController;

      private void Awake()
      {
         _iconProvider = new IconProvider();
         donationOfferView.Initialize(_iconProvider);
         _donationOfferModel = new DonationOfferModel(donationOfferView);
         _donationOfferController = new DonationOfferController(_donationOfferModel, donationOfferView);
      }

      private void Start()
      {
         TMPInputField.onValueChanged.AddListener((x) => _donationOfferController.SetModel(int.Parse(x)));
         openOfferButton.onClick.AddListener(() => _donationOfferController.ShowDonationOffer());
         buyOfferButton.onClick.AddListener(() => _donationOfferController.BuyDonationOffer());
      }
   }
}