using System.Windows;
using WiredBrainCoffee.Simulators;

namespace WiredBrainCoffee.UI.Wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly CoffeeMachine _coffeeMachine;

		public MainWindow()
		{
			InitializeComponent();
			_coffeeMachine = new CoffeeMachine();
			SetTextTitle();
		}

		private void BtnMakeCapuchinoClicked(object sender, RoutedEventArgs e)
		{
			_coffeeMachine.MakeCappuccino();
			SetTextTitle();
		}

		private void SetTextTitle()
		{
			txtCapuchinoCounter.Text = _coffeeMachine.CounterCappuccino.ToString();
		}
	}
}