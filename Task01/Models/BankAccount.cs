namespace Task01.Models;

public class BankAccount(
    string bankName,
    string inn,
    string bik,
    string correspondentAccount,
    decimal initialBalance,
    decimal currentCredit,
    decimal creditCommission,
    decimal creditInterestRate)
{
    public string BankName { get; private set; } = bankName;
    public string Inn { get; private set; } = inn;
    public string Bik { get; private set; } = bik;
    public string CorrespondentAccount { get; private set; } = correspondentAccount;
    public decimal Balance { get; private set; } = initialBalance;
    public decimal CurrentCredit { get; private set; } = currentCredit;
    public decimal CreditCommission { get; private set; } = creditCommission;
    public decimal CreditInterestRate { get; private set; } = creditInterestRate;
    
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Сумма для пополнения должна быть положительной.");
        }

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Сумма для снятия должна быть положительной.");
        }

        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Недостаточно средств на счете.");
        }

        Balance -= amount;
    }

    public void TakeCredit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Сумма кредита должна быть положительной.");
        }

        CurrentCredit += amount;
        Balance += amount;
        Balance -= CreditCommission / 100 * Balance; // Комиссия за снятие кредита
    }

    public void RepayCredit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Сумма погашения должна быть положительной.");
        }
        
        if (amount > Balance)
        {
            throw new InvalidOperationException("Сумма погашения превышает текущий баланс.");
        }

        if (amount > CurrentCredit)
        {
            amount = CurrentCredit;
        }

        Balance -= amount;
        CurrentCredit -= amount;
    }

    public void AccrueInterest()
    {
        var interest = CurrentCredit * CreditInterestRate / 100;
        if (Balance - interest <= new decimal(0.0))
        {
            throw new InvalidOperationException("Сумма будет отрицательной при начисении процента");
        }
        Balance -= interest;
    }
}