namespace DnDIMDesktopUI.Library.Model
{
    public interface ILoggedInUserModel
    {
        string UserName { get; set; }
        string Id { get; set; }
        string Token { get; set; }
        
        void LogOffUser();
    }
    
}