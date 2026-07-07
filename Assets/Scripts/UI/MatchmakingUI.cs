using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace AwsanSultan.GameCore.UI
{
    public class MatchmakingUI : MonoBehaviour
    {
        [Header("UI Panels & Windows")]
        [SerializeField] private GameObject matchmakingMenuPanel;
        [SerializeField] private GameObject searchingOverlayPanel;

        [Header("Text & Visual Indicators")]
        [SerializeField] private TextMeshProUGUI statusText;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private Button startSearchButton;
        [SerializeField] private Button cancelSearchButton;

        private float searchStartTime;
        private bool isSearching = false;

        private void OnEnable()
        {
            if (startSearchButton != null) startSearchButton.onClick.AddListener(StartMatchmakingSearch);
            if (cancelSearchButton != null) cancelSearchButton.onClick.AddListener(CancelMatchmakingSearch);
        }

        private void OnDisable()
        {
            if (startSearchButton != null) startSearchButton.onClick.RemoveListener(StartMatchmakingSearch);
            if (cancelSearchButton != null) cancelSearchButton.onClick.RemoveListener(CancelMatchmakingSearch);
        }

        private void Update()
        {
            if (isSearching)
            {
                float elapsedTime = Time.time - searchStartTime;
                TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
                if (timerText != null)
                    timerText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
            }
        }

        private void StartMatchmakingSearch()
        {
            isSearching = true;
            searchStartTime = Time.time;
            
            if (searchingOverlayPanel != null) searchingOverlayPanel.SetActive(true);
            if (statusText != null) statusText.text = "Searching for Opponents...";

            // هنا يتم الربط البرمجي مع كودك المتكامل المكتوب سابقاً في الخلفية
            // مثال للاستدعاء: PvPMatchManager.Instance.StartQueue();
        }

        private void CancelMatchmakingSearch()
        {
            isSearching = false;
            if (searchingOverlayPanel != null) searchingOverlayPanel.SetActive(false);
            
            // إلغاء البحث في الكود الخلفي
            // مثال للاستدعاء: PvPMatchManager.Instance.CancelQueue();
        }

        public void OnMatchFound(string matchId)
        {
            isSearching = false;
            if (statusText != null) statusText.text = "Match Found! Loading Arena...";
            // الانتقال التلقائي لمشهد المعركة بالتنسيق مع مدير اللعبة
        }
    }
}
