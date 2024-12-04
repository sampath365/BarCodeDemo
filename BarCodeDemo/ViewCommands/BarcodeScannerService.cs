namespace BarCodeDemo.ViewCommands
{
    public class BarcodeScannerService : IBarcodeScannerService
    {
        public async Task<string> ScanBarcodeAsync()
        {
            //try
            //{
            //    var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            //    var result = await scanner.Scan();
            //    return result?.Text;
            //}
            //catch (Exception ex)
            //{
            //    // Handle error (optional)
            //    Console.WriteLine(ex.Message);
            //    return null;
            //}

            return null;
        }
    }

}
