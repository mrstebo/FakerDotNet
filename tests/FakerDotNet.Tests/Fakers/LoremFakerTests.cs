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
    public class LoremFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _loremFaker = new LoremFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private ILoremFaker _loremFaker;

        [Test]
        public void Word_returns_a_word()
        {
            A.CallTo(() => _fakerContainer.Random.Element(LoremData.Words))
                .Returns("word");

            Assert.AreEqual("word", _loremFaker.Word());
        }

        [Test]
        public void Words_returns_an_array_of_words()
        {
            var words = new[] {"word1", "word2", "word3"};
            
            A.CallTo(() => _fakerContainer.Random.Assortment(LoremData.Words, 3))
                .ReturnsNextFromSequence(words.AsEnumerable());

            CollectionAssert.AreEqual(words, _loremFaker.Words());
        }

        [Test]
        [TestCase(5)]
        [TestCase(17)]
        [TestCase(123)]
        public void Words_returns_an_array_with_the_specified_number_of_words(int count)
        {
            var words = Enumerable.Range(0, count).Select(i => $"word{i}").ToArray();
            
            A.CallTo(() => _fakerContainer.Random.Assortment(LoremData.Words, count))
                .ReturnsNextFromSequence(words.AsEnumerable());

            CollectionAssert.AreEqual(words, _loremFaker.Words(count));
        }

        [Test]
        public void Words_returns_supplemental_words_when_specified()
        {
            var words = new[] {"word1", "word2", "word3"};

            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(LoremData.Words.Concat(LoremData.Supplemental)), 3))
                .Returns(words);
            
            CollectionAssert.AreEqual(words, _loremFaker.Words(3, true));
        }

        [Test]
        public void Multibyte_returns_a_utf8_encoded_string()
        {
            A.CallTo(() => _fakerContainer.Random.Element(LoremData.Multibytes))
                .Returns(new byte[] {240, 159, 152, 128});

            Assert.AreEqual("😀", _loremFaker.Multibyte());
        }

        [Test]
        public void Character_returns_a_character()
        {
            A.CallTo(() => _fakerContainer.Random.Element(LoremData.Characters))
                .Returns("x");
            
            Assert.AreEqual("x", _loremFaker.Character());
        }

        [Test]
        public void Characters_returns_a_string_of_characters()
        {
            A.CallTo(() => _fakerContainer.Random.Element(LoremData.Characters))
                .Returns("x");

            var expected = string.Join("", Enumerable.Range(0, 255).Select(_ => "x"));
            
            Assert.AreEqual(expected, _loremFaker.Characters());
        }

        [Test]
        [TestCase(5)]
        [TestCase(17)]
        [TestCase(1423)]
        public void Characters_returns_a_string_with_the_specified_number_of_characters(int count)
        {
            A.CallTo(() => _fakerContainer.Random.Element(LoremData.Characters))
                .Returns("x");

            var expected = string.Join("", Enumerable.Range(0, count).Select(_ => "x"));
            
            Assert.AreEqual(expected, _loremFaker.Characters(count));
        }

        [Test]
        public void Characters_returns_an_empty_string_when_number_of_characters_is_less_than_one()
        {
            Assert.AreEqual("", _loremFaker.Characters(-1));
        }

        [Test]
        public void Sentence_returns_a_string_of_words()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(LoremData.Words, 4))
                .Returns(new[] {"this", "is", "a", "test"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);

            Assert.AreEqual("This is a test.", _loremFaker.Sentence());
        }

        [Test]
        public void Sentence_returns_a_sentence_with_the_specified_number_of_words()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(LoremData.Words, 5))
                .Returns(new[] {"this", "is", "a", "longer", "sentence"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);

            Assert.AreEqual("This is a longer sentence.", _loremFaker.Sentence(5));

        }

        [Test]
        public void Sentence_returns_supplemental_words_when_specified()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(LoremData.Words.Concat(LoremData.Supplemental)), 4))
                .Returns(new[] {"this", "is", "a", "test"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);

            Assert.AreEqual("This is a test.", _loremFaker.Sentence(4, true));
        }

        [Test]
        public void Sentence_includes_random_words_when_specified()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(LoremData.Words, 5))
                .Returns(new[] {"this", "is", "a", "longer", "sentence"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 3))
                .Returns(1);

            Assert.AreEqual("This is a longer sentence.", _loremFaker.Sentence(4, false, 3));
        }

        [Test]
        public void Sentence_returns_an_empty_string_when_number_of_words_is_less_than_one()
        {
            Assert.AreEqual("", _loremFaker.Sentence(-1));
        }

        [Test]
        public void Sentences_returns_a_collection_of_sentences()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(LoremData.Words, 3))
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
            }, _loremFaker.Sentences());
        }

        [Test]
        public void Sentences_returns_a_collection_with_the_specified_number_of_sentences()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(LoremData.Words, 3))
                .ReturnsNextFromSequence(
                    new[] {"big", "bad", "boo"},
                    new[] {"small", "tiny", "micro"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);

            CollectionAssert.AreEqual(new[]
            {
                "Big bad boo.",
                "Small tiny micro."
            }, _loremFaker.Sentences(2));
        }

        [Test]
        public void Sentences_returns_supplemental_words_when_specified()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(LoremData.Words.Concat(LoremData.Supplemental)), 3))
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
            }, _loremFaker.Sentences(3, true));
        }

        [Test]
        public void Sentences_returns_an_empty_collection_when_number_of_sentences_is_less_than_one()
        {
            CollectionAssert.IsEmpty(_loremFaker.Sentences(-1));
        }
        
        [Test]
        public void Paragraph_returns_a_string_of_sentences()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(LoremData.Words, 3))
                .ReturnsNextFromSequence(
                    new[] {"big", "bad", "boo"},
                    new[] {"small", "tiny", "micro"},
                    new[] {"alright", "sometimes", "maybe"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);

            Assert.AreEqual("Big bad boo. Small tiny micro. Alright sometimes maybe.", _loremFaker.Paragraph());
        }

        [Test]
        public void Paragraph_returns_a_paragraph_with_the_specified_number_of_sentences()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(LoremData.Words, 3))
                .ReturnsNextFromSequence(
                    new[] {"big", "bad", "boo"},
                    new[] {"small", "tiny", "micro"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);

            Assert.AreEqual("Big bad boo. Small tiny micro.", _loremFaker.Paragraph(2));
        }

        [Test]
        public void Paragraph_returns_supplemental_words_when_specified()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(LoremData.Words.Concat(LoremData.Supplemental)), 3))
                .ReturnsNextFromSequence(
                    new[] {"big", "bad", "boo"},
                    new[] {"small", "tiny", "micro"},
                    new[] {"alright", "sometimes", "maybe"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);
            
            Assert.AreEqual("Big bad boo. Small tiny micro. Alright sometimes maybe.", _loremFaker.Paragraph(3, true));
        }

        [Test]
        public void Paragraph_includes_random_sentences_when_specified()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(LoremData.Words, 3))
                .ReturnsNextFromSequence(
                    new[] {"big", "bad", "boo"},
                    new[] {"small", "tiny", "micro"},
                    new[] {"alright", "sometimes", "maybe"});
            A.CallTo(() => _fakerContainer.Number.Between(0, 6))
                .Returns(0);
            A.CallTo(() => _fakerContainer.Number.Between(0, 5))
                .Returns(1);

            Assert.AreEqual("Big bad boo. Small tiny micro. Alright sometimes maybe.", 
                _loremFaker.Paragraph(2, false, 5));
        }

        [Test]
        public void Paragraph_returns_an_empty_string_when_number_of_sentences_is_less_than_one()
        {
            Assert.AreEqual("", _loremFaker.Paragraph(-1));
        }

        [Test]
        public void Paragraphs_returns_a_collection_of_paragraphs()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(LoremData.Words, 3))
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
            }, _loremFaker.Paragraphs());
        }

        [Test]
        public void Paragraphs_returns_a_collection_with_the_specified_number_of_paragraphs()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(LoremData.Words, 3))
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
            }, _loremFaker.Paragraphs(2));
        }
        
        [Test]
        public void Paragraphs_returns_supplemental_words_when_specified()
        {
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(LoremData.Words.Concat(LoremData.Supplemental)), 3))
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
            }, _loremFaker.Paragraphs(3, true));
        }
        
        [Test]
        public void Paragraphs_returns_an_empty_collection_when_number_of_paragraphs_is_less_than_one()
        {
            CollectionAssert.IsEmpty(_loremFaker.Paragraphs(-1));
        }
    }
}
