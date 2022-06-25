// See https://aka.ms/new-console-template for more information


var userDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

Console.WriteLine("Profile list : ");
var configProfiles = Directory.GetFiles(userDir, ".gitconfig@*");
foreach (var configProfile in configProfiles) {
    var profileName = configProfile.Split("@")[1];

    Console.WriteLine($"    @{Path.GetFileName(profileName)}");
}

Console.WriteLine("─────────────────────────────────");
Console.WriteLine("Type to target profile to swtich : ");
var targetProfileName = Console.ReadLine().Trim();
if (!string.IsNullOrEmpty(targetProfileName) && targetProfileName[0] == '@') {
    targetProfileName = targetProfileName.Substring(1);
}

foreach (var configProfile in configProfiles) {
    var profileName = configProfile.Split("@")[1];

    if (targetProfileName == profileName) {
        var configDir = Path.GetDirectoryName(configProfile);
        try {
            File.Copy(configProfile, Path.Combine(configDir, ".gitconfig"), true);

            Console.WriteLine($"Switching to '{profileName}' completed.");
        } catch (Exception ex) {
            Console.WriteLine($"Switching failed because of : {ex}");
        }

        Console.ReadLine();
        return;
    }
}

Console.WriteLine($"Not found profile '${targetProfileName}'");
Console.ReadLine();