namespace Gap.Clinic.Services
{
    public interface IInclude
    {
        void Add(params string[] inclutions);
        void Clear();
        string Get();
    }
}