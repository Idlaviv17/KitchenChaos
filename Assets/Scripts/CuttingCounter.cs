using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter {

    [SerializeField] private KitchenObjectSO cuttingKitchenObjectSO;

    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            if (player.HasKitchenObject()) player.GetKitchenObject().SetKitchenObjectParent(this);
        } else {
            if (!player.HasKitchenObject()) GetKitchenObject().SetKitchenObjectParent(player);
        }
    }

    public override void InteractAlternate(Player player) {
        if (HasKitchenObject()) {
            GetKitchenObject().DestroySelf();
            Transform kitchenObjectTransform = Instantiate(cuttingKitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
    }
}
