// See https://aka.ms/new-console-template for more information
using JurnalModul8_103022300072;

 class Program
{
    private const String url = @"../../../bank_transfer_config.json";

    public static void Main(string[] args)
    {
        BankTransferConfig bankConfig = new BankTransferConfig();
        bankConfig.ReadConfigFile(url);

        bool defaultLang = bankConfig.lang == "en";

        Console.WriteLine(defaultLang ? "Welcome" : "Selamat Datang!");
        Console.WriteLine(defaultLang ? "Program Language!: " : "Bahasa Saat Ini!: " + bankConfig.lang);

        try
        {
            Console.Write(defaultLang ? "Please insert the amount of money to transfer: " : "Masukkan jumlah uang yang akan di-transfer: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            int totalPayed = 0;

            Console.WriteLine(defaultLang ? "Select payment method: " : "Pilih metode pembayaran: ");
            string[] methodPayment = bankConfig.methods;

            for (int i = 0; i < methodPayment.Length; i++)
            {
                Console.WriteLine(i + " " + methodPayment[i]);
            }

            Console.Write(defaultLang ? "Choose number: " : "Pilih nomor: ");
            int? choosenMethodPayment = Convert.ToInt32(Console.ReadLine());

            if (choosenMethodPayment != null)
            {
                if (amount <= bankConfig.transfer.threshold)
                {
                    int fee = bankConfig.transfer.low_fee;

                    totalPayed = amount + fee;
                    Console.WriteLine(defaultLang ? $"Transfer fee: {fee} and Total amount: {totalPayed}" : $"Biaya transfer: {fee} and Total biaya: {totalPayed}");
                }
                else if (amount >= bankConfig.transfer.threshold)
                {
                    int fee = bankConfig.transfer.high_fee;

                    totalPayed = amount + fee;
                    Console.WriteLine(defaultLang ? $"Transfer fee: {fee} and Total amount: {totalPayed}" : $"Biaya transfer: {fee} and Total biaya: {totalPayed}");
                }

                Console.WriteLine(defaultLang ? "Transfer is completed!" : "Transfer berhasil!");
            }
        }
        catch
        {
            Console.WriteLine(defaultLang ? "Transfer is cancelled!" : "Transfer dibatalkan!");
        }
    }
}
