namespace Finance.ModulusChecking.Domain
{
    public interface IModulusCheck
    {
        bool IsValid(BankDetails bankDetails);
    }
}