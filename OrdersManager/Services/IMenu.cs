namespace OrdersManager.Services
{
    public enum MenuAction
    {
        Stay,        
        GoToMainMenu,
        GoToProductMenu,
        GoToDeleteMenu,
        Exit
    }

    public interface IMenu
    {
        MenuAction Display();
    }
}