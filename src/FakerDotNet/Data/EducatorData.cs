using System.Collections.Generic;

namespace FakerDotNet.Data
{
    internal static class EducatorData
    {
        public static readonly IEnumerable<string> Names = new[]
        {
            "Marblewald",
            "Mallowtow",
            "Brookville",
            "Flowerlake",
            "Falconholt",
            "Ostbarrow",
            "Lakeacre",
            "Clearcourt",
            "Ironston",
            "Mallowpond",
            "Iceborough",
            "Icelyn",
            "Brighthurst",
            "Bluemeadow",
            "Vertapple",
            "Ironbarrow"
        };

        public static readonly IEnumerable<string> SecondaryNames = new[]
        {
            "High School",
            "Secondary College",
            "High"
        };

        public static readonly IEnumerable<string> Types = new[]
        {
            "College",
            "University",
            "Technical College",
            "TAFE"
        };

        public static readonly IEnumerable<string> DegreeSubjects = new[]
        {
            "Arts",
            "Business",
            "Education",
            "Applied Science (Psychology)",
            "Architectural Technology",
            "Biological Science",
            "Biomedical Science",
            "Commerce",
            "Communications",
            "Creative Arts",
            "Criminology",
            "Design",
            "Engineering",
            "Forensic Science",
            "Health Science",
            "Information Systems",
            "Computer Science",
            "Law",
            "Nursing",
            "Medicine",
            "Psychology",
            "Teaching"
        };

        public static readonly IEnumerable<string> DegreeTypes = new[]
        {
            "Associate Degree in",
            "Bachelor of",
            "Master of"
        };

        public static readonly IEnumerable<string> CourseNumbers = new[]
        {
            "1##",
            "2##",
            "3##",
            "4##",
            "5##"
        };
    }
}
