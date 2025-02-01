using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace CoinCoin;

public partial class BrowserView : UserControl
{
    public BrowserView()
    {
        InitializeComponent();
        InitializeWebView();
    }
    
    private string _currentUrl;
    public string CurrentUrl
    {
        get => _currentUrl;
        set
        {
            if (_currentUrl != value)
            {
                _currentUrl = value;
                webView.Source = new Uri(_currentUrl);
                urlTextBox.Text = CurrentUrl;
                OnCurrentUrlChanged(nameof(CurrentUrl));
            }
        }
    }
    
    public event PropertyChangedEventHandler CurrentUrlChanged;

    private void OnCurrentUrlChanged(string propertyName)
    {
        CurrentUrlChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    async void InitializeWebView()
    {
        await webView.EnsureCoreWebView2Async(null);
        webView.NavigationCompleted += WebView_NavigationCompleted;
    }

    private void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
    {
        if (webView.Source != null)
        {
            CurrentUrl = webView.Source.ToString();
        }
    }

    private void goToButton_Click(object sender, RoutedEventArgs e)
    {
        CurrentUrl = urlTextBox.Text;
    }
}