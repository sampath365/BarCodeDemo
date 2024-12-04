namespace BarCodeDemo;

public partial class BarcodeScanPage : ContentPage
{
	public BarcodeScanPage()
	{
		InitializeComponent();
	}

    private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {

    }
}