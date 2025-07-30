using UnityEngine;

public class MapLoader : MonoBehaviour
{
    WebViewObject webViewObject;

    void Start()
    {
        webViewObject = gameObject.AddComponent<WebViewObject>();
        webViewObject.Init();

#if UNITY_ANDROID
        string url = "file:///android_asset/yandex_map.html";
#elif UNITY_IOS
        string url = Application.streamingAssetsPath + "/yandex_map.html";
#else
        string url = "https://your-fallback-url.com";
#endif

        webViewObject.LoadURL(url);
        webViewObject.SetVisibility(true);
        webViewObject.SetMargins(0, 0, 0, 0);
    }

    // 💡 Вызывай этот метод для обновления позиции
    public void UpdatePlayerPosition(float latitude, float longitude)
    {
        string js = $"updatePlayerPosition({latitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}, {longitude.ToString(System.Globalization.CultureInfo.InvariantCulture)});";
        webViewObject.EvaluateJS(js);
    }
}