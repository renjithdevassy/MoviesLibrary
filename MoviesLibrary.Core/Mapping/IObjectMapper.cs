using System;


namespace MoviesLibrary.Core
{
    public interface IObjectMapper
    {
        object Map(object source, Type sourceType, Type destinationType);

        D Map<D>(object source, Type sourceType);

        D Map<S, D>(S src);
    }
}
