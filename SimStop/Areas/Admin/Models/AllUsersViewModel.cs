namespace SimStop.Web.ViewModels.Admin.UserManagement
{
    public class AllUsersViewModel
    {
        public string UserId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<string> Roles { get; set; } = new List<string>();
    }
}
