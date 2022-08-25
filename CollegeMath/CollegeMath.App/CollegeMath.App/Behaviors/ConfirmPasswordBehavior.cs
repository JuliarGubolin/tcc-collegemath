using CollegeMath.App.Models.Custom;
using Xamarin.Forms;

//Comportamentos que podem ser injtados nos controles de tela
namespace CollegeMath.App.Behaviors
{
    public class ConfirmPasswordBehavior : Behavior<RoundedEntry>
    {
        //Criação de propriedades
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(ConfirmPasswordBehavior), false);
        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public static readonly BindableProperty CompareToEntryProperty = BindableProperty.Create("CompareToEntry", typeof(RoundedEntry), typeof(ConfirmPasswordBehavior), null);

        public RoundedEntry CompareToEntry
        {
            get { return (RoundedEntry)base.GetValue(CompareToEntryProperty); }
            set { base.SetValue(CompareToEntryProperty, value); }
        }
        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }
        protected override void OnAttachedTo(RoundedEntry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(RoundedEntry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }
        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            var password = CompareToEntry.Text;
            var confirmPassword = e.NewTextValue;
            IsValid = password.Equals(confirmPassword);
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }
    }
}
