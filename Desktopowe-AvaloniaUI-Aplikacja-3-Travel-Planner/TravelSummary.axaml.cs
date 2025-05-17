using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Desktopowe_AvaloniaUI_Aplikacja_3_Travel_Planner;

public partial class TravelSummary : Window
{
    public TravelSummary(string Content)
    {
        InitializeComponent();
        ContentTextBlock.Text = Content;
    }
    
    
    
    
}