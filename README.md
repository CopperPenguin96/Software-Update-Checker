# Software-Update-Checker
.NET Software Version checker. Will result in 3 scenarios: Current, Outdated, Developer.

Example:

```
switch (Updates.Check("http://somewebsite.org/latest.txt"))
{
    case VersionResult.Current:
        Console.WriteLine("Your software is updated!");
        break;
    case VersionResult.Outdated:
        Console.WriteLine("Your software is outdated.");
        break;
    case VersionResult.Developer:
        Console.WriteLine("You are using an unreleased version of your software!");
        break;
}
```

In order for this to work you must have a txt file on your webserver that you can tell us to read that is formatted like so:

```
Title (first line If applicable)
Major Code (first line if Title not applicable)
Minor Code
Revision Code (-1 if not applicable)
Build Code (-1 if not applicable)
```


