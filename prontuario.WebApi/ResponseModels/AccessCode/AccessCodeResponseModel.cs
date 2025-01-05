namespace prontuario.WebApi.ResponseModels
{
    public class AccessCodeResponseModel
    {
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public bool IsUserUpdatePassword { get; set; }
        public DateTime ExperationDate { get; set; }

        public AccessCodeResponseModel(string code, bool isActive, bool isUserUpdatePassword, DateTime expirationDate)
        {
            Code = code;
            IsActive = isActive;
            IsUserUpdatePassword = isUserUpdatePassword;
            ExperationDate = expirationDate;
        }
    }
}
