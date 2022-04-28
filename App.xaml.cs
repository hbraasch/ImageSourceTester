namespace ImageSourceTester;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		ZippedFiles.Extract();

		MainPage = new NavigationPage(new StartupPage()) { BarTextColor = Colors.Blue, BarBackgroundColor = Colors.Grey };
	}
}
