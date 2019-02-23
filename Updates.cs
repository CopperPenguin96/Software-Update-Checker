namespace Updater
{
    public class Updates
    {
        public static bool Checked { get; private set; }
        public static VersionResult Check(string updateUrl)
        {
            Version currentOnline = Version.ToVersion(
                Network.GetUrlSourceAsList(updateUrl)
            );
            Checked = true;
            int versionCompare = Version.Compare(Version.LatestStable, currentOnline);
            switch (versionCompare)
            {
                case -1:
                    return VersionResult.Current;
                case 0:
                    return VersionResult.Developer;
                case 1:
                    return VersionResult.Outdated;
                default:
                    return VersionResult.Current;
            }
        }
    }
}
