using System;
using System.Net.Http;

class Program
{
    static void Main(string[] args)
    {

        #region 2) recommended
        // 2) recommended
        /*
        CurrencyService currencyService = null;
        try
        {
            currencyService = new CurrencyService();
            var result = currencyService.GetCurrencies();
            Console.WriteLine(result);
        }
        catch (Exception)
        {
            Console.WriteLine("Error");
        }
        finally
        {
            currencyService?.Dispose();
        }
        */
        #endregion

        #region  // 3) more recommended

        using (CurrencyService currencyService = new CurrencyService())
        {
            var result = currencyService.GetCurrencies();
            Console.WriteLine(result);
        }

        // Using statement without code blocks (C# 8.0 feature)
        using CurrencyService currencyServiceNoBlock = new CurrencyService();
        var resultNoBlock = currencyServiceNoBlock.GetCurrencies();
        Console.WriteLine(resultNoBlock);
        #endregion

    }
}

class CurrencyService : IDisposable
{
    private readonly HttpClient httpClient;
    private bool _disposed = false;

    public CurrencyService()
    {
        httpClient = new HttpClient();
    }

    public string GetCurrencies()
    {
        string url = "https://coinbase.com/api/v2/currencies";
        var result = httpClient.GetStringAsync(url).Result;
        return result;
    }


    // private bool _disposed = false;
    ~CurrencyService()
    {
        Dispose(false);
    }

    // disposing: true  (dispose managed + unmanaged)
    // disposing: false (dispose unmanaged + large fields)
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            // Dispose managed resources
            httpClient?.Dispose();
        }

        // Dispose unmanaged resources here (if any)

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
