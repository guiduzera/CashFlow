using System.Globalization;

namespace CashFlow.API.Middlewares;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;

    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

        var requestedLangauage = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var defaultCulture = new CultureInfo("pt-BR");

        if (string.IsNullOrWhiteSpace(requestedLangauage) == false && supportedLanguages.Exists((e) => e.Name.Equals(requestedLangauage)))
        {
            defaultCulture = new CultureInfo(requestedLangauage);
        }

        CultureInfo.CurrentCulture = defaultCulture;
        CultureInfo.CurrentUICulture = defaultCulture;

        await _next(context);
    }
}
