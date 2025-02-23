using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Task01.Views;

public partial class InformationDialog : Window
{
    public InformationDialog()
    {
        InitializeComponent();
    }

    public InformationDialog(String message)
    {
        InitializeComponent();
        LabelText.Text = message;
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}