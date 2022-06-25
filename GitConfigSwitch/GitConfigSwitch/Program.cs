// See https://aka.ms/new-console-template for more information


var userDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

string targetProfileName = null;
if (args.Length > 0) {
    targetProfileName = args[0].Trim();
}

var configProfiles = Directory.GetFiles(userDir, ".gitconfig@*");
if (string.IsNullOrEmpty(targetProfileName)) {
    Console.WriteLine("Profile list : ");
    foreach (var configProfile in configProfiles) {
        var profileName = configProfile.Split("@")[1];

        Console.WriteLine($"    @{Path.GetFileName(profileName)}");
    }


    Console.WriteLine("─────────────────────────────────");
    Console.WriteLine("Type to target profile to swtich : ");
    targetProfileName = Console.ReadLine().Trim();
    Console.WriteLine("─────────────────────────────────");
}

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

        return;
    }
}

Console.WriteLine($"Not found profile '${targetProfileName}'");