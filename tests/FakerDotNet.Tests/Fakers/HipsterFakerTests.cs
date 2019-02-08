using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class HipsterFakerTests
    {
        private static readonly IEnumerable<string> WordsWithoutSpaces = HipsterData.Words
            .Where(word => !word.Contains(" ")); 
        
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _hipsterFaker = new HipsterFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IHipsterFaker _hipsterFaker;

        [Test]
        public void Word_returns_a_word()
        {
            A.CallTo(() => _fakerContainer.Random.Element(HipsterData.Words))
                .Returns("word");

            Assert.AreEqual("word", _hipsterFaker.Word());
        }

        [Test]
        public void Words_returns_an_array_of_words()
        {
            var words = new[] {"word1", "word2", "word3"};
            
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces), 3))
                .ReturnsNextFromSequence(words.AsEnumerable());

            CollectionAssert.AreEqual(words, _hipsterFaker.Words());
        }

        [Test]
        [TestCase(5)]
        [TestCase(17)]
        [TestCase(123)]
        public void Words_returns_an_array_with_the_specified_number_of_words(int count)
        {
            var words = Enumerable.Range(0, count).Select(i => $"word{i}").ToArray();
            
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces), count))
                .ReturnsNextFromSequence(words.AsEnumerable());

            CollectionAssert.AreEqual(words, _hipsterFaker.Words(count));
        }

        [Test]
        public void Words_returns_supplemental_words_when_specified()
        {
            var words = new[] {"word1", "word2", "word3"};

            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces.Concat(HipsterData.Supplemental)), 3))
                .Returns(words);
            
            CollectionAssert.AreEqual(words, _hipsterFaker.Words(3, true));
        }

        [Test]
        public void Words_returns_words_with_spaces_when_specified()
        {
            var words = new[] {"qui", "magni", "craft beer", "est"};

            A.CallTo(() => _fakerContainer.Random.Assortment(HipsterData.Words, 3))
                .Returns(words);

            CollectionAssert.AreEqual(words, _hipsterFaker.Words(3, false, true));
        }

        [Test]
        public void Words_returns_an_empty_array_when_number_of_words_is_less_than_one()
        {
            CollectionAssert.IsEmpty(_hipsterFaker.Words(-1));
        }

        [Test]
        public void Sentence_returns_a_string_of_words()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces), 4))
                .Returns(new[] {"this", "is", "a", "test"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);

            Assert.AreEqual("This is a test.", _hipsterFaker.Sentence());
        }

        [Test]
        public void Sentence_returns_a_sentence_with_the_specified_number_of_words()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces), 5))
                .Returns(new[] {"this", "is", "a", "longer", "sentence"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);

            Assert.AreEqual("This is a longer sentence.", _hipsterFaker.Sentence(5));

        }

        [Test]
        public void Sentence_returns_supplemental_words_when_specified()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces.Concat(HipsterData.Supplemental)), 4))
                .Returns(new[] {"this", "is", "a", "test"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);

            Assert.AreEqual("This is a test.", _hipsterFaker.Sentence(4, true));
        }

        [Test]
        public void Sentence_includes_random_words_when_specified()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces), 5))
                .Returns(new[] {"this", "is", "a", "longer", "sentence"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 3))
                .Returns(1);

            Assert.AreEqual("This is a longer sentence.", _hipsterFaker.Sentence(4, false, 3));
        }

        [Test]
        public void Sentence_returns_an_empty_string_when_number_of_words_is_less_than_one()
        {
            Assert.AreEqual("", _hipsterFaker.Sentence(-1));
        }

        [Test]
        public void Sentences_returns_an_array_of_sentences()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces), 3))
                .ReturnsNextFromSequence(
                    new[] {"big", "bad", "boo"},
                    new[] {"small", "tiny", "micro",},
                    new[] {"alright", "sometimes", "maybe"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);

            CollectionAssert.AreEqual(new[]
            {
                "Big bad boo.",
                "Small tiny micro.",
                "Alright sometimes maybe.",
            }, _hipsterFaker.Sentences());
        }

        [Test]
        public void Sentences_returns_an_array_with_the_specified_number_of_sentences()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces), 3))
                .ReturnsNextFromSequence(
                    new[] {"big", "bad", "boo"},
                    new[] {"small", "tiny", "micro"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);

            CollectionAssert.AreEqual(new[]
            {
                "Big bad boo.",
                "Small tiny micro."
            }, _hipsterFaker.Sentences(2));
        }

        [Test]
        public void Sentences_returns_supplemental_words_when_specified()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces.Concat(HipsterData.Supplemental)), 3))
                .ReturnsNextFromSequence(
                    new[] {"big", "bad", "boo"},
                    new[] {"small", "tiny", "micro"},
                    new[] {"alright", "sometimes", "maybe"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);

            CollectionAssert.AreEqual(new[]
            {
                "Big bad boo.",
                "Small tiny micro.",
                "Alright sometimes maybe."
            }, _hipsterFaker.Sentences(3, true));
        }

        [Test]
        public void Sentences_returns_an_empty_array_when_number_of_sentences_is_less_than_one()
        {
            CollectionAssert.IsEmpty(_hipsterFaker.Sentences(-1));
        }
        
        [Test]
        public void Paragraph_returns_a_string_of_sentences()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces), 3))
                .ReturnsNextFromSequence(
                    new[] {"big", "bad", "boo"},
                    new[] {"small", "tiny", "micro"},
                    new[] {"alright", "sometimes", "maybe"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);

            Assert.AreEqual("Big bad boo. Small tiny micro. Alright sometimes maybe.", _hipsterFaker.Paragraph());
        }

        [Test]
        public void Paragraph_returns_a_paragraph_with_the_specified_number_of_sentences()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces), 3))
                .ReturnsNextFromSequence(
                    new[] {"big", "bad", "boo"},
                    new[] {"small", "tiny", "micro"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);

            Assert.AreEqual("Big bad boo. Small tiny micro.", _hipsterFaker.Paragraph(2));
        }

        [Test]
        public void Paragraph_returns_supplemental_words_when_specified()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces.Concat(HipsterData.Supplemental)), 3))
                .ReturnsNextFromSequence(
                    new[] {"big", "bad", "boo"},
                    new[] {"small", "tiny", "micro"},
                    new[] {"alright", "sometimes", "maybe"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);
            
            Assert.AreEqual("Big bad boo. Small tiny micro. Alright sometimes maybe.", _hipsterFaker.Paragraph(3, true));
        }

        [Test]
        public void Paragraph_includes_random_sentences_when_specified()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces), 3))
                .ReturnsNextFromSequence(
                    new[] {"big", "bad", "boo"},
                    new[] {"small", "tiny", "micro"},
                    new[] {"alright", "sometimes", "maybe"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);
            A.CallTo(() => _fakerContainer.Number.Between(0, 5))
                .Returns(1);

            Assert.AreEqual("Big bad boo. Small tiny micro. Alright sometimes maybe.", 
                _hipsterFaker.Paragraph(2, false, 5));
        }

        [Test]
        public void Paragraph_returns_an_empty_string_when_number_of_sentences_is_less_than_one()
        {
            Assert.AreEqual("", _hipsterFaker.Paragraph(-1));
        }

        [Test]
        public void Paragraphs_returns_an_array_of_paragraphs()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces), 3))
                .ReturnsNextFromSequence(
                    new[] {"one", "x", "y"},
                    new[] {"two", "x", "y"},
                    new[] {"three", "x", "y"},
                    new[] {"four", "x", "y"},
                    new[] {"five", "x", "y"},
                    new[] {"six", "x", "y"},
                    new[] {"seven", "x", "y"},
                    new[] {"eight", "x", "y"},
                    new[] {"nine", "x", "y"});
            A.CallTo(() => _fakerContainer.Number.Between(A<double>.Ignored, A<double>.Ignored))
                .Returns(0);

            CollectionAssert.AreEqual(new[]
            {
                "One x y. Two x y. Three x y.",
                "Four x y. Five x y. Six x y.",
                "Seven x y. Eight x y. Nine x y."
            }, _hipsterFaker.Paragraphs());
        }

        [Test]
        public void Paragraphs_returns_an_array_with_the_specified_number_of_paragraphs()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces), 3))
                .ReturnsNextFromSequence(
                    new[] {"one", "x", "y"},
                    new[] {"two", "x", "y"},
                    new[] {"three", "x", "y"},
                    new[] {"four", "x", "y"},
                    new[] {"five", "x", "y"},
                    new[] {"six", "x", "y"});
            A.CallTo(() => _fakerContainer.Number.Between(A<double>.Ignored, A<double>.Ignored))
                .Returns(0);

            CollectionAssert.AreEqual(new[]
            {
                "One x y. Two x y. Three x y.",
                "Four x y. Five x y. Six x y."
            }, _hipsterFaker.Paragraphs(2));
        }
        
        [Test]
        public void Paragraphs_returns_supplemental_words_when_specified()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces.Concat(HipsterData.Supplemental)), 3))
                .ReturnsNextFromSequence(
                    new[] {"one", "x", "y"},
                    new[] {"two", "x", "y"},
                    new[] {"three", "x", "y"},
                    new[] {"four", "x", "y"},
                    new[] {"five", "x", "y"},
                    new[] {"six", "x", "y"},
                    new[] {"seven", "x", "y"},
                    new[] {"eight", "x", "y"},
                    new[] {"nine", "x", "y"});
            A.CallTo(() => _fakerContainer.Number.Between(A<double>.Ignored, A<double>.Ignored))
                .Returns(0);

            CollectionAssert.AreEqual(new[]
            {
                "One x y. Two x y. Three x y.",
                "Four x y. Five x y. Six x y.",
                "Seven x y. Eight x y. Nine x y."
            }, _hipsterFaker.Paragraphs(3, true));
        }
        
        [Test]
        public void Paragraphs_returns_an_empty_array_when_number_of_paragraphs_is_less_than_one()
        {
            CollectionAssert.IsEmpty(_hipsterFaker.Paragraphs(-1));
        }

        [Test]
        public void ParagraphByChars_returns_a_paragraph()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces), 3))
                .ReturnsNextFromSequence(
                    new[] {"one", "x", "y"},
                    new[] {"two", "x", "y"},
                    new[] {"three", "x", "y"},
                    new[] {"four", "x", "y"});
            A.CallTo(() => _fakerContainer.Number.Between(A<double>.Ignored, A<double>.Ignored))
                .Returns(0);

            Assert.AreEqual("One x y. Two x y. Three x y.", _hipsterFaker.ParagraphByChars(28));
        }
        
        [Test]
        public void ParagraphByChars_will_trim_off_the_end()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(WordsWithoutSpaces), 3))
                .ReturnsNextFromSequence(
                    new[] {"one", "x", "y"},
                    new[] {"two", "x", "y"},
                    new[] {"three", "x", "y"},
                    new[] {"four", "x", "y"});
            A.CallTo(() => _fakerContainer.Number.Between(A<double>.Ignored, A<double>.Ignored))
                .Returns(0);

            Assert.AreEqual("One x y. Two x y. Thre.", _hipsterFaker.ParagraphByChars(23));
        }
    }
}
