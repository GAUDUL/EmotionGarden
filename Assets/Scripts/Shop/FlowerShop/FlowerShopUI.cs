using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using EmotionGarden.Models;

public class FlowerShopUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private Transform gridParent;
    [SerializeField] private FlowerSlotUI slotPrefab;
    [SerializeField] private Confirm confirmModal;
    private int lastPoints = -1;

    void Start()
    {
        UpdatePointsUI();
        LoadFlowers();
    }

    void Update()
    {
        int currentPoints = GameManager.Instance.EmotionPoints;
        if (currentPoints != lastPoints)
        {
            UpdatePointsUI();
            lastPoints = currentPoints;
        }
    }

    void UpdatePointsUI()
    {
        pointsText.text = $"{GameManager.Instance.EmotionPoints}";
    }

    void LoadFlowers()
    {
        List<ItemIdPriceName> flowerItems = DatabaseController.Instance.GetItemsByType("flower");
        var ownedItems = DatabaseController.Instance.GetMyItemsByType("flower");

        foreach (var item in flowerItems)
        {
            var slot = Instantiate(slotPrefab, gridParent);

            bool isOwned = ownedItems.Exists(i => i.item_id == item.item_id);

            Sprite sprite = LoadFlowerSprite(item.item_id);

            var data = new FlowerUIData(item.item_id, item.name, item.price, sprite);

            slot.Initialize(data, this, isOwned, confirmModal);
        }
    }

    private Sprite LoadFlowerSprite(int itemId)
    {
        return Resources.Load<Sprite>($"Flowers/{itemId}");
    }

    public void TryBuyItem(int itemId, int price)
    {
        int points = GameManager.Instance.EmotionPoints;

        if (points < price)
        {
            Debug.Log("포인트 부족!");
            return;
        }

        
        var myItems = DatabaseController.Instance.GetMyItems();
        if (myItems.Exists(i => i.item_id == itemId))
        {
            Debug.Log("이미 구매한 아이템입니다.");
            return;
        }

        DatabaseController.Instance.AddItem(itemId);
        GameManager.Instance.UseEmotionPoints(price);

        UpdatePointsUI();
        Debug.Log($"구매 완료: {itemId}");
    }
    
}
