namespace WebProject.ViewModels
{
    public class AdminUserRoleViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? DisplayName { get; set; }
        public string CurrentRole { get; set; } = string.Empty;
    }
}
