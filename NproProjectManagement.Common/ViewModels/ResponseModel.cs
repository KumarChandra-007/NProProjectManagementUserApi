namespace Common.ViewModels
{
    public class LoginResponse
    {
        public string Message { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }        
    }

    public class StatusResponse
    {
        public int StatusId { get; set; }

        public string StatusName { get; set; }        
    }

    public class RoleResponse
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }      
    }
}
