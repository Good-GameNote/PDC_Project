using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine.Purchasing;
using System;

public class IAPManager : MonoBehaviour, IStoreListener
{
    private static IStoreController storeController;
    private static IExtensionProvider storeExtensionProvider;

    public static string productID = "your_product_id"; // Google Play Console에서 설정한 상품 ID

    async void Start()
    {
        // Unity Gaming Services 초기화
        try
        {
            var options = new InitializationOptions().SetEnvironmentName("production");
            await UnityServices.InitializeAsync(options);

            if (UnityServices.State == ServicesInitializationState.Initialized)
            {
                Debug.Log("Unity Gaming Services initialized successfully.");
                InitializePurchasing();
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to initialize Unity Gaming Services: {e.Message}");
        }
    }

    void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance(AppStore.GooglePlay));

        builder.AddProduct(productID, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return storeController != null && storeExtensionProvider != null;
    }

    public void BuyProduct()
    {
        if (IsInitialized())
        {
            Product product = storeController.products.WithID(productID);

            if (product != null && product.availableToPurchase)
            {
                Debug.Log($"Purchasing product asychronously: '{product.definition.id}'");
                storeController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProduct: Fail. Not purchasing product, either it is not found or is not available for purchase.");
            }
        }
        else
        {
            Debug.Log("BuyProduct: Fail. Not initialized.");
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");

        storeController = controller;
        storeExtensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log($"OnInitializeFailed InitializationFailureReason: {error}");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"OnPurchaseFailed: FAIL. Product: '{product.definition.storeSpecificId}', PurchaseFailureReason: {failureReason}");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, productID, StringComparison.Ordinal))
        {
            Debug.Log($"여기서 아이템 지급 등의 로직을 추가합니다 ProcessPurchase: PASS. Product: '{args.purchasedProduct.definition.id}'");

            // 여기서 아이템 지급 등의 로직을 추가합니다.
        }
        else
        {
            Debug.Log($"ProcessPurchase: FAIL. Unrecognized product: '{args.purchasedProduct.definition.id}'");
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log($"OnInitializeFailed InitializationFailureReason: {error}, message: {message}");
    }
}
