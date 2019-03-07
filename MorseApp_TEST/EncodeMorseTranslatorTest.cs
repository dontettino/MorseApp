using Microsoft.AspNetCore.Mvc;
using MorseApp_API.Controllers;
using MorseApp_API.Dtos;
using MorseApp_API.Logic;
using System;
using System.Collections.Generic;
using Xunit;

namespace MorseApp_TEST
{
    public class EncodeMorseTranslatorTest
    {
        MorseTranslator _translator = new MorseTranslator();

        public EncodeMorseTranslatorTest()
        {

        }
        [Fact]
        public void Encode_WhenCalledOnMessageWithSpaces_ReturnsCorrectResult()
        {
            var message = ".../.--./.-./.-/...-/.-//-/---/.--.//..././-.-./.-././-";
            var expectedMessage = "sprava top secret";
            var resultMessage = _translator.Encode(message);
            Assert.Equal(expectedMessage, resultMessage);
        }

        [Fact]
        public void EncodeMessage_WhenCalledOnSingleWord_ReturnsCorrectResult()
        {
            var message = "-.--/.../---/..-./-";
            var expectedMessage = "ysoft";
            var resultMessage = _translator.Encode(message);
            Assert.Equal(expectedMessage, resultMessage);
        }

        [Fact]
        public void EncodeMessage_WhenCalledOnEmptyWord_ReturnsCorrectResult()
        {
            var message = "";
            var expectedMessage = "";
            var resultMessage = _translator.Encode(message);
            Assert.Equal(expectedMessage, resultMessage);
        }

        [Fact]
        public void EncodeMessage_WhenCalledOnCorruptedChars_ReturnsCorrectResult()
        {
            var message = "-.--/.-.-../--..-/..-./-.....";
            Action act = () => _translator.Encode(message);
            Assert.Throws<KeyNotFoundException>(act);
        }

        [Fact]
        public void EncodeMessage_WhenCalledOnNonMorseChars_ReturnsCorrectResult()
        {
            var message = "-.--/a/--..-/..-./-.....";
            Action act = () => _translator.Encode(message);
            Assert.Throws<ArgumentException>(act);
        }
    }
}