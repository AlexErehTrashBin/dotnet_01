using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task01.Models;

namespace Task01.Util;

public class BankAccountWrapper(BankAccount account) : INotifyPropertyChanged
{
    public decimal Balance => account.Balance;
    public string BankName => account.BankName;
    public string Inn => account.Inn;
    public string Bik => account.Bik;
    public string CorrespondentAccount => account.CorrespondentAccount;
    public decimal CurrentCredit => account.CurrentCredit;
    public decimal CreditCommission => account.CreditCommission;
    public decimal CreditInterestRate => account.CreditInterestRate;

    public void Deposit(decimal amount)
    {
        account.Deposit(amount);
        OnPropertyChanged(nameof(Balance));
    }

    public void Withdraw(decimal amount)
    {
        account.Withdraw(amount);
        OnPropertyChanged(nameof(Balance));
    }

    public void TakeCredit(decimal amount)
    {
        account.TakeCredit(amount);
        OnPropertyChanged(nameof(Balance));
        OnPropertyChanged(nameof(CurrentCredit));
    }

    public void RepayCredit(decimal amount)
    {
        account.RepayCredit(amount);
        OnPropertyChanged(nameof(Balance));
        OnPropertyChanged(nameof(CurrentCredit));
    }

    public void AccrueInterest()
    {
        account.AccrueInterest();
        OnPropertyChanged(nameof(Balance));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}