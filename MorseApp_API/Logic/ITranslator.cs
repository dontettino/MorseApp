using MorseApp_API.Dtos;

namespace MorseApp_API.Logic
{
    public interface ITranslator
    {
        string Encode(string message);

        string Decode(string message);

    }
}