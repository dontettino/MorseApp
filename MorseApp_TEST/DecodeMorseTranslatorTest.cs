using Microsoft.AspNetCore.Mvc;
using MorseApp_API.Controllers;
using MorseApp_API.Dtos;
using MorseApp_API.Logic;
using System;
using Xunit;

namespace MorseApp_TEST
{
    public class DecodeMorseTranslatorTest
    {
        MorseTranslator _translator = new MorseTranslator();

        public DecodeMorseTranslatorTest()
        {

        }
        [Fact]
        public void DecodeMessage_WhenCalledOnMessageWithSpaces_ReturnsCorrectResult()
        {
            var message = "sprava top secret";
            var expectedMessage = ".../.--./.-./.-/...-/.-//-/---/.--.//..././-.-./.-././-";
            var resultMessage = _translator.Decode(message);
            Assert.Equal(expectedMessage, resultMessage);
        }

        [Fact]
        public void DecodeMessage_WhenCalledOnMessageWithUpperCase_ReturnsCorrectResult()
        {
            var message = "MesSaGe";
            var expectedMessage = "--/./.../.../.-/--./.";
            var resultMessage = _translator.Decode(message);
            Assert.Equal(expectedMessage, resultMessage);
        }

        [Fact]
        public void DecodeMessage_WhenCalledOnSingleWord_ReturnsCorrectResult()
        {
            var message = "ysoft";
            var expectedMessage = "-.--/.../---/..-./-";
            var resultMessage = _translator.Decode(message);
            Assert.Equal(expectedMessage, resultMessage);
        }

        [Fact]
        public void DecodeMessage_WhenCalledOnEmptyWord_ReturnsCorrectResult()
        {
            var message = "";
            var expectedMessage = "";
            var resultMessage = _translator.Decode(message);
            Assert.Equal(expectedMessage, resultMessage);
        }

        [Fact]
        public void DecodeMessage_WhenCalledOnSpecialChars_ReturnsCorrectResult()
        {
            var message = "y^s#o{f=t<";
            Action act = () => _translator.Decode(message);
            Assert.Throws<ArgumentException>(act);
        }
    }
}