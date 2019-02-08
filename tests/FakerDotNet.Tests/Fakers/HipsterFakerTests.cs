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
            const string word = "irony";

            A.CallTo(() => _fakerContainer.Random.Element(HipsterData.Words))
                .Returns(word);

            Assert.AreEqual(word, _hipsterFaker.Word());
        }

        [Test]
        public void Word_returns_words_without_spaces()
        {
            const string word = "irony";
            const string wordWithSpace = "another word";

            A.CallTo(() => _fakerContainer.Random.Element(HipsterData.Words))
                .ReturnsNextFromSequence(wordWithSpace, word);

            Assert.AreEqual(word, _hipsterFaker.Word());
        }

        [Test]
        public void Words_returns_an_array_of_words()
        {
            var words = new[]
            {
                "pug",
                "pitchfork",
                "chia"
            };
            var wordsWithoutSpaces = HipsterData.Words.Where(word => !word.Contains(" "));

            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(wordsWithoutSpaces), 3))
                .Returns(words);

            CollectionAssert.AreEqual(words, _hipsterFaker.Words());
        }

        [Test]
        public void Words_returns_an_array_with_the_specified_number_of_words()
        {
            var words = new[]
            {
                "ugh",
                "cardigan",
                "poutine",
                "stumptown"
            };
            var wordsWithoutSpaces = HipsterData.Words.Where(word => !word.Contains(" "));

            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(wordsWithoutSpaces), 3))
                .Returns(words);

            CollectionAssert.AreEqual(words, _hipsterFaker.Words());
        }

        [Test]
        public void Words_returns_supplemental_words_when_specified()
        {
            var words = new[]
            {
                "iste",
                "seitan",
                "normcore",
                "provident"
            };
            var wordsWithoutSpaces = HipsterData.Words.Where(word => !word.Contains(" "));
            var wordsWithSupplemental = wordsWithoutSpaces.Concat(LoremData.Supplemental);

            A.CallTo(() => _fakerContainer.Random.Assortment(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(wordsWithSupplemental), 3))
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
            const string sentence = "Park iphone leggings put a bird on it.";

            Assert.AreEqual(sentence, _hipsterFaker.Sentence());
        }

        [Test]
        public void Sentence_returns_a_sentence_with_the_specified_number_of_words()
        {
            const string sentence = "Pour-over swag godard.";

            Assert.AreEqual(sentence, _hipsterFaker.Sentence(3));

        }

        [Test]
        public void Sentence_returns_supplemental_words_when_specified()
        {
            const string sentence = "Beard laboriosam sequi celiac.";

            Assert.AreEqual(sentence, _hipsterFaker.Sentence(3, true));
        }

        [Test]
        public void Sentence_includes_random_words_when_specified()
        {
            const string sentence = "Bitters retro mustache aesthetic biodiesel 8-bit.";

            Assert.AreEqual(sentence, _hipsterFaker.Sentence(4, false, 3));
        }

        [Test]
        public void Sentence_returns_an_empty_string_when_number_of_words_is_less_than_one()
        {
            Assert.AreEqual("", _hipsterFaker.Sentence(-1));
        }

        [Test]
        public void Sentences_returns_an_array_of_sentences()
        {
            var sentences = new[]
            {
                "Godard pitchfork vinegar chillwave everyday 90's whatever.",
                "Pour-over artisan distillery street waistcoat.",
                "Salvia yr leggings franzen blue bottle."
            };

            CollectionAssert.AreEqual(sentences, _hipsterFaker.Sentences());
        }

        [Test]
        public void Sentences_returns_an_array_with_the_specified_number_of_sentences()
        {
            var sentences = new[]
            {
                "Before they sold out pinterest venmo umami try-hard ugh hoodie artisan."
            };

            CollectionAssert.AreEqual(sentences, _hipsterFaker.Sentences(1));
        }

        [Test]
        public void Sentences_returns_supplemental_words_when_specified()
        {
            var sentences = new[]
            {
                "Et sustainable optio aesthetic et."
            };

            CollectionAssert.AreEqual(sentences, _hipsterFaker.Sentences(1, true));
        }

        [Test]
        public void Sentences_returns_an_empty_array_when_number_of_sentences_is_less_than_one()
        {
            CollectionAssert.IsEmpty(_hipsterFaker.Sentences(-1));
        }

        [Test]
        public void Paragraph_returns_a_string_of_sentences()
        {
            const string paragraph =
                "Migas fingerstache pbr&b tofu. Polaroid distillery typewriter echo tofu actually. Slow-carb fanny pack pickled direct trade scenester mlkshk plaid. Banjo venmo chambray cold-pressed typewriter. Fap skateboard intelligentsia.";

            Assert.AreEqual(paragraph, _hipsterFaker.Paragraph());
        }

        [Test]
        public void Paragraph_returns_a_paragraph_with_the_specified_number_of_sentences()
        {
            const string paragraph = "Yolo tilde farm-to-table hashtag. Lomo kitsch disrupt forage +1.";

            Assert.AreEqual(paragraph, _hipsterFaker.Paragraph(2));
        }

        [Test]
        public void Paragraph_returns_supplemental_words_when_specified()
        {
            const string paragraph =
                "Typewriter iste ut viral kombucha voluptatem. Sint voluptates saepe. Direct trade irony chia excepturi yuccie. Biodiesel esse listicle et quam suscipit.";

            Assert.AreEqual(paragraph, _hipsterFaker.Paragraph(3, true));
        }

        [Test]
        public void Paragraph_includes_random_sentences_when_specified()
        {
            const string paragraph =
                "Selvage vhs chartreuse narwhal vinegar. Authentic vinyl truffaut carry vhs pop-up. Hammock everyday iphone locavore thundercats bitters vegan goth. Fashion axe banh mi shoreditch whatever artisan.";

            Assert.AreEqual(paragraph, _hipsterFaker.Paragraph(2, false, 5));
        }

        [Test]
        public void Paragraph_returns_an_empty_string_when_number_of_sentences_is_less_than_one()
        {
            Assert.AreEqual("", _hipsterFaker.Paragraph(-1));
        }

        [Test]
        public void Paragraphs_returns_an_array_of_paragraphs()
        {
            var paragraphs = new[]
            {
                "Tilde microdosing blog cliche meggings. Intelligentsia five dollar toast forage yuccie. Master kitsch knausgaard. Try-hard everyday trust fund mumblecore.",
                "Normcore viral pickled. Listicle humblebrag swag tote bag. Taxidermy street hammock neutra butcher cred kale chips. Blog portland humblebrag trust fund irony.",
                "Single-origin coffee fixie cleanse tofu xoxo. Post-ironic tote bag ramps gluten-free locavore mumblecore hammock. Umami loko twee. Ugh kitsch before they sold out."
            };

            Assert.AreEqual(paragraphs, _hipsterFaker.Paragraphs());
        }

        [Test]
        public void Paragraphs_returns_an_array_with_the_specified_number_of_paragraphs()
        {
            var paragraphs = new[]
            {
                "Skateboard cronut synth +1 fashion axe. Pop-up polaroid skateboard asymmetrical. Ennui fingerstache shoreditch before they sold out. Tattooed pitchfork ramps. Photo booth yr messenger bag raw denim bespoke locavore lomo synth."
            };

            CollectionAssert.AreEqual(paragraphs, _hipsterFaker.Paragraphs(2));
        }

        [Test]
        public void Paragraphs_returns_supplemental_words_when_specified()
        {
            var paragraphs = new[]
            {
                "Quae direct trade pbr&b quo taxidermy autem loko. Umami quas ratione migas cardigan sriracha minima. Tenetur perspiciatis pickled sed eum doloribus truffaut. Excepturi dreamcatcher meditation."
            };

            CollectionAssert.AreEqual(paragraphs, _hipsterFaker.Paragraphs(3, true));
        }

        [Test]
        public void Paragraphs_returns_an_empty_array_when_number_of_paragraphs_is_less_than_one()
        {
            CollectionAssert.IsEmpty(_hipsterFaker.Paragraphs(-1));
        }

        [Test]
        public void ParagraphByChars_returns_a_paragraph()
        {
            const string paragraph =
                "Truffaut stumptown trust fund 8-bit messenger bag portland. Meh kombucha selvage swag biodiesel. Lomo kinfolk jean shorts asymmetrical diy. Wayfarers portland twee stumptown. Wes anderson biodiesel retro 90's pabst. Diy echo 90's mixtape semiotics. Cornho.";

            Assert.AreEqual(paragraph, _hipsterFaker.ParagraphByChars());
        }
    }
}
