using UnityEngine;

namespace AwsanSultan.GameCore.Config
{
    public class PlayerSettingsPrefs : MonoBehaviour
    {
        private conststring GraphicsQualityKey = "SavedGraphicsQuality";
        private conststring VolumeKey = "SavedVolumeSettings";

        // حفظ خيارات الجرافيكس المخصصة للاعب
        public void SavePlayerGraphicsSelection(int qualityIndex)
        {
            PlayerPrefs.SetInt(GraphicsQualityKey, qualityIndex);
            PlayerPrefs.Save();
            Debug.Log($"Player graphics preference saved: Index {qualityIndex}");
        }

        // جلب الإعدادات المحفوظة عند تشغيل اللعبة مجدداً
        public int GetSavedGraphicsSelection()
        {
            // يرجع الجودة رقم 3 الافتراضية إذا لم يكن هناك خيار محفوظ مسبقاً
            return PlayerPrefs.GetInt(GraphicsQualityKey, 3); 
        }
    }
}
