using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TradeButton : MonoBehaviour
    {
        [SerializeField] private Image blurImage;
        [SerializeField] private TMP_Text text;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        
        public void SetBuyButton(bool isAvailableToBuy)
        {
            _button.interactable = isAvailableToBuy;
            blurImage.enabled = !isAvailableToBuy;
            text.text = "buy";
        }
       
        public void SetSellButton()
        {
            _button.interactable = true;
            blurImage.enabled = false;
            text.text = "sell";
        }
        
        public void SetTradeButton()
        {
            _button.interactable = false;
            blurImage.enabled = true;
            text.text = "trade";    
        }

    }
}