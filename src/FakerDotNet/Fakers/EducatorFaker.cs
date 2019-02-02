using System;
using System.Text.RegularExpressions;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IEducatorFaker
    {
        string University();
        string SecondarySchool();
        string Degree();
        string CourseName();
        string Campus();
    }

    internal class EducatorFaker : IEducatorFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public EducatorFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string University()
        {
            return string.Join(" ",
                _fakerContainer.Random.Element(EducatorData.Names),
                _fakerContainer.Random.Element(EducatorData.Types));
        }

        public string SecondarySchool()
        {
            return string.Join(" ",
                _fakerContainer.Random.Element(EducatorData.Names),
                _fakerContainer.Random.Element(EducatorData.SecondaryNames));
        }

        public string Degree()
        {
            return string.Join(" ",
                _fakerContainer.Random.Element(EducatorData.DegreeTypes),
                _fakerContainer.Random.Element(EducatorData.DegreeSubjects));
        }

        public string CourseName()
        {
            return string.Join(" ",
                _fakerContainer.Random.Element(EducatorData.DegreeSubjects),
                Numerify(_fakerContainer.Random.Element(EducatorData.CourseNumbers)));
        }

        public string Campus()
        {
            return string.Join(" ",
                _fakerContainer.Random.Element(EducatorData.Names),
                "Campus");
        }
        
        private string Numerify(string text)
        {
            return Regex.Replace(text, "#", m => _fakerContainer.Number.Digit());
        }
    }
}
