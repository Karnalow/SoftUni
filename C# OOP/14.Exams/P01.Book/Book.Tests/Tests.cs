namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase("Legend for Sasho", "Ivan")]
        [TestCase("The inpossible 3", "Pesho")]
        public void CtorShouldInitializeAllValues
            (string bookName, string authorName)
        {
            Book book = new Book(bookName, authorName);

            Assert.IsNotNull(book.FootnoteCount);
            Assert.IsNotNull(book.Author);
            Assert.IsNotNull(book.BookName);
        }

        [Test]
        [TestCase("", "Ivan")]
        [TestCase(null, "Pesho")]
        public void CtorShouldThrowArgumentExceptionForInvalidBookName
            (string bookName, string authorName)
        {
            Assert.Throws<ArgumentException>(() => new Book(bookName, authorName));
        }

        [Test]
        [TestCase("Aladin", null)]
        [TestCase("History of Zlatan", "")]
        public void CtorShouldThrowArgumentExceptionForInvalidAuthor
            (string bookName, string authorName)
        {
            Assert.Throws<ArgumentException>(() => new Book(bookName, authorName));
        }

        [Test]
        [TestCase(10, "text")]
        [TestCase(500, "Ivan")]
        [TestCase(569, "Pesho")]
        public void AddFootnoteShouldAddFootnoteIfFootnoteDoesNotExist
            (int footNoteNumber, string text)
        {
            Book book = new Book("HarryPotter", "Ivan");

            book.AddFootnote(footNoteNumber, text);

            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        [TestCase(10, "text")]
        [TestCase(500, "Ivan")]
        [TestCase(569, "Pesho")]
        public void AddFootnoteShouldThrowInvalidOperationExceptionIfFootnoteAlreayExist
            (int footNoteNumber, string text)
        {
            Book book = new Book("HarryPotter", "Ivan");

            book.AddFootnote(footNoteNumber, text);

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(footNoteNumber, text));
        }

        [Test]
        [TestCase(1000, "zzzzz")]
        [TestCase(1424, "bbbbb")]
        [TestCase(3453, "aaaaa")]
        public void FindFootnoteShouldFootnoteWithTheGivenNumberAndReturnFootnoteAndText
            (int footNoteNumber, string note)
        {
            Book book = new Book("HarryPotter", "Ivan");
            book.AddFootnote(footNoteNumber, note);

            string text = book.FindFootnote(footNoteNumber);

            Assert.AreEqual(text, book.FindFootnote(footNoteNumber));
        }

        [Test]
        [TestCase(1000)]
        [TestCase(1424)]
        [TestCase(3453)]
        public void FindFootnoteShouldThrowInvalidOperationExceptionIfFootnoteDoesNotExist
            (int footNoteNumber)
        {
            Book book = new Book("HarryPotter", "Ivan");

            Assert.Throws<InvalidOperationException>
                (() => book.FindFootnote(footNoteNumber));
        }

        [Test]
        [TestCase(1000, "new text")]
        [TestCase(1424, "old text")]
        [TestCase(3453, "oldest text")]
        public void AlterFootnoteShouldThrowInvalidOperationException
            (int footNoteNumber, string newText)
        {
            Book book = new Book("HarryPotter", "Ivan");

            Assert.Throws<InvalidOperationException>
                (() => book.AlterFootnote(footNoteNumber, newText));
        }

        [Test]
        [TestCase(1000, "new text")]
        [TestCase(1424, "old text")]
        [TestCase(3453, "oldest text")]
        public void AlterFootnoteShouldAlterFootnoteWithTheGivenFootnoteNumberAndNewText
            (int footNoteNumber, string newText)
        {
            string oldText = "Pesho";

            Book book = new Book("HarryPotter", "Ivan");
            book.AddFootnote(footNoteNumber, oldText);
            book.AlterFootnote(footNoteNumber, newText);

            Assert.AreNotEqual(oldText, newText);
        }
    }
}