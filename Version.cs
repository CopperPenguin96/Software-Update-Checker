using System;
using System.Collections.Generic;

namespace Updater
{
    public enum VersionResult { Current, Outdated, Developer }
    public class Version
    {
        public string Title { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Revision { get; set; }
        public int Build { get; set; }
        public bool ShowTitle { get; set; }

        public static Version LatestStable { get; set; }

        public static Version ToVersion(string title, List<string> list)
        {
            List<string> x = new List<string> {title};
            x.AddRange(list);
            return MakeVersion(x);
        }

        public static Version ToVersion(List<string> list)
        {
            List<string> x = new List<string>();
            x.AddRange(list);
            return MakeVersion(x);
        }
        private static Version MakeVersion(IReadOnlyList<string> list)
        {
            return new Version
            {
                Title = list[0],
                Major = int.Parse(list[1]),
                Minor = int.Parse(list[2]),
                Revision = int.Parse(list[3]),
                Build = int.Parse(list[4]),
            };
        }

        /// <summary>
        /// Creates a new version object. Not to be used
        /// </summary>
        public Version()
        {

        }

        /// <summary>
        /// Creates a new Version object
        /// </summary>
        /// <param name="major">From a 4 digit version code: X.0.0.0</param>
        /// <param name="minor">From a 4 digit version code: 0.X.0.0</param>
        /// <param name="revision">(Optional) From a 4 digit version code: 0.0.X.0</param>
        /// <param name="build">(Optional) From a 4 digit version code: 0.0.0.X</param>
        /// <param name="title">(Optional) The title of the version, if desired for instance Android "Honeycomb"</param>
        /// <param name="show">(Optional) Whether to show the title when the ToString() method is called. Default is false.</param>
        public Version(int major, int minor, int revision = -1, int build = -1, string title = null, bool show = false)
        {
            Title = title;
            Major = major;
            Minor = minor;
            Revision = revision;
            Build = build;
            ShowTitle = show;

            if (title == null && show)
                throw new ArgumentException("Value show cannot be set to true if title is null", nameof(show));
        }

        public static int Compare(Version version1, Version version2)
        {
            if (version1.Title == version2.Title)
            {
                if (version1.Major < version2.Major) return 1;
                if (version1.Major > version2.Major) return 0;
                if (version1.Minor < version2.Minor) return 1;
                if (version1.Minor > version2.Minor) return 0;
                if (version1.Revision < version2.Revision) return 1;
                if (version1.Revision > version2.Revision) return 0;
                if (version1.Build < version2.Build) return 1;
                if (version1.Build > version2.Build) return 0;
                return -1;
            }

            if (version1.Title == "Alpha") return 1;
            if (version1.Title == "Beta" && version2.Title == "Alpha") return 0;
            if (version1.Major < version2.Major) return 1;
            if (version1.Major > version2.Major) return 0;
            if (version1.Minor < version2.Minor) return 1;
            if (version1.Minor > version2.Minor) return 0;
            if (version1.Revision < version2.Revision) return 1;
            if (version1.Revision > version2.Revision) return 0;
            if (version1.Build < version2.Build) return 1;
            if (version1.Build > version2.Build) return 0;
            return -1;
        }

        public override string ToString()
        {
            string finalResult = "";
            if (ShowTitle || Title == "Alpha" || Title == "Beta")
            {
                finalResult = Title + " ";
            }

            finalResult += $"{Major}.{Minor}";
            if (Revision <= -1) return finalResult;
            finalResult += $".{Revision}";
            if (Build > -1)
            {
                finalResult += $".{Build}";
            }

            return finalResult;
        }
    }
}
