namespace EmployeeRegister.Models
{
    internal class intLengthAttribute : Attribute
    {
        private int v;
        private string errorMessage;

        public intLengthAttribute(int v, string ErrorMessage)
        {
            this.v = v;
            errorMessage = ErrorMessage;
        }

        public string ErrorMessage { get; set; }
    }
}