using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Web.WebView2.Core;

namespace CoinCoin;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void AddTab_Click(object sender, RoutedEventArgs e)
    { 
        var newTab = new TabItem
        {
            Header = $"Tab",
            HeaderTemplate = (DataTemplate)TabControl.Resources["TabHeaderTemplate"]!,
            Content = new BrowserView()
        };
        
        TabControl.Items.Add(newTab);
        newTab.IsSelected = true;
    }
    
    private void CloseTab_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is TabItem tabItem)
        {
            TabControl.Items.Remove(tabItem);
        }
    }
}