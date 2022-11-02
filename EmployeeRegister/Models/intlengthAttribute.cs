namespace EmployeeRegister.Models
{
    internal class intlengthAttribute : Attribute
    {
        private int v;

        public intlengthAttribute(int v, string ErrorMessage)
        {
            this.v = v;
            this.ErrorMessage = ErrorMessage;
        }

        public string ErrorMessage { get; set; }
    }
}