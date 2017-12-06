using UnityEngine;
using UnityEngine.UI;
using SIS;

public class ProductPurchaseButton : MonoBehaviour
{
	//enter product identifier for this button in the inspector
	public string productId;


	void OnEnable()
	{
		//check if product has been bought before
		//if it has been bought already, hide the button
		if(DBManager.isPurchased(productId))
		{
			gameObject.SetActive(false);
			return;
		}

		//listen to purchase events in the future
		IAPManager.purchaseSucceededEvent += HandlePurchase;
	}


	void OnDisable()
	{
		//unsubscribe from purchase events
		IAPManager.purchaseSucceededEvent -= HandlePurchase;
	}


	//linked with the OnClick button action
	public void DoPurchase()
	{
		IAPManager.PurchaseProduct(productId);
	}


	void HandlePurchase(string id)
	{
		//this product was bought right now, so hide the button
		if(id == productId)
		{
			gameObject.SetActive(false);
		}
	}
}