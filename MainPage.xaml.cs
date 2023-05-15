using MauiArabic.Resources.Strings;

namespace MauiArabic;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = string.Format(Strings.ClickedXTime, count);
		else
			CounterBtn.Text = string.Format(Strings.ClickedXTimes, count);

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

