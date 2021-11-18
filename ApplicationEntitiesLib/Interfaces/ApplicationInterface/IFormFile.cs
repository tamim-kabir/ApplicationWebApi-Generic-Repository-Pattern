using System;

namespace ApplicationEntitiesLib.Interfaces.ApplicationInterface
{
    public interface IFormFile
    {
        ReadOnlySpan<char> FileName { get; }
    }
}