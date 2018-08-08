﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

// Placing the Purchaser class in the CompleteProject namespace allows it to interact with ScoreManager, 
// one of the existing Survival Shooter scripts.

    // Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
    public class Purchaser : MonoBehaviour, IStoreListener
    {
        private static IStoreController m_StoreController;          // The Unity Purchasing system.
        private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

  
        public static string kProductIDConsumable = "consumable";
        public static string kProductIDNonConsumable = "nonconsumable";
        public static string kProductIDSubscription = "subscription";
        public static string kitbasico = "kitbasico"; //remove anuncios e 10 dinamites
        public static string dinamite50 = "dinamite25";
        public static string armadilha100 = "armadilha50";
       // public static string bau1 = "bau1";


    // Google Play Store-specific product identifier subscription product.
    private static string kProductNameGooglePlaySubscription = "com.unity3d.subscription.original";

        private void Start()
        {
            // If we haven't set up the Unity Purchasing reference
            if (m_StoreController == null)
            {
                // Begin to configure our connection to Purchasing
                InitializePurchasing();
            //Test Git2
            }
        }

        public void InitializePurchasing()
        {
            // If we have already connected to Purchasing ...
            if (IsInitialized())
            {
                // ... we are done here.
                return;
            }

            // Create a builder, first passing in a suite of Unity provided stores.
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            
            builder.AddProduct(kProductIDConsumable, ProductType.Consumable);
            builder.AddProduct(kProductIDNonConsumable, ProductType.NonConsumable);
            builder.AddProduct("kitbasico", ProductType.Consumable);
            builder.AddProduct("armadilha50", ProductType.Consumable);
            builder.AddProduct("dinamite25", ProductType.Consumable);
          //  builder.AddProduct("bau1", ProductType.Consumable);
            builder.AddProduct(kProductIDSubscription, ProductType.Subscription, new IDs()
            {
       
                { kProductNameGooglePlaySubscription, GooglePlay.Name },
            });

            UnityPurchasing.Initialize(this, builder);
        }


        private bool IsInitialized()
        {
        // Only say we are initialized if both the Purchasing references are set.
        //return m_StoreController != null & amp; &amp; m_StoreExtensionProvider != null;
         return m_StoreController != null && m_StoreExtensionProvider != null;
        }


        public void BuyConsumable()
        {
            // Buy the consumable product using its general identifier. Expect a response either 
            // through ProcessPurchase or OnPurchaseFailed asynchronously.
            BuyProductID(kProductIDConsumable);
        }


        public void BuyNonConsumable()
        {
            // Buy the non-consumable product using its general identifier. Expect a response either 
            // through ProcessPurchase or OnPurchaseFailed asynchronously.
            BuyProductID(kProductIDNonConsumable);
        }


        public void BuySubscription()
        {
            // Buy the subscription product using its the general identifier. Expect a response either 
            // through ProcessPurchase or OnPurchaseFailed asynchronously.
            // Notice how we use the general product identifier in spite of this ID being mapped to
            // custom store-specific identifiers above.
            BuyProductID(kProductIDSubscription);
        }


        public void BuyProductID(string productId)
        {
            // If Purchasing has been initialized ...
            if (IsInitialized())
            {
                // ... look up the Product reference with the general product identifier and the Purchasing 
                // system's products collection.
                Product product = m_StoreController.products.WithID(productId);

                // If the look up found a product for this device's store and that product is ready to be sold ... 
                if (product != null && product.availableToPurchase)
                {
                    Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                    // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                    // asynchronously.
                    m_StoreController.InitiatePurchase(product);
                }
                // Otherwise ...
                else
                {
                    // ... report the product look-up failure situation  
                    Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                }
            }
            // Otherwise ...
            else
            {
                // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
                // retrying initiailization.
                Debug.Log("BuyProductID FAIL. Not initialized.");
            }
        }


        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            // Purchasing has succeeded initializing. Collect our Purchasing references.
            Debug.Log("OnInitialized: PASS");

            // Overall Purchasing system, configured with products for this application.
            m_StoreController = controller;
            // Store specific subsystem, for accessing device-specific store features.
            m_StoreExtensionProvider = extensions;
        }


        public void OnInitializeFailed(InitializationFailureReason error)
        {
            // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
            Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
        }


        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {
            // A consumable product has been purchased by this user.
            if (String.Equals(args.purchasedProduct.definition.id, kProductIDConsumable, StringComparison.Ordinal))
            {
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
              //Removi  ScoreManager.score += 100;
            }
            // Or ... a non-consumable product has been purchased by this user.
            else if (String.Equals(args.purchasedProduct.definition.id, kProductIDNonConsumable, StringComparison.Ordinal))
            {
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                // TODO: The non-consumable item has been successfully purchased, grant this item to the player.
            }
            // Or ... a subscription product has been purchased by this user.
            else if (String.Equals(args.purchasedProduct.definition.id, kProductIDSubscription, StringComparison.Ordinal))
            {
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                // TODO: The subscription item has been successfully purchased, grant this to the player.
            }
        // Or ... an unknown product has been purchased by this user. Fill in additional products here....
           else if (String.Equals(args.purchasedProduct.definition.id, "kitbasico", StringComparison.Ordinal))
            {
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            GetComponent<AcountController>().CompraDinamite += 5;
            GetComponent<AcountController>().RemoveADS = 1;
            int noADS = GetComponent<AcountController>().RemoveADS;
            PlayerPrefs.SetInt("noADS", 1);
            // TODO: The subscription item has been successfully purchased, grant this to the player.
            //Chamar a função pra remover o anuncio, e liberar skin1
        }
        // Or ... an unknown product has been purchased by this user. Fill in additional products here....
        else if (String.Equals(args.purchasedProduct.definition.id, "armadilha50", StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            GetComponent<AcountController>().CompraArmadilha += 50;
            // TODO: The subscription item has been successfully purchased, grant this to the player.
        }
        // Or ... an unknown product has been purchased by this user. Fill in additional products here....
        else if (String.Equals(args.purchasedProduct.definition.id, "dinamite25", StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            GetComponent<AcountController>().CompraDinamite += 25;
            Debug.Log(GetComponent<AcountController>().CompraDinamite);
            // TODO: The subscription item has been successfully purchased, grant this to the player.
        }
        // Or ... an unknown product has been purchased by this user. Fill in additional products here....
        else
        {
                Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
            }

            // Return a flag indicating whether this product has completely been received, or if the application needs 
            // to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
            // saving purchased products to the cloud, and when that save is delayed. 
            return PurchaseProcessingResult.Complete;
        }


        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
            // this reason with the user to guide their troubleshooting actions.
            Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
        }
    
}