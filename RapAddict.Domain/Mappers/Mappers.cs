using RapAddict.Domain.Entities.Albums;
using System.Data;

namespace RapAddict.Domain.Mappers
{
    internal static class Mappers
    {
        internal static Album ToAlbum(this IDataRecord record)
        {
            return new Album(
                (int)record["Id"],
                (string)record["Title"],
                record["ReleaseDate"] is DBNull ? null : (DateTime?)record["ReleaseDate"],
                record["DurationMs"] is DBNull ? null : (int?)record["DurationMs"]);
        }
    }
}
