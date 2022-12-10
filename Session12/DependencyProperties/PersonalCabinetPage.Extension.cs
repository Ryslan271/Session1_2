using System.Collections.ObjectModel;
using System.Windows;

namespace Session12.Pages
{
    public partial class PersonalCabinetPage
    {
        public User MainUser
        {
            get { return (User)GetValue(MainUserProperty); }
            set { SetValue(MainUserProperty, value); }
        }

        public static readonly DependencyProperty MainUserProperty =
            DependencyProperty.Register("MainUser", typeof(User), typeof(PersonalCabinetPage));

        public ObservableCollection<Gender> Genders
        {
            get { return (ObservableCollection<Gender>)GetValue(GendersProperty); }
            set { SetValue(GendersProperty, value); }
        }

        public static readonly DependencyProperty GendersProperty =
            DependencyProperty.Register("Genders", typeof(ObservableCollection<Gender>), typeof(PersonalCabinetPage));
    }
}
