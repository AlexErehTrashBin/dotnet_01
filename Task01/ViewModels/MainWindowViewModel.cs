using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Task01.Models;
using ReactiveUI;
using Task01.Util;
using Task01.Views;

namespace Task01.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private BankAccountWrapper _account;
    private decimal _takeCreditValue; 
    private decimal _repayCreditValue; 
    private decimal _withdrawValue;
    private decimal _depositValue;
    
    
    public BankAccountWrapper Account
    {
        get => _account;
        set => this.RaiseAndSetIfChanged(ref _account, value);
    }

    public decimal TakeCreditValue
    {
        get => _takeCreditValue;
        set => this.RaiseAndSetIfChanged(ref _takeCreditValue, value);
    }
    
    public decimal RepayCreditValue
    {
        get => _repayCreditValue;
        set => this.RaiseAndSetIfChanged(ref _repayCreditValue, value);
    }

    public decimal WithdrawValue
    {
        get => _withdrawValue;
        set => this.RaiseAndSetIfChanged(ref _withdrawValue, value);
    }

    public decimal DepositValue
    {
        get => _depositValue;
        set => this.RaiseAndSetIfChanged(ref _depositValue, value);
    }

    public MainWindowViewModel()
    {
        
        _account = new BankAccountWrapper(new BankAccount(
            "Спёрбанк",
            "123456",
            "123456",
            "123456",
            new decimal(0.0),
            new decimal(1000.0),
            new decimal(13.0),
            new decimal(13.0)
        ));
        this.WhenAnyValue(o => o._account)
            .Subscribe(o => this.RaisePropertyChanged(nameof(Account)));
    }

    public void CreateAccount()
    {
        
    }

    public void Deposit()
    {
        try
        {
            Account.Deposit(_depositValue);
        }
        catch (Exception e)
        {
            var dialog = new InformationDialog(e.Message);
            var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null;
            if (mainWindow != null) dialog.ShowDialog(mainWindow);
        }
    }

    public void Withdraw()
    {
        try
        {
            Account.Withdraw(_withdrawValue);
        }
        catch (Exception e)
        {
            var dialog = new InformationDialog(e.Message);
            var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null;
            if (mainWindow != null) dialog.ShowDialog(mainWindow);
        }
    }

    public void TakeCredit()
    {
        try
        {
            Account.TakeCredit(_takeCreditValue);
        }
        catch (Exception e)
        {
            var dialog = new InformationDialog(e.Message);
            var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null;
            if (mainWindow != null) dialog.ShowDialog(mainWindow);
        }
    }
    
    public void RepayCredit()
    {
        try
        {
            Account.RepayCredit(_repayCreditValue);
        }
        catch (Exception e)
        {
            var dialog = new InformationDialog(e.Message);
            var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null;
            if (mainWindow != null) dialog.ShowDialog(mainWindow);
        }
    }

    public void AccrueInterest()
    {
        try
        {
            Account.AccrueInterest();
        }
        catch (Exception e)
        {
            var dialog = new InformationDialog(e.Message);
            var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null;
            if (mainWindow != null) dialog.ShowDialog(mainWindow);
        }
    }
}