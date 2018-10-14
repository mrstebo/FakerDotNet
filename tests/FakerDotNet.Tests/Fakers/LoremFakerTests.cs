using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private static readonly LoremData Data = new LoremData();

        private IFakerContainer _fakerContainer;
        private ILoremFaker _loremFaker;

        [Test]
        public void Word_returns_a_word()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Words)))
                .Returns("word");

            Assert.AreEqual("word", _loremFaker.Word());
        }

        [Test]
        public void Words_returns_an_array_of_words()
        {
            var words = new[] {"word1", "word2", "word3"}.AsEnumerable();
            
            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Words), 3))
                .ReturnsNextFromSequence(words);

            CollectionAssert.AreEqual(words, _loremFaker.Words());
        }

        [Test]
        public void Words_returns_an_array_with_the_specified_number_of_words()
        {
            Assert.Fail();
        }

        [Test]
        public void Words_returns_supplemental_words_when_specified()
        {
            Assert.Fail();
        }

        [Test]
        public void Multibyte_returns_a_utf8_encoded_string()
        {
            Assert.Fail();
        }

        [Test]
        public void Characters_returns_a_string_of_characters()
        {
            Assert.Fail();
        }

        [Test]
        public void Characters_returns_a_string_with_the_specified_number_of_characters()
        {
            Assert.Fail();
        }

        [Test]
        public void Characters_returns_an_empty_string_when_number_of_characters_is_less_than_one()
        {
            Assert.Fail();
        }

        [Test]
        public void Sentence_returns_a_string_of_words()
        {
            Assert.Fail();
        }

        [Test]
        public void Sentence_returns_a_sentence_with_the_specified_number_of_words()
        {
            Assert.Fail();
        }

        [Test]
        public void Sentence_returns_supplemental_words_when_specified()
        {
            Assert.Fail();
        }

        [Test]
        public void Sentence_includes_random_words_when_specified()
        {
            Assert.Fail();
        }

        [Test]
        public void Sentence_returns_an_empty_string_when_number_of_words_is_less_than_one()
        {
            Assert.Fail();
        }

        [Test]
        public void Sentences_returns_a_string_of_sentences()
        {
            Assert.Fail();
        }

        [Test]
        public void Sentences_returns_a_string_with_the_specified_number_of_sentences()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Sentences_returns_supplemental_words_when_specified()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Sentences_returns_an_empty_string_when_number_of_sentences_is_less_than_one()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Paragraph_returns_a_string_of_sentences()
        {
            Assert.Fail();
        }

        [Test]
        public void Paragraph_returns_a_paragraph_with_the_specified_number_of_words()
        {
            Assert.Fail();
        }

        [Test]
        public void Paragraph_returns_supplemental_words_when_specified()
        {
            Assert.Fail();
        }

        [Test]
        public void Paragraph_includes_random_sentences_when_specified()
        {
            Assert.Fail();
        }

        [Test]
        public void Paragraph_returns_an_empty_string_when_number_of_sentences_is_less_than_one()
        {
            Assert.Fail();
        }

        [Test]
        public void Paragraphs_returns_a_string_of_paragraphs()
        {
            Assert.Fail();
        }

        [Test]
        public void Paragraphs_returns_a_string_with_the_specified_number_of_paragraphs()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Paragraphs_returns_supplemental_words_when_specified()
        {
            Assert.Fail();
        }
        
        [Test]
        public void Paragraphs_returns_an_empty_string_when_number_of_paragraphs_is_less_than_one()
        {
            Assert.Fail();
        }

        [Test]
        public void ParagraphByChar_returns_a_paragraph()
        {
            Assert.Fail();
        }

        [Test]
        public void ParagraphByChar_returns_a_paragraph_with_the_specified_number_of_characters()
        {
            Assert.Fail();
        }
    }
}
