using System.Windows;

namespace Session12
{
    public partial class User
    {
        public string Fullname
        {
            get => $"{LastName[0]}. {FirstName[0]}. {Patronymic}";
        }
        public Visibility VisibilitiButton
        {
            get => (App.User.RoleID == 4) ?
                Visibility.Collapsed : Visibility.Visible;
        }
        public Visibility VisibilitiMakeAndAddOrder
        {
            get => (App.User.RoleID != 2) ?
                Visibility.Collapsed : Visibility.Visible;
        }
        public Visibility VisibilitiUserToMakeOrAddOrder
        {
            get => (App.User.RoleID == 4) ?
                Visibility.Visible : Visibility.Collapsed;
        }
        public Visibility VisibilitiUserToMakeOrAddOrdernd4
        {
            get => (App.User.RoleID == 4 ||
                    App.User.RoleID == 2) ?
                Visibility.Visible : Visibility.Collapsed;
        }
        public Visibility VisibilitiUserStorekeeper
        {
            get => (App.User.RoleID == 3) ?
                Visibility.Visible : Visibility.Collapsed;
        }
    }
}
