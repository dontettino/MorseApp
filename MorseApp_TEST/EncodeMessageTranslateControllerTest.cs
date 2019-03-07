using Microsoft.AspNetCore.Mvc;
using MorseApp_API.Controllers;
using MorseApp_API.Dtos;
using MorseApp_API.Logic;
using System;
using Xunit;

namespace MorseApp_TEST
{
    public class EncodeMessageTranslateControllerTest
    {
        TranslateController _controller;
        ITranslator _translator;

        public EncodeMessageTranslateControllerTest()
        {
            _controller = new TranslateController();
        }

        [Fact]
        public void EncodeMessage_WhenCalled_ReturnsOkResult()
        {
            var message = new MessageDto();
            message.Code = "morse";
            message.Message = "-.--/.../---/..-./-";
            var okResult = _controller.EncodeMessage(message);
            Assert.IsType<OkObjectResult>(okResult);

        }

        [Fact]
        public void EncodeMessage_WhenCalled_ReturnsBadRequest()
        {
            var message = new MessageDto();
            message.Code = "horse";
            message.Message = "message";
            var badRequestResult = _controller.EncodeMessage(message);
            Assert.IsType<BadRequestObjectResult>(badRequestResult);

        }

        [Fact]
        public void EncodeMessage_WhenCalledOnCorruptedChars_ReturnsBadRequest()
        {
            var message = new MessageDto();
            message.Code = "morse";
            message.Message = "-.--/.-.-../--..-/..-./-.....";
            var badRequestResult = _controller.EncodeMessage(message);
            Assert.IsType<BadRequestObjectResult>(badRequestResult);
        }
    }
}
