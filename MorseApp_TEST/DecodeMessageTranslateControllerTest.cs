using Microsoft.AspNetCore.Mvc;
using MorseApp_API.Controllers;
using MorseApp_API.Dtos;
using MorseApp_API.Logic;
using System;
using Xunit;

namespace MorseApp_TEST
{
    public class DecodeMessageTranslateControllerTest
    {
        TranslateController _controller;
        ITranslator _translator;

        public DecodeMessageTranslateControllerTest()
        {
            _controller = new TranslateController();
        }
        [Fact]
        public void DecodeMessage_WhenCalled_ReturnsOkResult()
        {
            var message = new MessageDto();
            message.Code = "morse";
            message.Message = "message";
            var okResult = _controller.DecodeMessage(message);
            Assert.IsType<OkObjectResult>(okResult);

        }

        [Fact]
        public void DecodeMessage_WhenCalled_ReturnsBadRequest()
        {
            var message = new MessageDto();
            message.Code = "horse";
            message.Message = "message";
            var badRequestResult = _controller.DecodeMessage(message);
            Assert.IsType<BadRequestObjectResult >(badRequestResult);

        }
    }
}
