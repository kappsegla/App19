namespace App1.Validation
{
    public class UserNameAtLeast5Characters<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        
        public bool Check(T value)
        {
            switch (value)
            {
                case null:
                    return false;
                case string s:
                    return s.Length >= 5;
                default:
                    return false;
            }
        }
    }
}