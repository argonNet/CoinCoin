using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Web.WebView2.Core;

namespace CoinCoin;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string _currentUrl;
    public string CurrentUrl
    {
        get => _currentUrl;
        set
        {
            if (_currentUrl != value)
            {
                _currentUrl = value;
                OnPropertyChanged(nameof(CurrentUrl));
                webView.Source = new Uri(_currentUrl);
            }
        }
    }
    
    public MainWindow()
    {
        InitializeComponent();
    }
    
    async void InitializeWebView()
    {
        await webView.EnsureCoreWebView2Async(null);
        webView.NavigationCompleted += WebView_NavigationCompleted;
        CurrentUrl = webView.Source.ToString();
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

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}