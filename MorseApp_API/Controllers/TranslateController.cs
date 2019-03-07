using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MorseApp_API.Dtos;
using MorseApp_API.Logic;

namespace MorseApp_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        private ITranslator _translator;

        [HttpPost("decode")]
        public IActionResult DecodeMessage(MessageDto messageDto)
        {
            try
            {
                InitTranslator(messageDto.Code);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex);
            }


            var decodedMessage = _translator.Decode(messageDto.Message);

            return Ok(decodedMessage);
        }


        [HttpPost("encode")]
        public IActionResult EncodeMessage(MessageDto messageDto)
        {
            try
            {
                InitTranslator(messageDto.Code);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex);
            }
            var encodedMessage = "";
            try
            {
                encodedMessage = _translator.Encode(messageDto.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(418);
            }


            return Ok(encodedMessage);
        }

        private void InitTranslator(string code)
        {
            if (code == "morse")
                _translator = new MorseTranslator();
            else throw new InvalidOperationException("Code \'" + code + "\' is not supported!");
        }
    }
}