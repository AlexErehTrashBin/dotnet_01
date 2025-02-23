using Avalonia.Controls;
using Task01.ViewModels;

namespace Task01.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void TakeCreditSpinner_OnSpin(object? sender, SpinEventArgs e)
    {
        if (DataContext is not MainWindowViewModel vm) return;
        switch (e.Direction)
        {
            case SpinDirection.Increase:
                vm.TakeCreditValue += new decimal(0.5);
                break;
            case SpinDirection.Decrease:
                vm.TakeCreditValue -= new decimal(0.5);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void RepayCreditSpinner_OnSpin(object? sender, SpinEventArgs e)
    {
        if (DataContext is not MainWindowViewModel vm) return;
        switch (e.Direction)
        {
            case SpinDirection.Increase:
                vm.RepayCreditValue += new decimal(0.5);
                break;
            case SpinDirection.Decrease:
                vm.RepayCreditValue -= new decimal(0.5);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void WithdrawSpinner_OnSpin(object? sender, SpinEventArgs e)
    {
        if (DataContext is not MainWindowViewModel vm) return;
        switch (e.Direction)
        {
            case SpinDirection.Increase:
                vm.WithdrawValue += new decimal(0.5);
                break;
            case SpinDirection.Decrease:
                vm.WithdrawValue -= new decimal(0.5);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void DepositSpinner_OnSpin(object? sender, SpinEventArgs e)
    {
        if (DataContext is not MainWindowViewModel vm) return;
        switch (e.Direction)
        {
            case SpinDirection.Increase:
                vm.DepositValue += new decimal(0.5);
                break;
            case SpinDirection.Decrease:
                vm.DepositValue -= new decimal(0.5);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}