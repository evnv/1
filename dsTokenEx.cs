instance.UseTrafficMonitoring = true;

Tab tab = instance.ActiveTab;
tab.Navigate("https://discord.com");
if(tab.IsBusy) tab.WaitDownloading();

System.Threading.Thread.Sleep(3000);

var trafficItems = instance.ActiveTab.GetTraffic();

string pattern = @"Authorization:\s*(.*?)\r?\n";
string token = "";

foreach(var t in trafficItems)
{
    if (t.Url.Contains("discord.com/api/v9/science") && !string.IsNullOrEmpty(t.RequestHeaders))
    {
        var match = System.Text.RegularExpressions.Regex.Match(t.RequestHeaders, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        if(match.Success)
        {
            token = match.Groups[1].Value;
            break;
        }
    }
}

return token;
