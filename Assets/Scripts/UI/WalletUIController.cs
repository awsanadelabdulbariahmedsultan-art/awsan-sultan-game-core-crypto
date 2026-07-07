using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace AwsanSultan.GameCore.UI
{
    public class WalletUIController : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Button connectWalletButton;
        [SerializeField] private TextMeshProUGUI walletAddressText;
        [SerializeField] private TextMeshProUGUI tokenBalanceText;
        [SerializeField] private GameObject connectionStatusPanel;

        private void OnEnable()
        {
            if (connectWalletButton != null)
                connectWalletButton.onClick.AddListener(HandleConnectWallet);
        }

        private void OnDisable()
        {
            if (connectWalletButton != null)
                connectWalletButton.onClick.RemoveListener(HandleConnectWallet);
        }

        private void Start()
        {
            // تحديث الواجهة المبدئية عند الإقلاع
            UpdateUI(false, "Disconnected", "0.00 AST");
        }

        private void HandleConnectWallet()
        {
            try
            {
                // هنا يتم استدعاء كودك الجاهز والمتكامل من المحفظة الأساسية
                // مثال افتراضي للاستدعاء بناءً على بنية Web3WalletManager الخاصة بك:
                // Web3WalletManager.Instance.Connect(OnWalletConnected);
                
                walletAddressText.text = "Connecting...";
            }
            catch (Exception ex)
            {
                Debug.LogError($"Wallet Connection Error: {ex.Message}");
            }
        }

        public void UpdateUI(bool isConnected, string address, string balance)
        {
            if (walletAddressText != null) walletAddressText.text = address;
            if (tokenBalanceText != null) tokenBalanceText.text = balance;
            if (connectWalletButton != null) connectWalletButton.gameObject.SetActive(!isConnected);
            if (connectionStatusPanel != null) connectionStatusPanel.SetActive(isConnected);
        }
    }
}
