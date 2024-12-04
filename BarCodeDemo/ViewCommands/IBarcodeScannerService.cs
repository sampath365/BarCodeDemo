namespace BarCodeDemo.ViewCommands
{
    public interface IBarcodeScannerService
    {
        Task<string> ScanBarcodeAsync();
    }

}
