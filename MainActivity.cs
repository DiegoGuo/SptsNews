using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Webkit;

namespace App23
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private WebView webView;
        private WebViewClient mWebviewClient;
        private WebChromeClient mWebChromeClient;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            webView = (WebView)FindViewById(Resource.Id.webView1);
            initWebView();
            string movieUrl = "http://m.youku.com/video/id_XMzg3MTY2MDE2MA==.html?firsttime=0&source=";
            webView.LoadUrl(movieUrl);
        }

        private void initWebView()
        {
            //mProgressBar.setVisibility(View.VISIBLE);
            WebSettings ws = webView.Settings;
            // 网页内容的宽度是否可大于WebView控件的宽度
            ws.LoadWithOverviewMode = false;

            // 保存表单数据
            ws.SaveFormData = true;

            // 是否应该支持使用其屏幕缩放控件和手势缩放
            ws.SetEnableSmoothTransition(true);

            ws.BuiltInZoomControls = true;

            ws.DisplayZoomControls = false;

            // 启动应用缓存
            ws.SetAppCacheEnabled(true);

            // 设置缓存模式
            //ws.setCacheMode(WebSettings.LOAD_DEFAULT);
            ws.CacheMode = CacheModes.Default;

            // setDefaultZoom  api19被弃用
            // 设置此属性，可任意比例缩放。
            ws.UseWideViewPort = true;

            // 不缩放
            webView.SetInitialScale(100);

            // 告诉WebView启用JavaScript执行。默认的是false。
            ws.JavaScriptEnabled = true;

            //  页面加载好以后，再放开图片
            ws.BlockNetworkImage = false;

            // 使用localStorage则必须打开
            ws.DomStorageEnabled = true;

            // 排版适应屏幕
            ws.SetLayoutAlgorithm(WebSettings.LayoutAlgorithm.NarrowColumns);

            // WebView是否新窗口打开(加了后可能打不开网页)
            ws.SetSupportMultipleWindows(true);

            // webview从5.0开始默认不允许混合模式,https中不能加载http资源,需要设置开启。
            if (Build.VERSION.SdkInt >= Build.VERSION_CODES.Lollipop)
            {
                ws.MixedContentMode = WebSettings.MixedContentAlwaysAllow;
            }
            /** 设置字体默认缩放大小(改变网页字体大小,setTextSize  api14被弃用)*/
            ws.TextZoom = 100;

            mWebviewClient = new WebViewClient();
            mWebChromeClient = new WebChromeClient();

            webView.SetWebViewClient(mWebviewClient);
            // 与js交互
            //webView.addJavascriptInterface(new ImageClickInterface(this), "injectedObject");

        }
    }
}