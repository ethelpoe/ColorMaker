using Android.Widget;
using CommunityToolkit.Maui.Core;
using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;
//why you need to add this in order to Toast work.
using Toast = CommunityToolkit.Maui.Alerts.Toast;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
	bool isRandom = false;
	string hexValue;

	public MainPage()
	{
		InitializeComponent();
	}

	private void sldRed_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		if (!isRandom)
        {
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);

            setColor(color);
        }

	}

	private void setColor(Color color)
	{
        Debug.WriteLine(color.ToString());
        btnRandom.BackgroundColor = color;
		Container.BackgroundColor = color;
        hexValue = color.ToHex();
		lblHex.Text = hexValue;


    }

	private void btnRandom_Clicked(object sender, EventArgs e)
	{
		isRandom = true;
		var random = new Random();
		var color = Color.FromRgb(random.Next(0, 256),
									random.Next(0, 256),
									random.Next(0, 256));

		setColor(color);

		sldRed.Value = color.Red;
		isRandom = false;
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
        string text = "Color Copied";
        ToastDuration duration = ToastDuration.Short;
        double fontSize = 14;

        await Clipboard.SetTextAsync(hexValue);


		var toast = Toast.Make(text,duration,fontSize);
        /*
         * var toast = Toast.Make("Color copied",
               CommunityToolkit.Maui.Core.ToastDuration.Short,
               12);
		*/

        await toast.Show();
    }
}

