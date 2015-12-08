namespace Problem_03.RepeatingStrings
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IStringSearcherService
    {
        [OperationContract]
        int GetCount(string a, string b);

    }
}
